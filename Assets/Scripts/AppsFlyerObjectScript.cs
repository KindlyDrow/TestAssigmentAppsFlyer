using AppsFlyerSDK;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppsFlyerObjectScript : MonoBehaviour, IAppsFlyerConversionData
{
    // These fields are set from the editor so do not modify!
    //******************************//
    public string devKey;
    public string appID;
    public string UWPAppID;
    public string macOSAppID;
    public bool isDebug;
    public bool getConversionData;
    //******************************//

    [SerializeField] private TextMeshProUGUI m_text;

    void Start()
    {
        // These fields are set from the editor so do not modify!
        //******************************//
        AppsFlyer.setIsDebug(isDebug);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
    AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#else
        AppsFlyer.initSDK(devKey, appID, getConversionData ? this : null);
#endif
        //******************************/

        AppsFlyer.startSDK();
    }

    private void Update()
    {
    }

    public void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        // add deferred deeplink logic here
        m_text.text = conversionData;
        m_text.text += conversionDataDictionary.ToString();
    }

    public void onConversionDataFail(string error)
    {
        m_text.text = error;
        AppsFlyer.AFLog("onConversionDataFail", error);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        m_text.text = attributionData;
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        m_text.text = error;
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }
}
