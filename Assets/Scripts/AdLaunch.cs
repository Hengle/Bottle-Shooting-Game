using AudienceNetwork;
using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdLaunch : MonoBehaviour
{
	private AudienceNetwork.InterstitialAd interstitialAd;

	private bool isLoaded;

	public static bool hasShownAdOneTime;

	private RewardBasedVideoAd rewardBasedVideo;

	public static bool rewardLoaded;

	public static GameObject UIComponents;

	public static GoogleMobileAds.Api.InterstitialAd interstitial;

	private void Constructed()
	{
	}

	private void Awake()
	{
		if (SceneManager.GetActiveScene().name.Equals("SplashScreen"))
		{
			try
			{
				RequestInterstitialAds();
			}
			catch (Exception)
			{
			}
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (Global.isFirstTime && SceneManager.GetActiveScene().name.Equals("MainMenu"))
		{
			Global.isFirstTime = false;
			try
			{
				showInterstitialAd();
				Global.isLaunchAdDisplayed = true;
			}
			catch (Exception)
			{
			}
		}
	}

	public void showInterstitialAd()
	{
		if (interstitial != null && interstitial.IsLoaded())
		{
			interstitial.Show();
		}
	}

	private void RequestInterstitialAds()
	{
		string text = "ca-app-pub-3411062052281263/8595134225";
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
