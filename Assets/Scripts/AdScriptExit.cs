using AudienceNetwork;
using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdScriptExit : MonoBehaviour
{
	private AudienceNetwork.InterstitialAd interstitialAd;

	private bool isLoaded;

	private bool hasShownAdOneTime;

	private RewardBasedVideoAd rewardBasedVideo;

	public static bool rewardLoaded;

	public static GameObject UIComponents;

	public static GoogleMobileAds.Api.InterstitialAd interstitial;

	private void Start()
	{
		rewardLoaded = false;
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
	}

	private void Update()
	{
		if (MainMenuController.isExitClicked)
		{
			MainMenuController.isExitClicked = false;
			hasShownAdOneTime = true;
			try
			{
				showInterstitialAd();
			}
			catch (Exception)
			{
			}
		}
	}

	public void showInterstitialAd()
	{
		if (isLoaded)
		{
			interstitialAd.Show();
			UnityEngine.Debug.Log("SHOW AD XXX");
		}
		else if (interstitial != null && interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			MainMenuController.UIComponents2.SetActive(value: false);
			MainMenuController.ExitPanel2.SetActive(value: true);
		}
	}

	private void RequestInterstitialAds()
	{
		string text = "ca-app-pub-3411062052281263/4112253294";
		string adUnitId = text;
		interstitial = new GoogleMobileAds.Api.InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.OnAdClosed += Interstitial_OnAdClosed;
		interstitial.LoadAd(request);
		UnityEngine.Debug.Log("AD LOADED XXX");
	}

	private void Interstitial_OnAdClosed(object sender, EventArgs e)
	{
		MainMenuController.UIComponents2.SetActive(value: false);
		MainMenuController.ExitPanel2.SetActive(value: true);
	}

	public void LoadInterstitial()
	{
		AudienceNetwork.InterstitialAd interstitialAd = this.interstitialAd = new AudienceNetwork.InterstitialAd("177562949545239_177563016211899");
		this.interstitialAd.Register(base.gameObject);
		this.interstitialAd.InterstitialAdDidLoad = delegate
		{
			UnityEngine.Debug.Log("Interstitial ad loaded.");
			isLoaded = true;
		};
		interstitialAd.InterstitialAdDidFailWithError = delegate(string error)
		{
			UnityEngine.Debug.Log("Interstitial ad failed to load with error: " + error);
			RequestInterstitialAds();
		};
		interstitialAd.InterstitialAdWillLogImpression = delegate
		{
			UnityEngine.Debug.Log("Interstitial ad logged impression.");
		};
		interstitialAd.InterstitialAdDidClick = delegate
		{
			UnityEngine.Debug.Log("Interstitial ad clicked.");
		};
		interstitialAd.interstitialAdDidClose = delegate
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
		};
		this.interstitialAd.LoadAd();
	}

	public void ShowInterstitial()
	{
		if (isLoaded)
		{
			interstitialAd.Show();
			isLoaded = false;
		}
	}
}
