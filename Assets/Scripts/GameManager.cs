using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public CameraFollow cameraFollow;

	private bool isReward;

	public int currentBirdIndex;

	public GameObject gameOverPanel;

	public GameObject gameFailed;

	public GameObject rewardCanvas;

	public GameObject blackBg;

	public static GameObject blackBg2;

	public GameObject levelup;

	public GameObject menu;

	public GameObject retry;

	public GameObject failRetry;

	public GameObject failMenu;

	public GameObject skipLevelBtn;

	public SlingShot slingShot;

	public int target;

	public int currentLevel;

	[HideInInspector]
	public static GameState gameState;

	private List<GameObject> bricks;

	private List<GameObject> birds;

	private List<GameObject> pigs;

	public GameObject star1;

	public GameObject star2;

	public GameObject star3;

	public GameObject star0;

	public GameObject pauseBtn;

	public GameObject replayBtn;

	public GameObject tutorAnim;

	public GameObject tutorOkBtn;

	public GameObject blurBG;

	public GameObject rewardBall;

	public Text txt;

	public Text levelNo;

	public Text levelNoFail;

	public Text skipLevelText;

	public Image ZeroStarsImage;

	public Text gameFailedMsg;

	private float timer;

	private float timermax;

	public static GameObject levelup2;

	public static GameObject menu2;

	public static GameObject retry2;

	public static Text txt2;

	public static Text gameFailedMsg2;

	public static GameObject gameFailed2;

	[SerializeField]
	private GameObject[] stars;

	private void Start()
	{
		blackBg.SetActive(value: false);
		blackBg2 = blackBg;
		levelup2 = levelup;
		menu2 = menu;
		retry2 = retry;
		if (Global.currentLevel >= 13 && Global.currentLevel <= 24)
		{
			levelNo.text = string.Empty + (Global.currentLevel - 12);
			levelNoFail.text = string.Empty + (Global.currentLevel - 12);
		}
		else if (Global.currentLevel >= 25 && Global.currentLevel <= 36)
		{
			levelNo.text = string.Empty + (Global.currentLevel - 24);
			levelNoFail.text = string.Empty + (Global.currentLevel - 24);
		}
		else if (Global.currentLevel >= 113 && Global.currentLevel <= 150)
		{
			levelNo.text = string.Empty + (Global.currentLevel - 100);
			levelNoFail.text = string.Empty + (Global.currentLevel - 100);
		}
		else if (Global.currentLevel >= 213 && Global.currentLevel <= 224)
		{
			levelNo.text = string.Empty + (Global.currentLevel - 200);
			levelNoFail.text = string.Empty + (Global.currentLevel - 200);
		}
		else
		{
			levelNo.text = string.Empty + Global.currentLevel;
			levelNoFail.text = string.Empty + Global.currentLevel;
		}
		txt2 = txt;
		gameFailedMsg2 = gameFailedMsg;
		gameFailed2 = gameFailed;
		if ((Global.currentLevel >= 1 && Global.currentLevel < 13) || (Global.currentLevel > 112 && Global.currentLevel < 121))
		{
			Global.retryCount = Global.retryCount1;
		}
		else if (Global.currentLevel >= 121 && Global.currentLevel < 141)
		{
			Global.retryCount = Global.retryCount2;
		}
		else if (Global.currentLevel >= 141 && Global.currentLevel < 151)
		{
			Global.retryCount = Global.retryCount3;
		}
		else
		{
			Global.retryCount = Global.retryCount4;
		}
		skipLevelText.text = getSkipLevelText();
	}

	private string getSkipLevelText()
	{
		string result = "Watch video to\n skip level";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Regarder la vidéo pour\nSauter niveau";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "شاهد الفيديو لتخطي المستوى";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Bekijk video naar\nsla level over";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Sehen Sie sich das Video an\num die Ebene zu überspringen";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Guarda il video \nper saltare il livello";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "レベルをスキップするために\nビデオを見る";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Obejrzyj wideo, \naby pominąć poziom";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Assista ao vídeo \npara pular o nível";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Смотреть видео,\nчтобы пропустить уровень";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Ver video para saltar de nivel";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Seviyeyi atlamak için\nvideoyu izleyin";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "观看视频以跳过级别";
		}
		return result;
	}

	private void Awake()
	{
		Global.rewardUsed = false;
		try
		{
			if (AdScript.bannerAd1 != null && AdScript.bannerAd2 != null)
			{
				AdScript.bannerAd2.Hide();
			}
		}
		catch (Exception)
		{
		}
		Global.target = target;
		Global.currentLevel = currentLevel;
		try
		{
			Analytics.CustomEvent(Global.world + " 2 ", new Dictionary<string, object>
			{
				{
					"LEVEL",
					Global.currentLevel
				}
			});
		}
		catch (Exception)
		{
		}
		gameState = GameState.Start;
		slingShot.enabled = false;
		slingShot.slingShootLineRenderer1.enabled = false;
		slingShot.slingShootLineRenderer2.enabled = false;
		slingShot.slingBeltRenderer.enabled = false;
		bricks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Brick"));
		birds = new List<GameObject>();
		GameObject[] array = FindObsWithTag("Bird");
		for (int i = 0; i < array.Length; i++)
		{
			if (i == array.Length - 1)
			{
				array[i].SetActive(value: false);
				rewardBall = array[i];
			}
			else
			{
				birds.Add(array[i]);
			}
		}
		object[] array2 = birds.ToArray();
		if (array2 != null && array2.Length > 0)
		{
			for (int j = 0; j < array2.Length; j++)
			{
				birds[j].GetComponent<CircleCollider2D>().enabled = false;
			}
		}
		pigs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pig"));
		Global.birdCount = 0;
		Global.TotalbirdCount = birds.Count;
	}

	private GameObject[] FindObsWithTag(string tag)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(tag);
		Array.Sort(array, CompareObNames);
		return array;
	}

	private int CompareObNames(GameObject x, GameObject y)
	{
		return x.name.CompareTo(y.name);
	}

	private void OnEnable()
	{
		slingShot.birdThrown += SlingShotBirdThrown;
	}

	private void OnDisable()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		try
		{
			if (pauseStatus)
			{
				Analytics.CustomEvent(Global.currentLevel + "_DeviceHome", new Dictionary<string, object>
				{
					{
						"DeviceHome",
						Global.retryCount
					}
				});
				if (Global.currentLevel == 1)
				{
					Analytics.CustomEvent(Global.world + "_DeviceHome_" + currentBirdIndex, new Dictionary<string, object>
					{
						{
							"DeviceHome",
							Global.count
						}
					});
				}
				Global.retryCount = Global.retryCount;
			}
		}
		catch (Exception)
		{
		}
	}

	private void Update()
	{
		try
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !PopUpManager.continueVideoPup.activeSelf)
			{
				if (pauseBtn.activeSelf)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
				}
				else
				{
					try
					{
						Analytics.CustomEvent(Global.world + "_HomeButton", new Dictionary<string, object>
						{
							{
								"HomeLevel",
								Global.currentLevel
							}
						});
					}
					catch (Exception)
					{
					}
					Time.timeScale = 1f;
					UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
				}
			}
			if (SceneManager.GetActiveScene().name == "LEVEL_SELECT_new" || SceneManager.GetActiveScene().name == "MainMenu")
			{
				if (null != AudioManager.Instance)
				{
					AudioManager.Instance.Nmusic.Stop();
					AudioManager.Instance.Dmusic.Stop();
					AudioManager.Instance.Smusic.Stop();
				}
			}
			else
			{
				List<string> list = new List<string>();
				list.Add("LEVEL1");
				list.Add("LEVEL2");
				list.Add("LEVEL3");
				list.Add("LEVEL4");
				list.Add("LEVEL5");
				list.Add("LEVEL6");
				list.Add("LEVEL7");
				list.Add("LEVEL8");
				list.Add("LEVEL9");
				list.Add("LEVEL10");
				list.Add("LEVEL11");
				list.Add("LEVEL12");
				list.Add("LEVEL113");
				list.Add("LEVEL114");
				list.Add("LEVEL115");
				list.Add("LEVEL116");
				list.Add("LEVEL118");
				list.Add("LEVEL119");
				list.Add("LEVEL120");
				list.Add("LEVEL121");
				list.Add("LEVEL123");
				list.Add("LEVEL124");
				list.Add("LEVEL125");
				list.Add("LEVEL126");
				list.Add("LEVEL127");
				list.Add("LEVEL128");
				list.Add("LEVEL129");
				list.Add("LEVEL130");
				list.Add("LEVEL131");
				list.Add("LEVEL132");
				list.Add("LEVEL133");
				list.Add("LEVEL134");
				list.Add("LEVEL135");
				list.Add("LEVEL136");
				list.Add("LEVEL137");
				list.Add("LEVEL138");
				list.Add("LEVEL139");
				list.Add("LEVEL140");
				list.Add("LEVEL141");
				list.Add("LEVEL142");
				list.Add("LEVEL143");
				list.Add("LEVEL144");
				list.Add("LEVEL145");
				list.Add("LEVEL146");
				list.Add("LEVEL147");
				list.Add("LEVEL148");
				list.Add("LEVEL149");
				list.Add("LEVEL150");
				if (list.Contains(SceneManager.GetActiveScene().name))
				{
					int @int = PlayerPrefs.GetInt("SOUND");
					if (@int == 1 && null != AudioManager.Instance)
					{
						if (!AudioManager.Instance.Nmusic.isPlaying)
						{
							AudioManager.Instance.Nmusic.Play();
						}
					}
					else if (null != AudioManager.Instance)
					{
						AudioManager.Instance.Nmusic.Stop();
					}
				}
				else
				{
					list = new List<string>();
					list.Add("LEVEL20");
					list.Add("LEVEL21");
					list.Add("LEVEL13");
					list.Add("LEVEL14");
					list.Add("LEVEL15");
					list.Add("LEVEL16");
					list.Add("LEVEL17");
					list.Add("LEVEL18");
					list.Add("LEVEL19");
					list.Add("LEVEL23");
					list.Add("LEVEL24");
					list.Add("LEVEL22");
					list.Add("LEVEL213");
					list.Add("LEVEL214");
					list.Add("LEVEL215");
					list.Add("LEVEL216");
					list.Add("LEVEL217");
					list.Add("LEVEL218");
					list.Add("LEVEL219");
					list.Add("LEVEL220");
					list.Add("LEVEL221");
					list.Add("LEVEL223");
					list.Add("LEVEL224");
					if (list.Contains(SceneManager.GetActiveScene().name))
					{
						int int2 = PlayerPrefs.GetInt("SOUND");
						if (int2 == 1 && null != AudioManager.Instance)
						{
							if (!AudioManager.Instance.Dmusic.isPlaying)
							{
								AudioManager.Instance.Dmusic.Play();
							}
						}
						else if (null != AudioManager.Instance)
						{
							AudioManager.Instance.Dmusic.Stop();
						}
					}
					else
					{
						list = new List<string>();
						list.Add("LEVEL25");
						list.Add("LEVEL26");
						list.Add("LEVEL27");
						list.Add("LEVEL28");
						list.Add("LEVEL29");
						list.Add("LEVEL30");
						list.Add("LEVEL31");
						list.Add("LEVEL32");
						list.Add("LEVEL33");
						list.Add("LEVEL34");
						list.Add("LEVEL35");
						list.Add("LEVEL36");
						if (list.Contains(SceneManager.GetActiveScene().name))
						{
							int int3 = PlayerPrefs.GetInt("SOUND");
							if (int3 == 1 && null != AudioManager.Instance)
							{
								if (!AudioManager.Instance.Smusic.isPlaying)
								{
									AudioManager.Instance.Smusic.Play();
								}
							}
							else if (null != AudioManager.Instance)
							{
								AudioManager.Instance.Smusic.Stop();
							}
						}
					}
				}
			}
			if (Global.count >= Global.target && gameOverPanel.activeSelf)
			{
				if (Global.currentLevel == 124 || Global.currentLevel == 224 || Global.currentLevel == 36)
				{
					txt.fontSize = 25;
					txt.lineSpacing = 1f;
					if (retry.activeSelf && !levelup.activeSelf)
					{
						levelup.SetActive(value: true);
					}
				}
				else if (retry.activeSelf && !levelup.activeSelf)
				{
					levelup.SetActive(value: true);
				}
				PopUpManager.skipbtn.SetActive(value: false);
			}
			if (isReward)
			{
				gameOverPanel.SetActive(value: false);
				blackBg.SetActive(value: false);
			}
			if (gameOverPanel.activeSelf)
			{
				slingShot.SetSlingshotLinerenderersActive(active: false);
				if (AdScript.bannerAd1 != null)
				{
				}
				if (AdScript.adView != null)
				{
					AdScript.adView.Show(100.0);
				}
			}
			else if (AdScript.bannerAd1 != null && AdScript.adView != null)
			{
				AdScript.adView.Dispose();
			}
			switch (gameState)
			{
			case GameState.BirdMovingToSlingshot:
			case GameState.skipLevelReward:
			case GameState.SkipRewared_Video_Started:
				break;
			case GameState.Won:
			case GameState.Lost:
				break;
			case GameState.Start:
				if (Global.currentLevel != 1)
				{
					AnimateBirdToSlingshot();
				}
				else if (Global.tutorialDisplaye)
				{
					tutorAnim = GameObject.Find("Tuto 2");
					tutorAnim.SetActive(value: false);
					tutorOkBtn = GameObject.Find("Done");
					tutorOkBtn.SetActive(value: false);
					pauseBtn.SetActive(value: true);
					replayBtn.SetActive(value: true);
					blurBG = GameObject.Find("Blur_bg");
					blurBG.SetActive(value: false);
					AnimateBirdToSlingshot();
				}
				break;
			case GameState.Playing:
				if (slingShot.slingShootState == SlingshotState.BirdFlying && (BricksBirdsPigsStoppedMoving() || Time.time - slingShot.timeSinceThrown > 3f))
				{
					slingShot.enabled = false;
					slingShot.slingShootLineRenderer1.enabled = false;
					slingShot.slingShootLineRenderer2.enabled = false;
					slingShot.slingBeltRenderer.enabled = false;
					AnimateCameraToStartPosition();
					gameState = GameState.BirdMovingToSlingshot;
				}
				break;
			case GameState.RewardedBall:
				if (AdScript.continueReward)
				{
					PopUpManager.continueVideoPup.SetActive(value: false);
					menu.SetActive(value: true);
					retry.SetActive(value: true);
					if (gameFailed.activeSelf)
					{
						failMenu.SetActive(value: true);
						failRetry.SetActive(value: true);
					}
				}
				else if (AdScript.hideSkipRewardBtn)
				{
					gameOverPanel.SetActive(value: false);
					blackBg.SetActive(value: false);
					rewardCanvas.SetActive(value: false);
					isReward = true;
					AnimateBirdToSlingshot();
				}
				else
				{
					PlayerPrefs.SetInt("level" + Global.currentLevel, 1);
					UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL" + (Global.currentLevel + 1));
				}
				break;
			case GameState.Rewared_Video_Started:
				if (AdScript.hideSkipRewardBtn)
				{
					rewardCanvas.SetActive(value: false);
					blackBg.SetActive(value: false);
				}
				else
				{
					PopUpManager.skipbtn.SetActive(value: false);
					PopUpManager.watchVideoPup.SetActive(value: false);
				}
				break;
			case GameState.Rewared_Video_InCompleted:
				if (AdScript.hideSkipRewardBtn && !rewardBall.activeSelf)
				{
					if (!gameFailed.activeSelf)
					{
						gameFailed.SetActive(value: true);
						blackBg.SetActive(value: true);
					}
					rewardCanvas.SetActive(value: false);
				}
				else if (!AdScript.hideSkipRewardBtn && !rewardBall.activeSelf)
				{
					PopUpManager.skipbtn.SetActive(value: false);
					PopUpManager.watchVideoPup.SetActive(value: false);
					gameState = GameState.Playing;
				}
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void AnimateBirdToSlingshot()
	{
		if (Global.count >= target)
		{
			slingShot.enabled = false;
			if (isReward)
			{
				rewardBall.GetComponent<SpriteRenderer>().enabled = false;
			}
			else
			{
				birds[currentBirdIndex].GetComponent<SpriteRenderer>().enabled = false;
			}
			slingShot.slingShootLineRenderer1.enabled = false;
			slingShot.slingShootLineRenderer2.enabled = false;
			slingShot.slingBeltRenderer.enabled = false;
			return;
		}
		float num = Vector2.Distance(Camera.main.transform.position, cameraFollow.startingPosition) / 10f;
		if (num == 0f)
		{
			num = 0.1f;
		}
		Camera.main.transform.positionTo(num, cameraFollow.startingPosition).setOnCompleteHandler(delegate
		{
			if (isReward)
			{
				Global.rewardUsed = true;
				rewardBall.GetComponent<CircleCollider2D>().enabled = true;
			}
			else
			{
				birds[currentBirdIndex].GetComponent<CircleCollider2D>().enabled = true;
			}
		});
		GameObject ball = null;
		if (gameState == GameState.RewardedBall)
		{
			ball = rewardBall;
			rewardBall.SetActive(value: true);
			isReward = true;
			gameOverPanel.SetActive(value: false);
			blackBg.SetActive(value: false);
		}
		else
		{
			ball = birds[currentBirdIndex];
		}
		gameState = GameState.BirdMovingToSlingshot;
		ball.transform.positionTo(Vector2.Distance(ball.transform.position / 10f, slingShot.birdWaitPosition.position) / 10f, slingShot.birdWaitPosition.position).setOnCompleteHandler(delegate(AbstractGoTween x)
		{
			x.complete();
			x.destroy();
			Global.isBottleCollission = false;
			gameState = GameState.Playing;
			slingShot.enabled = true;
			slingShot.birdToThrow = ball;
			slingShot.slingShootState = SlingshotState.Idle;
			if (ball.transform.position == slingShot.birdWaitPosition.position && Waited(1f))
			{
			}
		});
	}

	private bool Waited(float seconds)
	{
		timermax = seconds;
		timer += Time.deltaTime;
		if (timer >= timermax)
		{
			return true;
		}
		return false;
	}

	private void enableSling()
	{
		slingShot.slingShootLineRenderer1.enabled = true;
		slingShot.slingShootLineRenderer2.enabled = true;
		slingShot.slingBeltRenderer.enabled = true;
		slingShot.enabled = true;
	}

	private bool BricksBirdsPigsStoppedMoving()
	{
		foreach (GameObject item in bricks.Union(birds).Union(pigs))
		{
			if (item != null)
			{
				return false;
			}
		}
		return true;
	}

	private bool AllPigsAreDestroyed()
	{
		return pigs.All((GameObject x) => x == null);
	}

	private void AnimateCameraToStartPosition()
	{
		float num = Vector2.Distance(Camera.main.transform.position, cameraFollow.startingPosition) / 10f;
		if (num == 0f)
		{
			num = 0.1f;
		}
		int @int = PlayerPrefs.GetInt("level" + Global.currentLevel);
		if (Global.count >= target && !gameOverPanel.activeSelf)
		{
			gameOverPanel.SetActive(value: true);
			blackBg.SetActive(value: true);
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
			txt.text = "Level Cleared ";
			if (Global.currentLevel != 36 && retry.activeSelf)
			{
				levelup.SetActive(value: true);
			}
			if ((birds.Count - Global.birdCount > 1 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 3) || Global.currentLevel == 213 || Global.currentLevel == 135)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 3);
			}
			else if (birds.Count - Global.birdCount > 0 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 2)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 2);
			}
			else if (PlayerPrefs.GetInt("level" + Global.currentLevel) < 1)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 1);
			}
			if (birds.Count - Global.birdCount > 1 || Global.currentLevel == 213 || Global.currentLevel == 121)
			{
				ShowStars(3);
			}
			else if (birds.Count - Global.birdCount > 0)
			{
				ShowStars(2);
			}
			else
			{
				ShowStars(1);
			}
		}
		Camera.main.transform.positionTo(num, cameraFollow.startingPosition).setOnCompleteHandler(delegate
		{
			cameraFollow.isFollowing = false;
			if (AllPigsAreDestroyed())
			{
				gameState = GameState.Won;
				if (!gameOverPanel.activeSelf)
				{
					if (Global.currentLevel == 118 || Global.currentLevel == 223 || Global.currentLevel == 116 || Global.currentLevel == 9)
					{
						Invoke("checkResult", 5.5f);
					}
					else
					{
						Invoke("checkResult", 3f);
					}
				}
			}
			else if (currentBirdIndex == birds.Count - 1)
			{
				gameState = GameState.Lost;
				if (!gameOverPanel.activeSelf)
				{
					if (Global.currentLevel == 118 || Global.currentLevel == 223 || Global.currentLevel == 116 || Global.currentLevel == 9)
					{
						Invoke("checkResult", 5.5f);
					}
					else
					{
						Invoke("checkBottleCollision", 0.1f);
						Invoke("checkResult", 3f);
					}
				}
			}
			else
			{
				slingShot.slingShootState = SlingshotState.Idle;
				currentBirdIndex++;
				AnimateBirdToSlingshot();
			}
		});
	}

	private void checkBottleCollision()
	{
		if (Global.isBottleCollission)
		{
			return;
		}
		gameFailedMsg.text = getLevelFailedText();
		if (!rewardCanvas.activeSelf && !Global.rewardUsed && (AdScript.rewardLoaded || AdScript.IsUnityRewardReady()) && Global.currentLevel != 135 && Global.currentLevel != 213 && Global.target - Global.count <= 2)
		{
			rewardCanvas.SetActive(value: true);
			Text component = GameObject.FindGameObjectWithTag("rewardTxt").GetComponent<Text>();
			component.text = getRewardText();
		}
		else if (!gameFailed.activeSelf)
		{
			gameFailed.SetActive(value: true);
			blackBg.SetActive(value: true);
			star0.SetActive(value: true);
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1 && null != AudioManager.Instance)
			{
				AudioManager.Instance.LevFail.Play();
			}
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
		}
	}

	private void SlingShotBirdThrown()
	{
		if (isReward)
		{
			isReward = false;
			AdScript.rewardLoaded = false;
			cameraFollow.birdToFollow = rewardBall.transform;
		}
		else
		{
			cameraFollow.birdToFollow = birds[currentBirdIndex].transform;
		}
		cameraFollow.isFollowing = true;
	}

	private void checkResult()
	{
		if (isReward)
		{
			return;
		}
		if (Global.count >= target)
		{
			gameOverPanel.SetActive(value: true);
			blackBg.SetActive(value: true);
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
			txt.text = getLevelClearedText();
			if (birds.Count - Global.birdCount > 1 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 3)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 3);
			}
			else if (birds.Count - Global.birdCount > 0 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 2)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 2);
			}
			else if (PlayerPrefs.GetInt("level" + Global.currentLevel) < 1)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 1);
			}
			if (birds.Count - Global.birdCount > 1)
			{
				star3.SetActive(value: true);
			}
			else if (birds.Count - Global.birdCount > 0)
			{
				star2.SetActive(value: true);
			}
			else
			{
				star1.SetActive(value: true);
			}
			return;
		}
		gameFailedMsg2.text = getLevelFailedText();
		if (!Global.rewardUsed && (AdScript.rewardLoaded || AdScript.IsUnityRewardReady()) && Global.currentLevel != 135 && Global.currentLevel != 213 && Global.target - Global.count <= 2)
		{
			rewardCanvas.SetActive(value: true);
			Text component = GameObject.FindGameObjectWithTag("rewardTxt").GetComponent<Text>();
			component.text = getRewardText();
		}
		else if (!gameFailed.activeSelf)
		{
			gameFailed.SetActive(value: true);
			blackBg.SetActive(value: true);
			star0.SetActive(value: true);
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1 && null != AudioManager.Instance)
			{
				AudioManager.Instance.LevFail.Play();
			}
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
		}
	}

	private string getLevelClearedText()
	{
		if (Global.currentLevel == 150)
		{
			return forestWorldCompletedText();
		}
		if (Global.currentLevel == 224)
		{
			return desertWorldCompletedText();
		}
		if (Global.currentLevel == 36)
		{
			return snowWorldCompletedText();
		}
		string result = "Level Cleared";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Niveau effacé";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "نجاح المستوى";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Niveau gewist";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Level abgeschlossen";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Livello finito";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "レベルクリア";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Poziom wyczyszczone";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Nível concluído";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Уровень очищен";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Nivel completado";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Seviye tamamlandı";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "等级完成";
		}
		return result;
	}

	private string forestWorldCompletedText()
	{
		string result = "Congratulations! \n You have cleared \n all Forest world Levels.";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Toutes nos félicitations!\n Tous les niveaux de \n Forest World ont terminé.";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "تهانينا!\n جميع المستويات \n تطهيرها في عالم الغابات";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Hartelijk gefeliciteerd!\n Je hebt alle levels in\n de Forest World gewist.";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Herzliche Glückwünsche! \n Du hast alle Wald \n World Levels beendet.";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Complimenti!\n Hai finito tutti i \n livelli del mondo della foresta.";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "おめでとう！\n フォレストワ\u30fcルドのす \n べてのレベルがクリアされました。";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Gratulacje! \n Ukończyłeś wszystkie \n poziomy Leśnego świata.";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Parabéns! \n Todos os níveis do \n Forest World terminaram.";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Поздравления! \n Вы очистили все \n уровни лесного мира.";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "¡Felicitaciones! \n Has despejado todos los \n Niveles del mundo forestal.";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Tebrik ederiz!\n Tüm orman \n seviyeleri bitti.";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "恭喜！\n所有森林\n水平都完成了";
		}
		return result;
	}

	private string desertWorldCompletedText()
	{
		string result = "Congratulations! \n You have cleared all \n Desert world Levels.";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Toutes nos félicitations! \n Tous les niveaux \n du désert ont terminé.";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "تهانينا! \nجميع المستويات تطهيرها\n في عالم الصحراء.";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Hartelijk gefeliciteerd! \n Je hebt alle niveaus van \n de woestijnwereld gewist.";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Herzliche Glückwünsche! \n Du hast alle Wüste \n World Levels beendet.";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Complimenti! \n Hai finito tutti i \n livelli del mondo della Deserto.";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "おめでとう！\n 砂漠の世界 \n のすべてのレベルがクリアされました。";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Gratulacje! \n Ukończyłeś wszystkie \n poziomy pustynnego świata.";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Parabéns! \n Todos os níveis do \n Desert World terminaram.";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Поздравления! \n Вы очистили все \n уровни мира пустыни.";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "¡Felicitaciones! \n Has despejado todos los niveles \n del mundo del desierto.";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Tebrik ederiz! \nBütün çöl \n seviyeleri bitti.";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "恭喜！\n所有沙漠\n级别完成。";
		}
		return result;
	}

	private string snowWorldCompletedText()
	{
		string result = "Congratulations!\n You have cleared\n all Snow world Levels.";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Toutes nos félicitations! \n Tous les niveaux \n Snow World ont terminé.";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = " تهانينا! \n جميع المستويات تطهيرها \n في سنو وورلد.";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Hartelijk gefeliciteerd! \n Je hebt alle niveaus van \n de sneeuwwereld gewist.";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Herzliche Glückwünsche! \n Du hast alle Snow \n World Levels beendet.";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Complimenti! \n Hai finito tutti i \n livelli del mondo della La neve.";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "おめでとう！すべて \n のレベルのスノ\u30fcワ\u30fcルド \n がクリアされました。";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Gratulacje! \n Ukończyłeś wszystkie \n poziomy śnieżne świata.";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Parabéns! \n Todos os níveis do \n Snow World terminaram.";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Поздравления! \n Вы очистили все \n уровни мира Снега.";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "¡Felicitaciones! \n Has despejado todos los Niveles \n del Mundo de Nieve.";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Tebrik ederiz! \n Bütün kar \n seviyeleri bitti.";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "恭喜！\n所有级别的\n雪都已完成。";
		}
		return result;
	}

	private string getLevelFailedText()
	{
		string result = "Level Failed";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Niveau échoué";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "فشل المستوى";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Level niet gehaald";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Level gescheitert";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Livello fallito";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "レベルに失敗しました";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Poziom nieudany";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Nível falhado";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Уровень провален";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Nivel fracasado";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Seviye geçilemedi";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "级别失败";
		}
		return result;
	}

	private string getRewardText()
	{
		string result = "Need Extra Ball ?";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Besoin d'une boule supplémentaire?";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "تحتاج الكرة اضافية؟";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Extra bal nodig ?";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Brauchen Sie Extraball ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Hai bisogno di una palla extra ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "余分なボ\u30fcルが必要ですか？";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Potrzebujesz dodatkowej piłki ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Precisa de bola extra ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Нужен лишний бал ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Necesitas bola extra ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Ekstra Top Gerekir ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "需要额外的球吗 ？";
		}
		return result;
	}

	public void skipRewardVideo()
	{
		if (!gameFailed.activeSelf)
		{
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1 && null != AudioManager.Instance)
			{
				AudioManager.Instance.LevFail.Play();
			}
			try
			{
				Analytics.CustomEvent(" SkipReward ", new Dictionary<string, object>
				{
					{
						"SkipReward",
						Global.currentLevel
					}
				});
			}
			catch (Exception)
			{
			}
			gameFailed.SetActive(value: true);
			blackBg.SetActive(value: true);
			star0.SetActive(value: true);
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
			rewardCanvas.SetActive(value: false);
		}
	}

	public void ShowStars(int count)
	{
		UnityEngine.Debug.Log("Show Stars" + count);
		for (int i = 0; i < count; i++)
		{
			stars[i].SetActive(value: true);
			stars[i].transform.DOLocalMoveY(1000f, 0.5f).From().SetDelay((float)i * 0.3f + 1.5f)
				.SetEase(Ease.OutBounce);
			stars[i].transform.DOScale(0f, 0.5f).From().SetDelay((float)i * 0.4f + 1.5f)
				.SetEase(Ease.OutBounce);
		}
	}
}
