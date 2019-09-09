using UnityEngine;

public class ShowRewardedVideoScript : MonoBehaviour
{
	private int userTotalCredits;

	public static string REWARDED_INSTANCE_ID = "0";

	private void Start()
	{
		UnityEngine.Debug.Log("unity-script: ShowRewardedVideoScript Start called");
		IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
		IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
		IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
		IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
		IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
		IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
		IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;
		IronSourceEvents.onRewardedVideoAdClickedEvent += RewardedVideoAdClickedEvent;
		IronSourceEvents.onRewardedVideoAdOpenedDemandOnlyEvent += RewardedVideoAdOpenedDemandOnlyEvent;
		IronSourceEvents.onRewardedVideoAdClosedDemandOnlyEvent += RewardedVideoAdClosedDemandOnlyEvent;
		IronSourceEvents.onRewardedVideoAvailabilityChangedDemandOnlyEvent += RewardedVideoAvailabilityChangedDemandOnlyEvent;
		IronSourceEvents.onRewardedVideoAdRewardedDemandOnlyEvent += RewardedVideoAdRewardedDemandOnlyEvent;
		IronSourceEvents.onRewardedVideoAdShowFailedDemandOnlyEvent += RewardedVideoAdShowFailedDemandOnlyEvent;
		IronSourceEvents.onRewardedVideoAdClickedDemandOnlyEvent += RewardedVideoAdClickedDemandOnlyEvent;
	}

	private void Update()
	{
	}

	public void ShowRewardedVideoButtonClicked()
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

	private void ShowDemandOnlyRewardedVideo()
	{
		UnityEngine.Debug.Log("unity-script: ShowDemandOnlyRewardedVideoButtonClicked");
		if (IronSource.Agent.isISDemandOnlyRewardedVideoAvailable(REWARDED_INSTANCE_ID))
		{
			IronSource.Agent.showISDemandOnlyRewardedVideo(REWARDED_INSTANCE_ID);
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isISDemandOnlyRewardedVideoAvailable - False");
		}
	}

	private void RewardedVideoAvailabilityChangedEvent(bool canShowAd)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAvailabilityChangedEvent, value = " + canShowAd);
		if (!canShowAd)
		{
		}
	}

	private void RewardedVideoAdOpenedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedEvent");
	}

	private void RewardedVideoAdRewardedEvent(IronSourcePlacement ssp)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdRewardedEvent, amount = " + ssp.getRewardAmount() + " name = " + ssp.getRewardName());
		userTotalCredits += ssp.getRewardAmount();
	}

	private void RewardedVideoAdClosedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClosedEvent");
	}

	private void RewardedVideoAdStartedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdStartedEvent");
	}

	private void RewardedVideoAdEndedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdEndedEvent");
	}

	private void RewardedVideoAdShowFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdShowFailedEvent, code :  " + error.getCode() + ", description : " + error.getDescription());
	}

	private void RewardedVideoAdClickedEvent(IronSourcePlacement ssp)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClickedEvent, name = " + ssp.getRewardName());
	}

	private void RewardedVideoAvailabilityChangedDemandOnlyEvent(string instanceId, bool canShowAd)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAvailabilityChangedDemandOnlyEvent for instance: " + instanceId + ", value = " + canShowAd);
		if (!canShowAd)
		{
		}
	}

	private void RewardedVideoAdOpenedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdRewardedDemandOnlyEvent(string instanceId, IronSourcePlacement ssp)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdRewardedDemandOnlyEvent for instance: " + instanceId + ", amount = " + ssp.getRewardAmount() + " name = " + ssp.getRewardName());
		userTotalCredits += ssp.getRewardAmount();
	}

	private void RewardedVideoAdClosedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClosedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdStartedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdStartedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdEndedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdEndedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdShowFailedDemandOnlyEvent(string instanceId, IronSourceError error)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdShowFailedDemandOnlyEvent for instance: " + instanceId + ", code :  " + error.getCode() + ", description : " + error.getDescription());
	}

	private void RewardedVideoAdClickedDemandOnlyEvent(string instanceId, IronSourcePlacement ssp)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClickedDemandOnlyEvent for instance: " + instanceId + ", name = " + ssp.getRewardName());
	}
}
