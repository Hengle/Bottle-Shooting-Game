using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class menuctrl : MonoBehaviour
{
	private float currentAdDisplayTime;

	public void Load(int level)
	{
		Global.tutorialDisplaye = true;
		Global.noOfTries++;
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && null != AudioManager.Instance)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		SceneLoader.LoadAScene("LEVEL" + Global.currentLevel);
	}

	public void NextLevel(int level)
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Global.noOfTries = 0;
		Global.isSkipActive = false;
		currentAdDisplayTime = Time.time;
		float num = currentAdDisplayTime - Global.lastAdDisplayTime;
		if (num > Global.backFillAdGapToContinue && Global.isRewardVidAvail)
		{
			Global.isContinuePopActive = true;
		}
		else if (Global.currentLevel == 12)
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

	public void WorldComplete()
	{
	}

	public void GoBack()
	{
		Global.noOfTries = 0;
		Global.isSkipActive = false;
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		try
		{
			Analytics.CustomEvent(Global.currentLevel + "_GOPopup _" + PlayerPrefs.HasKey("level" + Global.currentLevel), new Dictionary<string, object>
			{
				{
					"retryCount",
					Global.retryCount
				}
			});
		}
		catch (Exception)
		{
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
	}
}
