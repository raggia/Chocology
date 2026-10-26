/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */

//using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
//using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
//using GoogleMobileAds.Api;
using BsplabsMobileAds;

public class AdmobManager : MonoBehaviour
{
    public static AdmobManager instance;
    



    public enum ADS_CALLBACK_STATE
    {
        SUCCESS,
        FAIL
    }

   

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        BspLabsAdsMobile.Instance.Initialize();
    }
}
