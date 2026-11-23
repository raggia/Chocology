using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Sharing
{
    /// <summary>Exports an isolated, authored 9:16 achievement card without capturing gameplay.</summary>
    public sealed class LevelClearShareCard : MonoBehaviour
    {
        private const int c_Width = 1080;
        private const int c_Height = 1920;
        private const string c_CacheFolder = "chocology-share";
        private const string c_FilePrefix = "chocology-level-";
        private const string c_FilePattern = "chocology-level-*.png";
        private const double c_CacheLifetimeHours = 24d;

        [Serializable]
        private sealed class CardControls
        {
            [SerializeField] private Canvas m_Canvas;
            [SerializeField] private Camera m_Camera;
            [SerializeField] private Text m_LevelNumber;

            public Canvas Canvas => m_Canvas;
            public Camera Camera => m_Camera;
            public Text LevelNumber => m_LevelNumber;
        }

        [SerializeField] private CardControls m_Controls = new CardControls();
        private bool m_IsExporting;
        private string m_LastExportPath = string.Empty;

        public int Width => c_Width;
        public int Height => c_Height;
        public string LastExportPath => m_LastExportPath;

        /// <summary>Call on Unity's main thread, after an explicit Share tap.</summary>
        public void Export(int completedLevel, Action<string> onReady, Action<string> onError)
        {
            ExportInternal(completedLevel, onReady, onError);
        }

        private void ExportInternal(int completedLevel, Action<string> onReady, Action<string> onError)
        {
            if (completedLevel <= 0)
            {
                onError?.Invoke("Clear a level before creating a share image.");
                return;
            }
            if (m_IsExporting)
            {
                onError?.Invoke("Your share image is already being prepared.");
                return;
            }

            m_IsExporting = true;
            string resultPath = null;
            string failure = null;
            LevelClearShareCard instance = null;
            RenderTexture target = null;
            Texture2D image = null;
            RenderTexture previousTarget = RenderTexture.active;
            try
            {
                instance = Instantiate(this);
                instance.gameObject.name = "ChocologyShareCardExport";
                instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
                instance.gameObject.SetActive(true);
                if (instance.m_Controls.Canvas == null || instance.m_Controls.Camera == null || instance.m_Controls.LevelNumber == null)
                    throw new InvalidOperationException("The Chocology share card template is not configured.");

                var camera = instance.m_Controls.Camera;
                camera.enabled = false;
                instance.m_Controls.LevelNumber.text = completedLevel.ToString(CultureInfo.InvariantCulture);
                target = new RenderTexture(c_Width, c_Height, 24, RenderTextureFormat.ARGB32);
                target.Create();
                if (!target.IsCreated())
                    throw new InvalidOperationException("A share image render target could not be created.");
                camera.targetTexture = target;
                instance.m_Controls.Canvas.worldCamera = camera;
                instance.m_Controls.LevelNumber.SetAllDirty();
                LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)instance.m_Controls.Canvas.transform);
                Canvas.ForceUpdateCanvases();
                camera.Render();
                RenderTexture.active = target;
                image = new Texture2D(c_Width, c_Height, TextureFormat.RGBA32, false);
                image.ReadPixels(new Rect(0f, 0f, c_Width, c_Height), 0, 0, false);
                image.Apply(false, false);

                string directory = Path.Combine(Application.temporaryCachePath, c_CacheFolder);
                Directory.CreateDirectory(directory);
                RemoveExpiredCardsInternal(directory);
                string fileName = c_FilePrefix + completedLevel.ToString(CultureInfo.InvariantCulture) + "-" + Guid.NewGuid().ToString("N") + ".png";
                resultPath = Path.Combine(directory, fileName);
                File.WriteAllBytes(resultPath, image.EncodeToPNG());
                m_LastExportPath = resultPath;
            }
            catch (Exception exception)
            {
                resultPath = null;
                Debug.LogWarning("Chocology share-card export failed: " + exception, this);
                failure = "Could not prepare your Chocology share image. Please try again.";
            }
            finally
            {
                RenderTexture.active = previousTarget;
                if (instance != null)
                {
                    instance.gameObject.SetActive(false);
                    if (instance.m_Controls.Camera != null)
                        instance.m_Controls.Camera.targetTexture = null;
                    ReleaseInternal(instance.gameObject);
                }
                if (target != null)
                {
                    target.Release();
                    ReleaseInternal(target);
                }
                if (image != null)
                    ReleaseInternal(image);
                m_IsExporting = false;
            }

            // Invoke a single callback after cleanup; caller exceptions are not mistaken for export failures.
            if (failure == null)
                onReady?.Invoke(resultPath);
            else
                onError?.Invoke(failure);
        }

        private void RemoveExpiredCardsInternal(string directory)
        {
            DateTime cutoff = DateTime.UtcNow.AddHours(-c_CacheLifetimeHours);
            foreach (string file in Directory.GetFiles(directory, c_FilePattern, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    if (File.GetLastWriteTimeUtc(file) < cutoff)
                        File.Delete(file);
                }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
        }

        private void ReleaseInternal(UnityEngine.Object resource)
        {
            if (Application.isPlaying)
                Destroy(resource);
            else
                DestroyImmediate(resource);
        }
    }
}
