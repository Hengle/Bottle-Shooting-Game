using UnityEngine;

public class PopUpManager : MonoBehaviour
{
	private bool skipActive;

	private bool continuePopActive;

	[SerializeField]
	private GameObject skipButton;

	[SerializeField]
	private GameObject watchVideoPopUp;

	[SerializeField]
	private GameObject continueVideoPopUp;

	public static GameObject skipbtn;

	public static GameObject watchVideoPup;

	public static GameObject continueVideoPup;

	private void Start()
	{
		continueVideoPup = UnityEngine.Object.Instantiate(continueVideoPopUp, base.transform);
		continueVideoPup.SetActive(value: false);
	}

	private void Update()
	{
		if (Global.isSkipActive && !skipActive)
		{
			skipbtn = UnityEngine.Object.Instantiate(skipButton, base.transform);
			skipbtn.transform.localScale = Vector3.one;
			watchVideoPup = UnityEngine.Object.Instantiate(watchVideoPopUp, base.transform);
			watchVideoPup.SetActive(value: false);
			skipActive = true;
		}
		if (Global.isContinuePopActive && !continuePopActive)
		{
			continueVideoPup.SetActive(value: true);
			continuePopActive = true;
		}
	}

	public void skipBtnClick()
	{
		watchVideoPup.SetActive(value: true);
		skipbtn.SetActive(value: false);
	}

	public void closePopUp()
	{
		watchVideoPup.SetActive(value: false);
		skipbtn.SetActive(value: true);
	}

	public void watchRewardVideo()
	{
		AdScript.watchSkipLevelRewardVideo();
	}

	public void watchContinueRewardVideo()
	{
		AdScript.watchContinueRewardedVideo();
	}
}
