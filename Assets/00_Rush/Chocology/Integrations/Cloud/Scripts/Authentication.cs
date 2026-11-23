using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;
using CloudOnce;

namespace Rush.Chocology.Integrations.Cloud
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "Authentication")]
    public class Authentication : MonoBehaviour
    {
        private const int c_TargetFrameRate = 60;

        private void Start()
        {
            Application.targetFrameRate = c_TargetFrameRate;
            QualitySettings.vSyncCount = 0;
            global::CloudOnce.Cloud.OnInitializeComplete += OnCloudeInitComplete;
            global::CloudOnce.Cloud.Initialize(false, true, false);
        }

        void OnCloudeInitComplete()
        {
            global::CloudOnce.Cloud.OnInitializeComplete -= OnCloudeInitComplete;
            Debug.Log("Initialized");

        }

        private void OnDestroy()
        {
            global::CloudOnce.Cloud.OnInitializeComplete -= OnCloudeInitComplete;
        }

        private void CloudOnCloudSaveComplete(bool arg0)
        {
        }

        private void CloudOnCloudLoadComplete(bool arg0)
        {
        }
    }
}
