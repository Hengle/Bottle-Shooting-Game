using UnityEngine;
using UnityEngine.UI;

public class IronSourceAdDisplay : MonoBehaviour
{
	private int totalrewardsget;

	[SerializeField]
	private Text _rewardCount;

	private void Start()
	{
		IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
		UnityEngine.Debug.Log("unity-script: LoadInterstitial");
		IronSource.Agent.loadInterstitial();
	}

	private void Update()
	{
	}

	public void ShowIronAd()
	{
		UnityEngine.Debug.Log("unity-script: ShowInterstitialButtonClicked");
		if (IronSource.Agent.isInterstitialReady())
		{
			IronSource.Agent.showInterstitial();
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
		}
	}

	public void ShowIronRewardAd()
	{
		UnityEngine.Debug.Log("unity-script: ShowRewardedVideoButtonClicked");
		if (IronSource.Agent.isRewardedVideoAvailable())
		{
			IronSource.Agent.showRewardedVideo();
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isRewardedVideoAvailable - False");
		}
	}

	private void RewardedVideoAdRewardedEvent(IronSourcePlacement ssp)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdRewardedEvent, amount = " + ssp.getRewardAmount() + " name = " + ssp.getRewardName());
		totalrewardsget++;
		_rewardCount.text = "Rewards: " + totalrewardsget;
	}
}
