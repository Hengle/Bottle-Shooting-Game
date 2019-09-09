using UnityEngine;

public class GamePlayControllerTut : MonoBehaviour
{
	public Sprite done2;

	private int score;

	public GameObject pauseBtn;

	public GameObject replayBtn;

	public GameObject doneBtn;

	public GameObject rewardBG;

	public GameObject TutorialPanel;

	public GameObject PinchPanel;

	private GameManager gm;

	public void GoBack()
	{
		GameScript.sceneName = "LEVEL_SELECT_new";
		GameScript.isGameOver = true;
	}

	private void Start()
	{
		if (AdScript.bannerAd1 != null)
		{
		}
		gm = UnityEngine.Object.FindObjectOfType<GameManager>();
	}

	public void UpdateScore()
	{
		score++;
	}

	public void doneSelected()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		pauseBtn.SetActive(value: true);
		replayBtn.SetActive(value: true);
		TutorialPanel.SetActive(value: false);
		doneBtn.SetActive(value: false);
		rewardBG.SetActive(value: false);
		gm.AnimateBirdToSlingshot();
		LevelBuildup.Instance.StartCoroutine(LevelBuildup.Instance.BuildIt());
	}
}
