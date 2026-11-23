using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UnityEditor.Android;

namespace Rush.Integrations.Editor
{
    // The legacy Google Ads plugin uses one namespace for its runtime AAR and
    // configuration-only androidlib. Current AGP requires these to be distinct.
    public sealed class GoogleAdsNamespaceBuildProcessor : IPostGenerateGradleAndroidProject
    {
        private const string c_ConfigurationNamespace = "com.chocology.googlemobileads.configuration";
        public int callbackOrder => 10000;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            string library = Path.Combine(path, "GoogleMobileAdsPlugin.androidlib");
            string gradlePath = Path.Combine(library, "build.gradle");
            string manifestPath = Path.Combine(library, "AndroidManifest.xml");
            if (!File.Exists(gradlePath) || !File.Exists(manifestPath)) return;

            string gradle = File.ReadAllText(gradlePath);
            gradle = Regex.Replace(gradle, @"namespace\s+""[^""]+""",
                "namespace \"" + c_ConfigurationNamespace + "\"");
            File.WriteAllText(gradlePath, gradle);

            XDocument manifest = XDocument.Load(manifestPath);
            manifest.Root?.Attribute("package")?.Remove();
            manifest.Save(manifestPath);
        }
    }
}
