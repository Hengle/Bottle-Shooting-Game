using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ShareAndRate : MonoBehaviour
{
	private string subject = "Knock Down Bottles";

	private string body = "https://play.google.com/store/apps/details?id=com.knockdown.bottle.game";

	public void OnAndroidTextSharingClick()
	{
		StartCoroutine(ShareAndroidText());
	}

	private IEnumerator ShareAndroidText()
	{
		yield return new WaitForEndOfFrame();
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		intentObject.Call<AndroidJavaObject>("setAction", new object[1]
		{
			intentClass.GetStatic<string>("ACTION_SEND")
		});
		intentObject.Call<AndroidJavaObject>("setType", new object[1]
		{
			"text/plain"
		});
		intentObject.Call<AndroidJavaObject>("putExtra", new object[2]
		{
			intentClass.GetStatic<string>("EXTRA_SUBJECT"),
			subject
		});
		intentObject.Call<AndroidJavaObject>("putExtra", new object[2]
		{
			intentClass.GetStatic<string>("EXTRA_TEXT"),
			body
		});
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", new object[2]
		{
			intentObject,
			"Share Via"
		});
		currentActivity.Call("startActivity", jChooser);
	}

	public void OniOSTextSharingClick()
	{
	}

	public void RateUs()
	{
		Application.OpenURL("market://details?id=com.knockdown.bottle.game");
	}

	public void ProLink()
	{
		try
		{
			Analytics.CustomEvent(" PRO ", new Dictionary<string, object>
			{
				{
					"PRO",
					"PLAYSTORE"
				}
			});
		}
		catch (Exception)
		{
		}
		Application.OpenURL("market://details?id=com.knockdown.bottle.pro");
		UnityEngine.Debug.Log("PRO LINK CODE HERE");
	}
}
