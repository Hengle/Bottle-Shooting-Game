using AudienceNetwork;
using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdScriptEnter : MonoBehaviour
{
	private AudienceNetwork.InterstitialAd interstitialAd;

	private bool isLoaded;

	private static bool hasShownAdOneTime;

	private RewardBasedVideoAd rewardBasedVideo;

	public static bool rewardLoaded;

	public static GameObject UIComponents;

	private GoogleMobileAds.Api.InterstitialAd interstitial;

	private void Start()
	{
		hasShownAdOneTime = false;
		if (!Application.isEditor)
		{
			try
			{
				RequestInterstitialAds();
			}
			catch (Exception)
			{
			}
		}
		if (!hasShownAdOneTime)
		{
			try
			{
				Invoke("showInterstitialAd", 6f);
			}
			catch (Exception)
			{
			}
		}
	}

	private void Update()
	{
	}

	public void showInterstitialAd()
	{
		hasShownAdOneTime = true;
		if (interstitial != null && interstitial.IsLoaded())
		{
			interstitial.Show();
		}
	}

	private void RequestInterstitialAds()
	{
		string text = "ca-app-pub-3411062052281263/9258044518";
		string adUnitId = text;
		interstitial = new GoogleMobileAds.Api.InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.OnAdClosed += Interstitial_OnAdClosed;
		interstitial.LoadAd(request);
		UnityEngine.Debug.Log("AD LOADED XXX");
	}

	private void Interstitial_OnAdClosed(object sender, EventArgs e)
	{
	}
}
