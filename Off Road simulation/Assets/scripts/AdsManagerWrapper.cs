using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UIElements;
//using GoogleMobileAds.Api.Mediation.AdColony;
//using GoogleMobileAds.Api.Mediation.IronSource;
//using GoogleMobileAds.Api.Mediation.AppLovin;

public class AdsManagerWrapper : MonoBehaviour
{
    public string AppID = "ca-app-pub-1639132491567326~9666821048";
    public static AdsManagerWrapper Instance;
    public Action RewardHandle;
    public string interStitialadUnitId;
    public string interStitialadUnitIdStatic;
    //public string interStitialadUnitIdCP;
    public string RewardedadUnitId;
    public string BanneradUnitId;
    //  public string BanneradUnitIdRect = "ca-app-pub-5634437249844186/5102001215";
    public string OpenAdUnityID;
    private InterstitialAd interstitialAd;
    private InterstitialAd CPinterstitial;
    private InterstitialAd GamePlayinterstitialAd;

    private RewardedAd rewardedAd;
    private BannerView bannerView;
    private BannerView RectbannerView;
    public bool IsIntersitialLoaded = false;
    public bool IsGpIntersitialLoaded = false;
    bool rewardgiven = false;
    public bool InitSucceded;
    public bool Test_ads;
    bool Consent;
    bool BannerisShowing = false;
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled=true;
#else
        Debug. unityLogger. logEnabled = false;
#endif
        if (Test_ads)
        {
            interStitialadUnitId="ca-app-pub-3940256099942544/1033173712";
            //interStitialadUnitIdCP="ca-app-pub-3940256099942544/1033173712";
            interStitialadUnitIdStatic="ca-app-pub-3940256099942544/1033173712";

            BanneradUnitId="ca-app-pub-3940256099942544/6300978111";

            OpenAdUnityID="ca-app-pub-3940256099942544/3419835294";

            interStitialadUnitIdStatic="ca-app-pub-3940256099942544/1033173712";
            //interStitialadUnitIdCP="ca-app-pub-3940256099942544/1033173712";
            interStitialadUnitId="ca-app-pub-3940256099942544/1033173712";
            RewardedadUnitId="ca-app-pub-3940256099942544/5224354917";
        }
        initialize(true);
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        if (Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(this.gameObject);
            PlayerPrefs.SetInt("app_open", 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private AdRequest CreateAdRequest ()
    {
        return new AdRequest.Builder ()
            .AddExtra ("npa", PlayerPrefs.GetString ("npa"))
            .Build ();
    }

    public void initialize( bool agree )
    {
        MobileAds.Initialize(initStatus => { OnInitSuccess(); });
        Consent=agree;

        //  UnityAds.SetGDPRConsentMetaData(Consent);
        //AdColonyAppOptions.SetGDPRRequired(Consent);
        //AdColonyAppOptions.SetGDPRConsentString(Consent == true ? "1" : "0");
        //AppLovin.SetHasUserConsent(Consent);
        //IronSource.SetConsent(Consent);
    }

    void OnInitSuccess()
    {
        InitSucceded=true;
        //LoadInterstitial();
        //LoadGPInterstitial ();
        //LoadCPInterstitial();
        RequestAndLoadInterstitialAd ();
        RequestAndLoadGpInterstitialAd ();
        LoadRewarded ();
        LoadOpenAd();
    }

    #region REWARDED ADS
    public bool isRewardAdLoadedAdmob { get; set; }
    void LoadRewarded ()
    {
        if ( !InitSucceded )
            return;

        this.rewardedAd = new RewardedAd (RewardedadUnitId);
        AdRequest request = new AdRequest.Builder().AddExtra("npa", Consent==true ? "1" : "0").Build();

        //abdullah
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += RewardedCompleted;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // it should be on bottom
        this.rewardedAd.LoadAd (request);
    }

    public void ShowRewardAdAdmob ()
    {
        if ( isRewardAdLoadedAdmob ) this.rewardedAd.Show ();
    }

    public void HandleRewardedAdLoaded ( object sender, EventArgs args )
    {
        isRewardAdLoadedAdmob = true;
    }

    public void HandleRewardedAdFailedToLoad ( object sender, AdFailedToLoadEventArgs args )
    {
        isRewardAdLoadedAdmob = false;
    }

    public void HandleRewardedAdOpening ( object sender, EventArgs args )
    {

    }

    public void HandleRewardedAdFailedToShow ( object sender, AdErrorEventArgs args )
    {

    }

    public void HandleRewardedAdClosed ( object sender, EventArgs args )
    {
        isRewardAdLoadedAdmob = false;
        LoadRewarded ();
    }

    //public bool IsRewardedVideoAvailable ()
    //{
    //    if ( !InitSucceded )
    //        return false;

    //    if ( this.rewardedAd.IsLoaded () )
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public void ShowRewardedVideo ( Action _Reward )
    {
        //  isRewarded = false;
        if ( !InitSucceded )
            return;

        if ( isRewardAdLoadedAdmob ) { this.rewardedAd.Show (); RewardHandle = _Reward; }
        //if ( IsRewardedVideoAvailable () )
        //{
        //    RewardHandle = _Reward;
        //    rewardedAd.OnUserEarnedReward += RewardedCompleted;
        //    this.rewardedAd.Show ();
        //}
        //LoadRewarded ();
    }

    private void RewardedCompleted ( object sender, Reward args )
    {
        if ( !InitSucceded )
            return;

        rewardgiven = true;
    }

    private void Update ()
    {
        if ( rewardgiven )
        {
            rewardgiven = false;
            if ( RewardHandle != null )
            {
                RewardHandle.Invoke ();
            }
        }
    }
    #endregion

    #region INTERSTITIAL ADS
    private void RequestIntersitialOnCloseEvent () { RequestAndLoadInterstitialAd (); }
    public void RequestAndLoadInterstitialAd ()
    {
        //string adUnitId = "ca-app-pub-9410075502784677/8481518226"; // real interstitial
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // testing interstitial
        // Clean up interstitial before using it
        if ( interstitialAd != null )
        {
            interstitialAd.Destroy ();
        }
        interstitialAd = new InterstitialAd (interStitialadUnitId);
        // Called when an ad request has successfully loaded.
        interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitialAd.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;
        // Load an interstitial ad
        interstitialAd.LoadAd (CreateAdRequest ());
    }

    public void HandleOnAdLoaded ( object sender, EventArgs args )
    {
        IsIntersitialLoaded = true;
    }

    public void HandleOnAdFailedToLoad ( object sender, AdFailedToLoadEventArgs args )
    {
        IsIntersitialLoaded = false;
    }

    public void HandleOnAdOpening ( object sender, EventArgs args )
    {

    }

    public void HandleOnInterstitialAdClosed ( object sender, EventArgs args )
    {
        RequestIntersitialOnCloseEvent ();
    }

    public void ShowInterstitial ()
    {
        if ( PlayerPrefs.GetInt ("RemoveAds") == 1 )
        {
            return;
        }

        if ( IsIntersitialLoaded )
        {
            interstitialAd.Show ();
        }
    }
    public void DestroyInterstitialAd ()
    {
        if ( interstitialAd != null )
        {
            interstitialAd.Destroy ();
        }
    }

    private void RequestGpIntersitialOnCloseEvent () { RequestAndLoadGpInterstitialAd (); }
    public void RequestAndLoadGpInterstitialAd ()
    {
        //string adUnitId = "ca-app-pub-9410075502784677/8481518226"; // real interstitial
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // testing interstitial
        // Clean up interstitial before using it
        if ( GamePlayinterstitialAd != null )
        {
            GamePlayinterstitialAd.Destroy ();
        }
        GamePlayinterstitialAd = new InterstitialAd (interStitialadUnitIdStatic);
        // Called when an ad request has successfully loaded.
        GamePlayinterstitialAd.OnAdLoaded += HandleOnGpAdLoaded;
        // Called when an ad request failed to load.
        GamePlayinterstitialAd.OnAdFailedToLoad += HandleOnGpAdFailedToLoad;
        // Called when an ad is shown.
        GamePlayinterstitialAd.OnAdOpening += HandleOnGpAdOpening;
        // Called when the ad is closed.
        GamePlayinterstitialAd.OnAdClosed += HandleOnGpInterstitialAdClosed;
        // Load an interstitial ad
        GamePlayinterstitialAd.LoadAd (CreateAdRequest ());
    }

    public void HandleOnGpAdLoaded ( object sender, EventArgs args )
    {
        IsGpIntersitialLoaded = true;
    }

    public void HandleOnGpAdFailedToLoad ( object sender, AdFailedToLoadEventArgs args )
    {
        IsGpIntersitialLoaded = false;
    }

    public void HandleOnGpAdOpening ( object sender, EventArgs args )
    {

    }

    public void HandleOnGpInterstitialAdClosed ( object sender, EventArgs args )
    {
        RequestGpIntersitialOnCloseEvent ();
    }

    public void ShowGpInterstitial ()
    {
        if ( PlayerPrefs.GetInt ("RemoveAds") == 1 )
        {
            return;
        }

        if ( IsGpIntersitialLoaded )
        {
            GamePlayinterstitialAd.Show ();
        }
    }
    public void DestroyGpInterstitialAd ()
    {
        if ( GamePlayinterstitialAd != null )
        {
            GamePlayinterstitialAd.Destroy ();
        }
    }

    //public void LoadInterstitial ()
    //{
    //    if ( !InitSucceded )
    //        return;

    //    this.interstitial = new InterstitialAd (interStitialadUnitId);
    //    // Create an empty ad request.
    //    AdRequest request = new AdRequest.Builder().AddExtra("npa", Consent==true ? "1" : "0").Build();
    //    // Load the interstitial with the request.
    //    this.interstitial.LoadAd (request);
    //    this.interstitial.OnAdClosed += HandleOnAdClosed;
    //}

    //public bool IsInterstitialAvailable ()
    //{
    //    if ( !InitSucceded )
    //        return false;

    //    if ( Application.isEditor )
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        if ( interstitial == null )
    //        {
    //            LoadInterstitial ();
    //            return false;
    //        }
    //        if ( this.interstitial.IsLoaded () )
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            LoadInterstitial ();
    //            return false;
    //        }
    //    }
    //}

    //public void ShowInterstitial ()
    //{
    //    if ( !InitSucceded )
    //        return;

    //    if ( PlayerPrefs.GetInt ("RemoveAds") != 1 )
    //    {
    //        if ( IsInterstitialAvailable () )
    //        {
    //            this.interstitial.Show ();
    //        }
    //    }
    //}

    //public void LoadCPInterstitial()
    //{
    //    if (!InitSucceded)
    //        return;
    //    this.CPinterstitial=new InterstitialAd(interStitialadUnitIdCP);
    //    // Create an empty ad request.
    //    AdRequest request = new AdRequest.Builder().AddExtra("npa", Consent==true ? "1" : "0").Build();
    //    // Load the interstitial with the request.
    //    this.CPinterstitial.LoadAd(request);
    //    this.CPinterstitial.OnAdClosed+=HandleOnCPAdClosed;
    //}
    //public bool IsCPInterstitialAvailable()
    //{
    //    if (!InitSucceded)
    //        return false;

    //    if (Application.isEditor) {
    //        return true;
    //    } else {
    //        if (CPinterstitial==null) {
    //            LoadCPInterstitial();
    //            return false;
    //        } if (this.CPinterstitial.IsLoaded()) {
    //            return true;
    //        } else {
    //            LoadCPInterstitial();
    //            return false;
    //        }
    //    }
    //}
    //public void ShowCpinterstitial()
    //{
    //    if (!InitSucceded)
    //        return;

    //    if (PlayerPrefs.GetInt("RemoveAds")!=1) {
    //        if (IsCPInterstitialAvailable()) {
    //            this.CPinterstitial.Show();
    //        }
    //    }
    //}

    //public void LoadGPInterstitial ()
    //{
    //    if ( !InitSucceded )
    //        return;

    //    this.GamePlayinterstitial = new InterstitialAd (interStitialadUnitIdStatic);
    //    // Create an empty ad request.
    //    AdRequest request = new AdRequest.Builder().AddExtra("npa", Consent==true ? "1" : "0").Build();
    //    // Load the interstitial with the request.
    //    this.GamePlayinterstitial.LoadAd (request);
    //    this.GamePlayinterstitial.OnAdClosed += HandleOnGPAdClosed;
    //}

    //public bool IsGamePlayInterstitialAvailable ()
    //{
    //    if ( !InitSucceded )
    //        return false;

    //    if ( Application.isEditor )
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        if ( GamePlayinterstitial == null )
    //        {
    //            LoadInterstitial ();
    //            return false;
    //        }
    //        if ( this.GamePlayinterstitial.IsLoaded () )
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            LoadInterstitial ();
    //            return false;
    //        }

    //    }
    //}

    //public void ShowGpinterstitial()
    //{
    //    if (!InitSucceded)
    //        return;

    //    if (PlayerPrefs.GetInt("RemoveAds")!=1)
    //    {
    //        if (IsGamePlayInterstitialAvailable())
    //        {
    //            this.GamePlayinterstitial.Show();
    //        }
    //    }
    //}
    #endregion

    #region Banner
    public void LoadBanner( AdPosition adPosition, AdSize _adSize )
    {
        if (!InitSucceded)
            return;

            this.bannerView=new BannerView(BanneradUnitId, _adSize, adPosition);

            AdRequest request = new AdRequest.Builder().AddExtra("npa", Consent==true ? "1" : "0").Build();
            this.bannerView.LoadAd(request);
            Debug.Log("<color=red>===================Medium Rectangele Banner Request==================</color>");
        
    }

    private void BannerFailed( object sender, EventArgs e )
    {
        BannerisShowing=false;
    }

    public void ShowBanner( AdPosition adPosition, AdSize _adsize )
    {
        if (!InitSucceded)
            return;


        if (PlayerPrefs.GetInt("RemoveAds", 0)==1)
            return;

        //DestroyBanner ();
        if (bannerView!=null)
        {
            bannerView.Show();
        }
        else
        {
            LoadBanner (adPosition, _adsize);
        }
    }

    public void HideBanner ()
    {

        if ( !InitSucceded )
            return;

        if ( bannerView != null )
        {
            bannerView.Hide ();
        }
    }

    public void DestroyBanner()
    {

        if (!InitSucceded)
            return;

        if (bannerView!=null)
        {
            bannerView.Destroy();
        }
    }
    #endregion

    public void HandleOnAdClosed ( object sender, EventArgs args )
    {
        //interstitial.Destroy ();
        //LoadInterstitial ();
    }
    //public void HandleOnCPAdClosed ( object sender, EventArgs args )
    //{
    //    CPinterstitial.Destroy ();
    //    LoadCPInterstitial ();
    //}
    public void HandleOnGPAdClosed ( object sender, EventArgs args )
    {
        //GamePlayinterstitial.Destroy ();
        //LoadGPInterstitial ();
    }

    #region Appopen
    private AppOpenAd ad;

    private bool IsOpenAdAvailable
    {
        get
        {
            return ad!=null;
        }
    }

    public void LoadOpenAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        // Load an app open ad for portrait orientation
        AppOpenAd.LoadAd(OpenAdUnityID, ScreenOrientation.LandscapeLeft, request, (( appOpenAd, error ) =>
   {
       if (error!=null)
       {
           // Handle the error.
           Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
           return;
       }

       // App open ad is loaded.
       ad=appOpenAd;
   }));
    }

    public void ShowAdIfAvailable()
    {
        if (!IsOpenAdAvailable)
        {
            return;
        }
        ad.OnAdDidDismissFullScreenContent+=HandleAdDidDismissFullScreenContent;
        ad.OnAdFailedToPresentFullScreenContent+=HandleAdFailedToPresentFullScreenContent;
        ad.OnAdDidPresentFullScreenContent+=HandleAdDidPresentFullScreenContent;
        ad.OnAdDidRecordImpression+=HandleAdDidRecordImpression;
        ad.OnPaidEvent+=HandlePaidEvent;
        ad.Show();
    }



    private void HandleAdDidDismissFullScreenContent( object sender, EventArgs args )
    {
        Debug.Log("Closed app open ad");
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        ad=null;
     //   isShowingAd=false;
      //  LoadOpenAd();
    }

    private void HandleAdFailedToPresentFullScreenContent( object sender, AdErrorEventArgs args )
    {
        Debug.LogFormat("Failed to present the ad (reason: {0})", args.AdError.GetMessage());
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        ad=null;
    }

    private void HandleAdDidPresentFullScreenContent( object sender, EventArgs args )
    {
        Debug.Log("Displayed app open ad");
      //  isShowingAd=true;
    }

    private void HandleAdDidRecordImpression( object sender, EventArgs args )
    {
        Debug.Log("Recorded ad impression");
    }

    private void HandlePaidEvent( object sender, AdValueEventArgs args )
    {
        Debug.LogFormat("Received paid event. (currency: {0}, value: {1}",
                args.AdValue.CurrencyCode, args.AdValue.Value);
    }
    #endregion

}
