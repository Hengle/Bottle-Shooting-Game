using AudienceNetwork;
using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Monetization;

public class AdScript : MonoBehaviour
{
	private AudienceNetwork.InterstitialAd interstitialAd;

	private bool isLoaded;

	private bool hasShownAdOneTime;

	private bool hasShownReplayAd;

	public static RewardBasedVideoAd rewardBasedVideo;

	public static bool rewardLoaded;

	public static bool isAdloaded;

	public static bool hideSkipRewardBtn;

	public static bool continueReward;

	private static GameManager gm;

	public static string stroreId = "2840030";

	public static string video_ad = "knockdown_fullscreen";

	public static string rewarded_Video = "rewardedVideo";

	public string bannerPlacement = "knockdown_banner";

	private float currentAdDisplayTime;

	public static BannerView bannerAd1;

	public static BannerView bannerAd2;

	public static AdView adView;

	public AudienceNetwork.AdPosition currentAdViewPosition;

	private static GoogleMobileAds.Api.InterstitialAd interstitial;

	private static GoogleMobileAds.Api.InterstitialAd interstitial2;

	[CompilerGenerated]
	private static Action _003C_003Ef__mg_0024cache0;

	[CompilerGenerated]
	private static EventHandler<EventArgs> _003C_003Ef__mg_0024cache1;

	[CompilerGenerated]
	private static EventHandler<AdFailedToLoadEventArgs> _003C_003Ef__mg_0024cache2;

	[CompilerGenerated]
	private static EventHandler<EventArgs> _003C_003Ef__mg_0024cache3;

	[CompilerGenerated]
	private static ShowAdFinishCallback _003C_003Ef__mg_0024cache4;

	[CompilerGenerated]
	private static ShowAdFinishCallback _003C_003Ef__mg_0024cache5;

	[CompilerGenerated]
	private static ShowAdFinishCallback _003C_003Ef__mg_0024cache6;

	private void Start()
	{
		UnityEngine.Debug.Log("No of retrys=  " + Global.noOfTries);
		try
		{
			Monetization.Initialize(stroreId, testMode: false);
			Invoke("UnityAdIsReady", 5f);
			IronSourceEvents.onInterstitialAdClosedEvent += OnIronInterstitialAdClosed;
			IronSource.Agent.loadInterstitial();
		}
		catch (Exception)
		{
		}
		rewardLoaded = false;
		gm = UnityEngine.Object.FindObjectOfType<GameManager>();
		try
		{
			if (Global.currentLevel >= Global.bannerLevel)
			{
				showBannerAd();
			}
		}
		catch (Exception)
		{
		}
		hasShownAdOneTime = false;
		hasShownReplayAd = false;
		string appId = "ca-app-pub-3411062052281263/5993459298";
		try
		{
			MobileAds.Initialize(appId);
		}
		catch (Exception)
		{
		}
		if (!Application.isEditor)
		{
			LoadInterstitial();
		}
		try
		{
			if (rewardBasedVideo == null || !rewardBasedVideo.IsLoaded())
			{
				rewardBasedVideo = RewardBasedVideoAd.Instance;
				rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
				rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
				rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
				rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
				rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
				rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
				rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
				RequestRewardBasedVideo();
			}
		}
		catch (Exception)
		{
		}
	}

	public void UnityAdIsReady()
	{
		Monetization.IsReady(video_ad);
		Monetization.IsReady(rewarded_Video);
	}

	private void RewardedTest()
	{
		rewardLoaded = true;
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		if (continueReward)
		{
			PopUpManager.continueVideoPup.SetActive(value: false);
			Global.isContinuePopActive = false;
			if (Global.currentLevel == 12)
			{
				SceneLoader.LoadAScene("LEVEL113");
			}
			else if (Global.currentLevel == 24)
			{
				SceneLoader.LoadAScene("LEVEL213");
			}
			else if (Global.currentLevel == 150)
			{
				SceneLoader.LoadAScene("LEVEL13");
			}
			else if (Global.currentLevel == 224)
			{
				SceneLoader.LoadAScene("LEVEL25");
			}
			else
			{
				SceneLoader.LoadAScene("LEVEL" + (Global.currentLevel + 1));
			}
		}
		else if (GameManager.gameState != GameState.RewardedBall)
		{
			GameManager.gameState = GameState.Rewared_Video_InCompleted;
		}
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		if (continueReward)
		{
			PopUpManager.continueVideoPup.SetActive(value: false);
			Global.isContinuePopActive = false;
			if (Global.currentLevel == 12)
			{
				SceneLoader.LoadAScene("LEVEL113");
			}
			else if (Global.currentLevel == 24)
			{
				SceneLoader.LoadAScene("LEVEL213");
			}
			else if (Global.currentLevel == 150)
			{
				SceneLoader.LoadAScene("LEVEL13");
			}
			else if (Global.currentLevel == 224)
			{
				SceneLoader.LoadAScene("LEVEL25");
			}
			else
			{
				SceneLoader.LoadAScene("LEVEL" + (Global.currentLevel + 1));
			}
		}
		else
		{
			GameManager.gameState = GameState.RewardedBall;
		}
		string type = args.Type;
		MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + args.Amount.ToString() + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}

	private void RequestRewardBasedVideo()
	{
		string adUnitId = "ca-app-pub-3411062052281263/5993459298";
		AdRequest request = new AdRequest.Builder().Build();
		rewardBasedVideo.LoadAd(request, adUnitId);
	}

	public static bool IsUnityRewardReady()
	{
		return Monetization.IsReady(rewarded_Video);
	}

	private void Update()
	{
		try
		{
			if (rewardBasedVideo.IsLoaded())
			{
				rewardLoaded = true;
			}
			if (!Global.isSkipActive && (rewardLoaded || Monetization.IsReady(rewarded_Video)) && Global.noOfTries >= Global.retryCount && Global.currentLevel >= 1)
			{
				Global.isSkipActive = true;
			}
			if (GameScript.isGameOver)
			{
				if (Global.isEditor)
				{
					gm.retry.SetActive(value: true);
					gm.menu.SetActive(value: true);
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
				if (!hasShownAdOneTime)
				{
					hasShownAdOneTime = true;
					if (Global.currentLevel > 300)
					{
						Invoke("showInterstitialAd", 0.4f);
					}
					else
					{
						if (Global.currentLevel == 1)
						{
							if (Global.isLaunchAdDisplayed)
							{
								Global.AdInterval += Global.const1;
							}
							else
							{
								Global.AdInterval = 0f;
							}
						}
						if (Global.currentLevel > 1 && Global.currentLevel <= 4)
						{
							Global.AdInterval = Global.AdGap1;
						}
						if (Global.currentLevel > 4 && Global.currentLevel <= 12)
						{
							Global.AdInterval = Global.AdGap2;
						}
						if (Global.currentLevel >= 113 && Global.currentLevel <= 151)
						{
							Global.AdInterval = Global.AdGap3;
						}
						if ((Global.currentLevel >= 13 && Global.currentLevel <= 36) || (Global.currentLevel >= 213 && Global.currentLevel <= 225))
						{
							Global.AdInterval = Global.AdGap4;
						}
						currentAdDisplayTime = Time.time;
						float num = currentAdDisplayTime - Global.lastAdDisplayTime;
						if (num > Global.AdInterval)
						{
							Invoke("showInterstitialAd", 0.4f);
						}
						else
						{
							gm.retry.SetActive(value: true);
							gm.menu.SetActive(value: true);
							gm.failMenu.SetActive(value: true);
							gm.failRetry.SetActive(value: true);
						}
					}
				}
			}
			if (GameScript.isReplay)
			{
				if (Global.isEditor)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
				}
				if (!hasShownReplayAd)
				{
					hasShownReplayAd = true;
					if (Global.currentLevel > 300)
					{
						Invoke("showGoogleInterstetial", 0.4f);
					}
					else
					{
						if (Global.currentLevel == 1)
						{
							if (Global.isLaunchAdDisplayed)
							{
								Global.AdInterval += Global.const1;
							}
							else
							{
								Global.AdInterval = 0f;
							}
						}
						if (Global.currentLevel > 1 && Global.currentLevel <= 4)
						{
							Global.AdInterval = Global.AdGap1;
						}
						if (Global.currentLevel > 4 && Global.currentLevel <= 12)
						{
							Global.AdInterval = Global.AdGap2;
						}
						if (Global.currentLevel >= 113 && Global.currentLevel <= 151)
						{
							Global.AdInterval = Global.AdGap3;
						}
						if ((Global.currentLevel >= 13 && Global.currentLevel <= 36) || (Global.currentLevel >= 213 && Global.currentLevel <= 225))
						{
							Global.AdInterval = Global.AdGap4;
						}
						currentAdDisplayTime = Time.time;
						float num2 = currentAdDisplayTime - Global.lastAdDisplayTime;
						if (num2 > Global.AdInterval)
						{
							Invoke("showGoogleInterstetial", 0.4f);
						}
						else
						{
							UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void showBannerAd()
	{
		string adUnitId = "ca-app-pub-3411062052281263/1957914584";
		AdRequest request = new AdRequest.Builder().AddTestDevice("0DF60A0D7FDE36526E3178F0D8E71DDB").Build();
		if (bannerAd1 == null)
		{
			bannerAd1 = new BannerView(adUnitId, GoogleMobileAds.Api.AdSize.Banner, GoogleMobileAds.Api.AdPosition.BottomLeft);
			bannerAd1.LoadAd(request);
			bannerAd1.OnAdFailedToLoad += Banner_OnFailToLoad;
			bannerAd1.Show();
		}
	}

	private static void OnIronInterstitialAdClosed()
	{
		try
		{
			if (GameScript.isGameOver)
			{
				gm.retry.SetActive(value: true);
				gm.menu.SetActive(value: true);
				gm.failMenu.SetActive(value: true);
				gm.failRetry.SetActive(value: true);
			}
			if (GameScript.isReplay)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
			}
		}
		catch (Exception)
		{
		}
	}

	private void Banner_OnFailToLoad(object sender, EventArgs e)
	{
	}

	public void showInterstitialAd()
	{
		try
		{
			currentAdDisplayTime = Time.time;
			float num = currentAdDisplayTime - Global.lastAdDisplayTime;
			if (interstitial != null && interstitial.IsLoaded())
			{
				interstitial.Show();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (isLoaded)
			{
				interstitialAd.Show();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (num > Global.backFillAdGap && Monetization.IsReady(video_ad))
			{
				ShowAdPlacementContent showAdPlacementContent = null;
				(Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent)?.Show(HandleShowResult);
			}
			else if (num > Global.backFillAdGap && IronSource.Agent.isInterstitialReady())
			{
				ShowIronAd();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (num > Global.backFillAdGap && interstitial2 != null && interstitial2.IsLoaded())
			{
				interstitial2.Show();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (Monetization.IsReady(rewarded_Video) || rewardLoaded)
			{
				Global.isRewardVidAvail = true;
				gm.retry.SetActive(value: true);
				gm.menu.SetActive(value: true);
				if (gm.gameFailed.activeSelf)
				{
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
			}
			else
			{
				gm.retry.SetActive(value: true);
				gm.menu.SetActive(value: true);
				if (gm.gameFailed.activeSelf)
				{
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void showGoogleInterstetial()
	{
		try
		{
			currentAdDisplayTime = Time.time;
			float num = currentAdDisplayTime - Global.lastAdDisplayTime;
			if (interstitial != null && interstitial.IsLoaded())
			{
				interstitial.Show();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (isLoaded)
			{
				interstitialAd.Show();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (num > Global.backFillAdGap && Monetization.IsReady(video_ad))
			{
				ShowAdPlacementContent showAdPlacementContent = null;
				(Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent)?.Show(HandleShowResult);
			}
			else if (num > Global.backFillAdGap && IronSource.Agent.isInterstitialReady())
			{
				ShowIronAd();
				Global.lastAdDisplayTime = currentAdDisplayTime;
			}
			else if (num > Global.backFillAdGap && interstitial2 != null && interstitial2.IsLoaded())
			{
				if (num > 60f)
				{
					interstitial2.Show();
					Global.lastAdDisplayTime = currentAdDisplayTime;
				}
				else
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
				}
			}
			else
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
			}
		}
		catch (Exception)
		{
		}
	}

	public void ShowIronAd()
	{
		UnityEngine.Debug.Log("unity-script: ShowInterstitialButtonClicked");
		if (IronSource.Agent.isInterstitialReady())
		{
			IronSource.Agent.showInterstitial("DefaultInterstitial");
			Global.lastAdDisplayTime = Time.time;
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
		}
	}

	private static void RequestInterstitialAds()
	{
		try
		{
			string text = "ca-app-pub-3411062052281263/8502865308";
			string adUnitId = text;
			interstitial = new GoogleMobileAds.Api.InterstitialAd(adUnitId);
			AdRequest request = new AdRequest.Builder().Build();
			interstitial.LoadAd(request);
			interstitial.OnAdClosed += Interstitial_OnAdClosed;
			interstitial.OnAdFailedToLoad += Interstitial_OnFailToLoad;
		}
		catch (Exception)
		{
		}
	}

	private static void RequestInterstitialAds2()
	{
		try
		{
			string text = "ca-app-pub-3411062052281263/9258044518";
			string adUnitId = text;
			interstitial2 = new GoogleMobileAds.Api.InterstitialAd(adUnitId);
			AdRequest request = new AdRequest.Builder().Build();
			interstitial2.LoadAd(request);
			interstitial2.OnAdClosed += Interstitial_OnAdClosed;
		}
		catch (Exception)
		{
		}
	}

	private static void Interstitial_OnFailToLoad(object sender, EventArgs e)
	{
		try
		{
			if (interstitial2 == null || !interstitial2.IsLoaded())
			{
				RequestInterstitialAds2();
			}
		}
		catch (Exception)
		{
		}
	}

	private static void Interstitial_OnAdClosed(object sender, EventArgs e)
	{
		try
		{
			if (GameScript.isGameOver)
			{
				gm.retry.SetActive(value: true);
				gm.menu.SetActive(value: true);
				gm.failMenu.SetActive(value: true);
				gm.failRetry.SetActive(value: true);
			}
			if (GameScript.isReplay)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadInterstitial()
	{
		AudienceNetwork.InterstitialAd interstitialAd = this.interstitialAd = new AudienceNetwork.InterstitialAd("177562949545239_319702571997942");
		this.interstitialAd.Register(base.gameObject);
		this.interstitialAd.InterstitialAdDidLoad = delegate
		{
			isLoaded = true;
		};
		interstitialAd.InterstitialAdDidFailWithError = delegate
		{
			if (interstitial == null || !interstitial.IsLoaded())
			{
				RequestInterstitialAds();
			}
		};
		interstitialAd.InterstitialAdWillLogImpression = delegate
		{
		};
		interstitialAd.InterstitialAdDidClick = delegate
		{
		};
		interstitialAd.interstitialAdDidClose = delegate
		{
			if (GameScript.isGameOver)
			{
				gm.retry.SetActive(value: true);
				gm.menu.SetActive(value: true);
				gm.failMenu.SetActive(value: true);
				gm.failRetry.SetActive(value: true);
			}
			if (GameScript.isReplay)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
			}
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

	public void watchRewardVideo()
	{
		try
		{
			Analytics.CustomEvent(" WatchReward ", new Dictionary<string, object>
			{
				{
					"WatchReward",
					Global.currentLevel
				}
			});
			if (rewardLoaded)
			{
				rewardBasedVideo.Show();
				hideSkipRewardBtn = true;
				continueReward = false;
				GameManager.gameState = GameState.Rewared_Video_Started;
			}
			else if (Monetization.IsReady(rewarded_Video))
			{
				hideSkipRewardBtn = true;
				continueReward = false;
				ShowAdPlacementContent showAdPlacementContent = null;
				showAdPlacementContent = (Monetization.GetPlacementContent(rewarded_Video) as ShowAdPlacementContent);
				if (showAdPlacementContent != null)
				{
					ShowAdCallbacks value = default(ShowAdCallbacks);
					value.finishCallback = HandleShowRewardedVideoResult;
					showAdPlacementContent.Show(value);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void watchSkipLevelRewardVideo()
	{
		try
		{
			Analytics.CustomEvent(" WatchSkipLevelReward ", new Dictionary<string, object>
			{
				{
					"WatchSkipLevelReward" + Global.currentLevel,
					Global.currentLevel
				}
			});
			Global.noOfTries = 0;
			Global.isSkipActive = false;
			if (rewardLoaded)
			{
				rewardBasedVideo.Show();
				hideSkipRewardBtn = false;
				continueReward = false;
				GameManager.gameState = GameState.Rewared_Video_Started;
			}
			else if (Monetization.IsReady(rewarded_Video))
			{
				hideSkipRewardBtn = false;
				continueReward = false;
				ShowAdPlacementContent showAdPlacementContent = null;
				showAdPlacementContent = (Monetization.GetPlacementContent(rewarded_Video) as ShowAdPlacementContent);
				if (showAdPlacementContent != null)
				{
					ShowAdCallbacks value = default(ShowAdCallbacks);
					value.finishCallback = HandleShowRewardedVideoResult;
					showAdPlacementContent.Show(value);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void watchContinueRewardedVideo()
	{
		try
		{
			Analytics.CustomEvent(" WatchContinueReward ", new Dictionary<string, object>
			{
				{
					"WatchContinueReward" + Global.currentLevel,
					Global.currentLevel
				}
			});
			if (rewardLoaded)
			{
				rewardBasedVideo.Show();
				Global.lastAdDisplayTime = Time.time;
				continueReward = true;
				GameManager.gameState = GameState.Rewared_Video_Started;
			}
			else if (Monetization.IsReady(rewarded_Video))
			{
				continueReward = true;
				ShowAdPlacementContent showAdPlacementContent = null;
				showAdPlacementContent = (Monetization.GetPlacementContent(rewarded_Video) as ShowAdPlacementContent);
				if (showAdPlacementContent != null)
				{
					ShowAdCallbacks value = default(ShowAdCallbacks);
					value.finishCallback = HandleShowRewardedVideoResult;
					showAdPlacementContent.Show(value);
					Global.lastAdDisplayTime = Time.time;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void HandleShowRewardedVideoResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			if (continueReward)
			{
				PopUpManager.continueVideoPup.SetActive(value: false);
				Global.isContinuePopActive = false;
				if (Global.currentLevel == 12)
				{
					SceneLoader.LoadAScene("LEVEL113");
				}
				else if (Global.currentLevel == 24)
				{
					SceneLoader.LoadAScene("LEVEL213");
				}
				else if (Global.currentLevel == 150)
				{
					SceneLoader.LoadAScene("LEVEL13");
				}
				else if (Global.currentLevel == 224)
				{
					SceneLoader.LoadAScene("LEVEL25");
				}
				else
				{
					SceneLoader.LoadAScene("LEVEL" + (Global.currentLevel + 1));
				}
			}
			else
			{
				GameManager.gameState = GameState.RewardedBall;
			}
			break;
		case ShowResult.Skipped:
			UnityEngine.Debug.Log("You will lose reward ");
			if (continueReward)
			{
				PopUpManager.continueVideoPup.SetActive(value: false);
				Global.isContinuePopActive = false;
				if (Global.currentLevel == 12)
				{
					SceneLoader.LoadAScene("LEVEL113");
				}
				else if (Global.currentLevel == 24)
				{
					SceneLoader.LoadAScene("LEVEL213");
				}
				else if (Global.currentLevel == 150)
				{
					SceneLoader.LoadAScene("LEVEL13");
				}
				else if (Global.currentLevel == 224)
				{
					SceneLoader.LoadAScene("LEVEL25");
				}
				else
				{
					SceneLoader.LoadAScene("LEVEL" + (Global.currentLevel + 1));
				}
			}
			else if (GameManager.gameState != GameState.RewardedBall)
			{
				GameManager.gameState = GameState.Rewared_Video_InCompleted;
			}
			break;
		case ShowResult.Failed:
			if (continueReward)
			{
				PopUpManager.continueVideoPup.SetActive(value: false);
				Global.isContinuePopActive = false;
				if (Global.currentLevel == 12)
				{
					SceneLoader.LoadAScene("LEVEL113");
				}
				else if (Global.currentLevel == 24)
				{
					SceneLoader.LoadAScene("LEVEL213");
				}
				else if (Global.currentLevel == 150)
				{
					SceneLoader.LoadAScene("LEVEL13");
				}
				else if (Global.currentLevel == 224)
				{
					SceneLoader.LoadAScene("LEVEL25");
				}
				else
				{
					SceneLoader.LoadAScene("LEVEL" + (Global.currentLevel + 1));
				}
			}
			else
			{
				UnityEngine.Debug.Log("Sorry. No Videos Available. ");
				PopUpManager.watchVideoPup.SetActive(value: false);
				PopUpManager.skipbtn.SetActive(value: false);
			}
			break;
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		try
		{
			switch (result)
			{
			case ShowResult.Finished:
				UnityEngine.Debug.Log("The ad was successfully shown.");
				Global.lastAdDisplayTime = Time.time;
				if (GameScript.isGameOver)
				{
					gm.retry.SetActive(value: true);
					gm.menu.SetActive(value: true);
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
				if (GameScript.isReplay)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
				}
				break;
			case ShowResult.Skipped:
				UnityEngine.Debug.Log("The ad was skipped before reaching the end.");
				Global.lastAdDisplayTime = Time.time;
				if (GameScript.isGameOver)
				{
					gm.retry.SetActive(value: true);
					gm.menu.SetActive(value: true);
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
				if (GameScript.isReplay)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
				}
				break;
			case ShowResult.Failed:
				UnityEngine.Debug.LogError("The ad failed to be shown.");
				if (GameScript.isGameOver)
				{
					gm.retry.SetActive(value: true);
					gm.menu.SetActive(value: true);
					gm.failMenu.SetActive(value: true);
					gm.failRetry.SetActive(value: true);
				}
				if (GameScript.isReplay)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(GameScript.sceneName);
				}
				break;
			}
		}
		catch (Exception)
		{
		}
	}
}
