using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Rush.Editor
{
    // Keep the Play Console remediation settings from regressing in another build profile.
    public sealed class ChocologyAndroidReleaseGuard : IPreprocessBuildWithReport
    {
        private const int c_MinTargetApi = 36;
        private const int c_MinVersionCode = 27;
        private const string c_PackageName = "com.gameson.chocology";
        private const string c_PlayGamesAppId = "584099846573";
        private const string c_IconBackgroundPath = "Assets/Chocology Assets/AndroidLauncher/ChocologyBackground.png";
        private const string c_IconForegroundPath = "Assets/Chocology Assets/AndroidLauncher/ChocologyForeground.png";
        private const string c_UploadKeyAlias = "saya game";
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android)
                return;
            ValidateAndroidReleaseInternal();
        }

        // This preflight can also be run from the Editor without starting a player build.
        public void ValidateAndroidRelease()
        {
            ValidateAndroidReleaseInternal();
        }

        private void ValidateAndroidReleaseInternal()
        {
            if (PlayerSettings.GetApplicationIdentifier(UnityEditor.Build.NamedBuildTarget.Android) != c_PackageName)
                throw new BuildFailedException("Chocology must keep its published Android package identifier.");
            if ((int)PlayerSettings.Android.targetSdkVersion < c_MinTargetApi)
                throw new BuildFailedException("Set an explicit Android target API of 36 or higher in the active build profile.");
            if (PlayerSettings.GetScriptingBackend(UnityEditor.Build.NamedBuildTarget.Android) != ScriptingImplementation.IL2CPP || (PlayerSettings.Android.targetArchitectures & AndroidArchitecture.ARM64) == 0)
                throw new BuildFailedException("Chocology Android requires IL2CPP and ARM64.");
            if ((int)Unity.Notifications.NotificationSettings.AndroidSettings.ExactSchedulingOption != 0)
                throw new BuildFailedException("Chocology reward reminders must use inexact notification scheduling.");
            if (GooglePlayGames.PlayGamesSettings.LoadInstance()?.AppId != c_PlayGamesAppId)
                throw new BuildFailedException("Restore the Chocology Play Games App ID from CloudOnce before building.");
            string numericVersion = Application.unityVersion.Split('f', 'b', 'a', 'p')[0];
            if (!Version.TryParse(numericVersion, out var version) || version < new Version(6000, 6, 5))
                throw new BuildFailedException("Use the project's Unity 6000.6.5f1 or a newer compatible patched editor, then recheck native 16 KB alignment.");
            ValidateAndroidIconsInternal();
            if (!EditorUserBuildSettings.exportAsGoogleAndroidProject && !EditorUserBuildSettings.development)
            {
                if (PlayerSettings.Android.bundleVersionCode < c_MinVersionCode)
                    throw new BuildFailedException("Chocology version codes through 26 have already been uploaded. Use version code 27 or higher for this release.");
                if (!EditorUserBuildSettings.buildAppBundle)
                    throw new BuildFailedException("Use an Android App Bundle for the Chocology Play release.");
                if (!PlayerSettings.Android.useCustomKeystore || string.IsNullOrEmpty(PlayerSettings.Android.keystorePass) || string.IsNullOrEmpty(PlayerSettings.Android.keyaliasPass))
                    throw new BuildFailedException("Enter the passwords for the registered Chocology upload key in Publishing Settings. Do not use debug signing for a Play release.");
                if (PlayerSettings.Android.keyaliasName != c_UploadKeyAlias)
                    throw new BuildFailedException("Select the registered Chocology upload key alias: saya game.");
            }
        }

        private void ValidateAndroidIconsInternal()
        {
#if UNITY_ANDROID
            var icons = PlayerSettings.GetPlatformIcons(UnityEditor.Build.NamedBuildTarget.Android, UnityEditor.Android.AndroidPlatformIconKind.Adaptive);
            if (icons.Length == 0)
                throw new BuildFailedException("Configure Chocology Adaptive Android icons before building.");
            foreach (var icon in icons)
            {
                var layers = icon.GetTextures();
                if (layers.Length < 2 || layers[0] == null || layers[1] == null ||
                    AssetDatabase.GetAssetPath(layers[0]) != c_IconBackgroundPath ||
                    AssetDatabase.GetAssetPath(layers[1]) != c_IconForegroundPath)
                    throw new BuildFailedException("Assign the Chocology Adaptive Background and Foreground to every Android icon size. Empty slots can produce Unity's default launcher icon.");
            }
#endif
        }
    }
}
