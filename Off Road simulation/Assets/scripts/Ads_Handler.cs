using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;

public enum AdType
{
    Banner = 0,
    medium_react=2,
    removeads = 1,
    smartbanner=3,
    interstital=4
}
public class Ads_Handler : MonoBehaviour
{
    //public AdPosition Enable_adposition;
    //public AdType adType;
    //public AdPosition disable_adposition;
    //public AdType Disableadtype;
    //public bool Interstial;
 
    void OnEnable ()
    {
        AdsManagerWrapper.Instance.ShowBanner (AdPosition.Top, AdSize.SmartBanner);
        //if (Interstial)
        //{
        //    AdsManagerWrapper.Instance.ShowInterstitial();
        //}
        //if ( adType == AdType.Banner )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (Enable_adposition, AdSize.Banner);
        //}
        //else if ( adType == AdType.removeads )
        //{
        //    AdsManagerWrapper.Instance.HideBanner ();
        //}
        //else if ( adType == AdType.smartbanner )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (Enable_adposition, AdSize.SmartBanner);
        //}
        //else if ( adType == AdType.medium_react )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (Enable_adposition, AdSize.MediumRectangle);
        //}
        //else if ( adType == AdType. interstital )
        //{
        //    AdsManagerWrapper. Instance. ShowInterstitial();
        //}
    }

    void OnDisable ()
    {
        AdsManagerWrapper.Instance.HideBanner ();
        //if ( Disableadtype == AdType.Banner )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (disable_adposition, AdSize.Banner);
        //}
        //else if ( Disableadtype == AdType.removeads )
        //{
        //    AdsManagerWrapper.Instance.HideBanner ();
        //}
        //else if ( Disableadtype == AdType.smartbanner )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (disable_adposition, AdSize.SmartBanner);
        //}
        //else if ( Disableadtype == AdType.medium_react )
        //{
        //    AdsManagerWrapper.Instance.ShowBanner (disable_adposition, AdSize.MediumRectangle);
        //}
    }
}
