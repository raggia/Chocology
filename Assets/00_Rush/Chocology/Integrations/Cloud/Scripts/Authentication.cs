using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;
using CloudOnce;
using GoogleMobileAds.Api;

namespace Rush.Chocology.Integrations.Cloud
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "Authentication")]
    public class Authentication : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 1000;
            QualitySettings.vSyncCount = 0;
            global::CloudOnce.Cloud.OnInitializeComplete += OnCloudeInitComplete;
            global::CloudOnce.Cloud.Initialize(false, true, false);
        }

        void OnCloudeInitComplete()
        {
            global::CloudOnce.Cloud.OnInitializeComplete -= OnCloudeInitComplete;
            Debug.Log("Initialized");
            Debug.Log("Signin as : " + global::CloudOnce.Cloud.PlayerDisplayName);
        }

        private void CloudOnCloudSaveComplete(bool arg0)
        {
        }

        private void CloudOnCloudLoadComplete(bool arg0)
        {
        }
    }
}
