using IronSourceJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AndroidAgent : IronSourceIAgent
{
	//private static AndroidJavaObject _androidBridge;

	private static readonly string AndroidBridge = "com.ironsource.unity.androidbridge.AndroidBridge";

	private const string REWARD_AMOUNT = "reward_amount";

	private const string REWARD_NAME = "reward_name";

	private const string PLACEMENT_NAME = "placement_name";

	public AndroidAgent()
	{
		UnityEngine.Debug.Log("AndroidAgent ctr");
	}

	//private AndroidJavaObject getBridge()
	//{
        //if (_androidBridge == null)
        //{
        //	using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(AndroidBridge))
        //	{
        //		_androidBridge = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
        //	}
        //}
        //return _androidBridge;
	//}

	public void onApplicationPause(bool pause)
	{
		//if (pause)
		//{
		//	getBridge().Call("onPause");
		//}
		//else
		//{
		//	getBridge().Call("onResume");
		//}
	}

	public void setAge(int age)
	{
		//getBridge().Call("setAge", age);
	}

	public void setGender(string gender)
	{
		//getBridge().Call("setGender", gender);
	}

	public void setMediationSegment(string segment)
	{
		//getBridge().Call("setMediationSegment", segment);
	}

	public string getAdvertiserId()
	{
        //return getBridge().Call<string>("getAdvertiserId", new object[0]);
        return string.Empty;
	}

	public void validateIntegration()
	{
		//getBridge().Call("validateIntegration");
	}

	public void shouldTrackNetworkState(bool track)
	{
		//getBridge().Call("shouldTrackNetworkState", track);
	}

	public bool setDynamicUserId(string dynamicUserId)
	{
        //return getBridge().Call<bool>("setDynamicUserId", new object[1]
        //{
        //	dynamicUserId
        //});
        return false;
	}

	public void setAdaptersDebug(bool enabled)
	{
		//getBridge().Call("setAdaptersDebug", enabled);
	}

	public void setUserId(string userId)
	{
		//getBridge().Call("setUserId", userId);
	}

	public void init(string appKey)
	{
		//getBridge().Call("setPluginData", "Unity", IronSource.pluginVersion(), IronSource.unityVersion());
		//getBridge().Call("init", appKey);
	}

	public void init(string appKey, params string[] adUnits)
	{
	}

	public void initISDemandOnly(string appKey, params string[] adUnits)
	{
	}

	public void showRewardedVideo()
	{
	}

	public void showRewardedVideo(string placementName)
	{
	}

	public bool isRewardedVideoAvailable()
	{
        return false;
	}

	public bool isRewardedVideoPlacementCapped(string placementName)
	{
        return false;
	}

	public IronSourcePlacement getPlacementInfo(string placementName)
	{
        return null;
	}

	public void setRewardedVideoServerParams(Dictionary<string, string> parameters)
	{
		string text = Json.Serialize(parameters);
		//getBridge().Call("setRewardedVideoServerParams", text);
	}

	public void clearRewardedVideoServerParams()
	{
		//getBridge().Call("clearRewardedVideoServerParams");
	}

	public void showISDemandOnlyRewardedVideo(string instanceId)
	{
		//getBridge().Call("showISDemandOnlyRewardedVideo", instanceId);
	}

	public void showISDemandOnlyRewardedVideo(string instanceId, string placementName)
	{
		//getBridge().Call("showISDemandOnlyRewardedVideo", instanceId, placementName);
	}

	public bool isISDemandOnlyRewardedVideoAvailable(string instanceId)
	{
        return false;
	}

	public void loadInterstitial()
	{
		//getBridge().Call("loadInterstitial");
	}

	public void showInterstitial()
	{
		//getBridge().Call("showInterstitial");
	}

	public void showInterstitial(string placementName)
	{
		//getBridge().Call("showInterstitial", placementName);
	}

	public bool isInterstitialReady()
	{
        return false;
	}

	public bool isInterstitialPlacementCapped(string placementName)
	{
        return false;
	}

	public void loadISDemandOnlyInterstitial(string instanceId)
	{
		//getBridge().Call("loadISDemandOnlyInterstitial", instanceId);
	}

	public void showISDemandOnlyInterstitial(string instanceId)
	{
		//getBridge().Call("showISDemandOnlyInterstitial", instanceId);
	}

	public void showISDemandOnlyInterstitial(string instanceId, string placementName)
	{
		//getBridge().Call("showISDemandOnlyInterstitial", instanceId, placementName);
	}

	public bool isISDemandOnlyInterstitialReady(string instanceId)
	{
        return false;
	}

	public void showOfferwall()
	{
		//getBridge().Call("showOfferwall");
	}

	public void showOfferwall(string placementName)
	{
		//getBridge().Call("showOfferwall", placementName);
	}

	public void getOfferwallCredits()
	{
		//getBridge().Call("getOfferwallCredits");
	}

	public bool isOfferwallAvailable()
	{
        return false;
	}

	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position)
	{
		loadBanner(size, position, string.Empty);
	}

	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName)
	{
		//getBridge().Call("loadBanner", size.Description, size.Width, size.Height, (int)position, placementName);
	}

	public void destroyBanner()
	{
		//getBridge().Call("destroyBanner");
	}

	public void displayBanner()
	{
		//getBridge().Call("displayBanner");
	}

	public void hideBanner()
	{
		//getBridge().Call("hideBanner");
	}

	public bool isBannerPlacementCapped(string placementName)
	{
        return false;
	}

	public void setSegment(IronSourceSegment segment)
	{
	}

	public void setConsent(bool consent)
	{
	}
}
