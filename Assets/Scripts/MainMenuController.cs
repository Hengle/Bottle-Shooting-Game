using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	public GameObject sound;

	public GameObject mute;

	public GameObject UIComponents;

	public GameObject ExitPanel;

	public GameObject WorldPanel;

	public GameObject rateUsPopup;

	public GameObject ProPopupPanel;

	public Text nStarCount;

	public Text dStartCount;

	public Text sStarCount;

	public GameObject desertStars;

	public GameObject snowStars;

	public GameObject desertLock;

	public GameObject snowLock;

	public GameObject lockPopup;

	public GameObject snowLockPopup;

	public Text natureWorldTopText;

	public Text natureWorldBottomText;

	public Text desertWorldTopText;

	public Text desertWorldBottomText;

	public Text snowyWorldTopText;

	public Text snowyWorldBottomText;

	public Text exitPanelText;

	public Text areYouSurePanelText;

	public Text rateUsText;

	public Text rateUsDescriptionText;

	public Text okayButtonText;

	public Text laterButtonText;

	public Text worldLockedText;

	public Text worldLockedDescriptionText;

	public Text desLockTxt;

	public Text snowLockTxt;

	public Text levUnlockTxt;

	public static GameObject UIComponents2;

	public static GameObject ExitPanel2;

	public static bool isExitClicked;

	private InterstitialAd interstitial;

	private void awake()
	{
		Application.targetFrameRate = 60;
		natureWorldTopText.text = getNatureWorldTopText();
		try
		{
			if (AdScript.bannerAd1 != null)
			{
			}
			if (AdScript.adView != null)
			{
				AdScript.adView.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			try
			{
				Analytics.CustomEvent(Global.world + "_DeviceHome", new Dictionary<string, object>
				{
					{
						"DeviceHome",
						"Main Menu"
					}
				});
			}
			catch (Exception)
			{
			}
		}
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			if (WorldPanel.activeSelf)
			{
				UIComponents.SetActive(value: true);
				WorldPanel.SetActive(value: false);
			}
			else
			{
				isExitClicked = true;
				UIComponents2 = UIComponents;
				ExitPanel2 = ExitPanel;
			}
		}
	}

	private IEnumerator Start()
	{
		if (!Global.loadedFromServer)
		{
			string url = "https://puzzle-games-d9a78.firebaseapp.com/kdbConfig.json";
			WWW www = new WWW(url);
			yield return www;
			try
			{
				if (www.error == null)
				{
					new GameConfig();
					GameConfig gameConfig = JsonUtility.FromJson<GameConfig>(www.text);
					Global.AdGap1 = gameConfig.adGap1;
					Global.AdGap2 = gameConfig.adGap2;
					Global.AdGap3 = gameConfig.adGap3;
					Global.AdGap4 = gameConfig.adGap4;
					Global.const1 = gameConfig.const1;
					Global.retryCount1 = gameConfig.retryCount1;
					Global.retryCount2 = gameConfig.retryCount2;
					Global.retryCount3 = gameConfig.retryCount3;
					Global.retryCount4 = gameConfig.retryCount4;
					Global.backFillAds = gameConfig.backFillAds;
					Global.bannerLevel = gameConfig.bannerLevel;
					Global.backFillAdGap = gameConfig.backFillAdGap;
					Global.backFillAdGapToContinue = gameConfig.backFillAdGapToContinue;
				}
				else
				{
					UnityEngine.Debug.Log("ERROR: " + www.error);
				}
				Global.loadedFromServer = true;
			}
			catch (Exception)
			{
			}
		}
		if (Global.fromLevelSelection)
		{
			UIComponents.SetActive(value: false);
			WorldPanel.SetActive(value: true);
			if (AdScript.bannerAd1 != null)
			{
			}
			if (AdScript.adView != null)
			{
				AdScript.adView.Dispose();
			}
			Global.fromLevelSelection = false;
		}
		natureWorldTopText.text = getNatureWorldTopText();
		natureWorldBottomText.text = getWorldText();
		desertWorldTopText.text = getDesertWorldTopText();
		desertWorldBottomText.text = getWorldText();
		snowyWorldTopText.text = getSnowyWorldTopText();
		snowyWorldBottomText.text = getWorldText();
		exitPanelText.text = getExitText();
		areYouSurePanelText.text = getAreYouSureText();
		rateUsText.text = getRateUsText();
		rateUsDescriptionText.text = getRateUsDescriptionText();
		okayButtonText.text = getOkayText();
		laterButtonText.text = getLaterText();
		worldLockedText.text = getWorldLockedText();
		worldLockedDescriptionText.text = getWorldLockedDescriptionText();
		desLockTxt.text = getWorldLockedDescriptionText();
		snowLockTxt.text = getSnowLockedDescriptionText();
		levUnlockTxt.text = getLevelsUnlockedText();
		nStarCount.text = string.Empty + getNatureStars();
		UnityEngine.Debug.Log("Nature Stars" + getNatureStars());
		dStartCount.text = string.Empty + getDesertStars();
		sStarCount.text = string.Empty + getSnowStars();
		if (isDesserUnlock())
		{
			desertStars.SetActive(value: true);
			desertLock.SetActive(value: false);
		}
		if (isSnowUnlock())
		{
			snowStars.SetActive(value: true);
			snowLock.SetActive(value: false);
		}
		if (PlayerPrefs.HasKey("SOUND"))
		{
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1)
			{
				sound.SetActive(value: true);
				mute.SetActive(value: false);
			}
			else
			{
				sound.SetActive(value: false);
				mute.SetActive(value: true);
			}
		}
		else
		{
			sound.SetActive(value: true);
			mute.SetActive(value: false);
			PlayerPrefs.SetInt("SOUND", 1);
		}
	}

	public void PlayGame(string world)
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Global.world = world;
		if (world.Equals("D") && isDesserUnlock())
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
		}
		else if (world.Equals("S") && isSnowUnlock())
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
		}
		else if (world.Equals("N"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
		}
		else if (world.Equals("D"))
		{
			lockPopup.SetActive(value: true);
		}
		else if (world.Equals("S"))
		{
			snowLockPopup.SetActive(value: true);
		}
	}

	public void Sound()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		sound.SetActive(value: true);
		mute.SetActive(value: false);
		PlayerPrefs.SetInt("SOUND", 1);
	}

	public void Mute()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		sound.SetActive(value: false);
		mute.SetActive(value: true);
		PlayerPrefs.SetInt("SOUND", 0);
	}

	public void quit()
	{
		try
		{
			Analytics.CustomEvent(" EXIT ", new Dictionary<string, object>
			{
				{
					"LEVEL",
					Global.exitLevel
				}
			});
		}
		catch (Exception)
		{
		}
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Application.Quit();
	}

	public void showExitPanel()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		isExitClicked = true;
		UIComponents2 = UIComponents;
		ExitPanel2 = ExitPanel;
	}

	public void hideExitPanel()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		UIComponents.SetActive(value: true);
		ExitPanel.SetActive(value: false);
	}

	public void showProPopupPanel()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		try
		{
			Analytics.CustomEvent(" PRO ", new Dictionary<string, object>
			{
				{
					"PRO",
					"MENU"
				}
			});
		}
		catch (Exception)
		{
		}
		UIComponents.SetActive(value: false);
		ProPopupPanel.SetActive(value: true);
	}

	public void hideProPopupPanel()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		UIComponents.SetActive(value: true);
		ProPopupPanel.SetActive(value: false);
	}

	public void showWorldSelection()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Invoke("showWorldSelection2", 0.5f);
	}

	public void showWorldSelection2()
	{
		UIComponents.SetActive(value: false);
		WorldPanel.SetActive(value: true);
		if (AdScript.bannerAd1 != null)
		{
		}
		if (AdScript.adView != null)
		{
			AdScript.adView.Dispose();
		}
	}

	public void hideWorldSelection()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (PlayerPrefs.HasKey("level24") && !PlayerPrefs.HasKey("RATED"))
		{
			rateUsPopup.SetActive(value: true);
			return;
		}
		UIComponents.SetActive(value: true);
		WorldPanel.SetActive(value: false);
	}

	public void rateNow()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		try
		{
			Application.OpenURL("market://details?id=com.knockdown.bottle.game");
		}
		catch (Exception)
		{
		}
		PlayerPrefs.SetString("RATED", "Y");
		rateUsPopup.SetActive(value: false);
	}

	public void rateLater()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		UIComponents.SetActive(value: true);
		WorldPanel.SetActive(value: false);
		rateUsPopup.SetActive(value: false);
	}

	public void showInterstitialAd()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
		}
	}

	private void RequestInterstitialAds()
	{
		string text = "ca-app-pub-3411062052281263/8401018569";
		string adUnitId = text;
		interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.OnAdClosed += Interstitial_OnAdClosed;
		interstitial.LoadAd(request);
	}

	private void Interstitial_OnAdClosed(object sender, EventArgs e)
	{
	}

	private void langCode()
	{
		string empty = string.Empty;
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.util.Locale"))
		{
			if (androidJavaClass != null)
			{
				using (AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getDefault", new object[0]))
				{
					if (androidJavaObject != null)
					{
						empty = androidJavaObject.Call<string>("getLanguage", new object[0]) + "_" + androidJavaObject.Call<string>("getCountry", new object[0]);
					}
				}
			}
		}
	}

	public static int getNatureStars()
	{
		int num = 0;
		for (int i = 1; i < 13; i++)
		{
			num += PlayerPrefs.GetInt("level" + i);
		}
		for (int j = 113; j < 151; j++)
		{
			num += PlayerPrefs.GetInt("level" + j);
		}
		return num;
	}

	public static int getDesertStars()
	{
		int num = 0;
		for (int i = 13; i < 25; i++)
		{
			num += PlayerPrefs.GetInt("level" + i);
		}
		for (int j = 213; j < 225; j++)
		{
			num += PlayerPrefs.GetInt("level" + j);
		}
		return num;
	}

	public static int getSnowStars()
	{
		int num = 0;
		for (int i = 25; i < 37; i++)
		{
			num += PlayerPrefs.GetInt("level" + i);
		}
		return num;
	}

	private bool isDesserUnlock()
	{
		if (getNatureStars() >= 80)
		{
			return true;
		}
		return false;
	}

	private bool isSnowUnlock()
	{
		if (getDesertStars() >= 40)
		{
			return true;
		}
		return false;
	}

	public void unlockPoupOkClick()
	{
		lockPopup.SetActive(value: false);
		snowLockPopup.SetActive(value: false);
	}

	private string getNatureWorldTopText()
	{
		string result = "Forest";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Forêt";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "غابة";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Bos";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Wald";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Foresta";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "森林";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Las";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Floresta";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "лес";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Bosque";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Orman";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "森林";
		}
		return result;
	}

	private string getDesertWorldTopText()
	{
		string result = "Desert";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "désert";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "صحراء";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Woestijn";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Wüste";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Deserto";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "砂漠";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Pustynia";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Deserto";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "пустынный";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Desierto";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Çöl";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "沙漠";
		}
		return result;
	}

	private string getSnowyWorldTopText()
	{
		string result = "Snowy";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Neige";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "ثلج";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Sneeuw";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Schnee";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "La neve";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "雪";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Śnieg";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Neve";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Снег";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Nieve";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Kar";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "雪";
		}
		return result;
	}

	private string getWorldText()
	{
		string result = "World";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Monde";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "العالمية";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Wereld";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Welt";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Mondo";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "世界";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Świat";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Mundo";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Мир";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Mundo";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Dünya";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "世界";
		}
		return result;
	}

	private string getExitText()
	{
		string result = "Exit";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Sortie";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "ىخرج";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Uitgang";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Ausgang";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Uscita";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "出口";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Wyjście";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Saída";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Выход";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Salida";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "çıkış";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "出口";
		}
		return result;
	}

	private string getAreYouSureText()
	{
		string result = "Are You Sure .. ?";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Êtes-vous sûr .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "هل أنت واثق .. ؟";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Weet je het zeker .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Bist du sicher .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Sei sicuro .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "本気ですか .. ？";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Jesteś pewny .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Você tem certeza .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Ты уверен .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Estás seguro .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Emin misiniz .. ?";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "你确定 .. ？";
		}
		return result;
	}

	private string getRateUsText()
	{
		string result = "Rate Us";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Évaluez nous";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "قيمنا";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Beoordeel ons";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Bewerten Sie uns";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Valutaci";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "評価";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Oceń nas";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Nos avalie";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Оцените нас";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Nos califica";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Bizi değerlendirin";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "为我们评分";
		}
		return result;
	}

	private string getRateUsDescriptionText()
	{
		string result = "We hope you're enjoying our game.Will you please take a moment to rate it ..? C'mon help a developer out ... Thanks";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Nous espérons que vous apprécierez notre jeu. S'il vous plaît prenez un moment pour le noter ..? Allez aider un développeur ... Merci";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "نتمنى أن تستمتعوا بلعبتنا. هل من الممكن أن تأخذ لحظة لتقييمها ..؟ هيا مساعدة مطور خارج ... شكرا";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "We hopen dat je geniet van ons spel. Wil je alsjeblieft een moment nemen om het te beoordelen ..? Kom op, help een ontwikkelaar ... Bedankt";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Wir hoffen, dass Sie unser Spiel genießen. Nehmen Sie sich bitte einen Moment Zeit, um es zu bewerten. Komm 'mal einem Entwickler aus ... Danke";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Speriamo che ti piaccia il nostro gioco. Ti prego, prenditi un momento per valutarlo ...? Dai, aiuta uno sviluppatore ... Grazie";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "あなたは私たちのゲ\u30fcムを楽しんでいることを願っています。 開発者を助けてください...ありがとう";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Mamy nadzieję, że podoba ci się nasza gra. Czy poświęcisz chwilę, aby ją ocenić? Chodź, pomóż programistom ... Dzięki";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Esperamos que você esteja gostando do nosso jogo. Por favor, reserve um momento para avaliá-lo ..? Vamos ajudar um desenvolvedor para fora ... Obrigado";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Мы надеемся, что вам понравится наша игра. Будете ли вы потратить минутку, чтобы оценить ее? .. C'mon помогите разработчику ... Спасибо";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Esperamos que disfrutes de nuestro juego. ¿Podrías tomarte un momento para calificarlo? Vamos a ayudar a un desarrollador a salir ... Gracias";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Umarız oyunumuzun tadını çıkarırsınız. Lütfen bunu değerlendirmek için bir dakikanızı ayırın ..? Bir geliştiriciye yardım edin ... Teşekkürler";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "我们希望你喜欢我们的游戏，请你花点时间评分..？ 来吧，帮助开发者......谢谢";
		}
		return result;
	}

	private string getOkayText()
	{
		string result = "Okay";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "d'accord";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "حسنا";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "oke";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "okay";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Va bene";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "はい";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "w porządku";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "OK";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Хорошо";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Bueno";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Tamam";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "好的";
		}
		return result;
	}

	private string getLaterText()
	{
		string result = "Later";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Plus tard";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "في وقت لاحق";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Later";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Später";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Dopo";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "後で";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Później";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Mais tarde";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Позже";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Luego";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Sonra";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "后来";
		}
		return result;
	}

	private string getWorldLockedText()
	{
		string result = "World Locked";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Monde verrouillé";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "العالم مقفل";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Wereld op slot";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Welt gesperrt";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Mondo bloccato";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "世界ロック";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Świat zablokowany";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Mundo bloqueado";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Мир закрыт";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Mundo bloqueado";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Dünya Kilitli";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "世界锁定";
		}
		return result;
	}

	private string getWorldLockedDescriptionText()
	{
		string result = "Get minimum of 80 stars in Forest World to unlock this world . . .\n (OR)<color=cyan>  BUY Pro version</color>";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Obtenez au moins 80 étoiles dans Forest World pour débloquer ce monde. . .\n (OU)<color=cyan>  Acheter la version Pro</Color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "احصل على 80 نجمة على الأقل في Forest World لفتح هذا العالم. . .\n (آخر)<color=cyan>  شراء نسخة برو</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Ontvang minimum 80 sterren in Forest World om deze wereld te ontgrendelen. . .\n (OF)<color=cyan>  KOOP Pro-versie</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Erhalte mindestens 80 Sterne in Forest World, um diese Welt zu öffnen. . .\n (oder)<color=cyan>  KAUFEN Pro Version</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Ottieni un minimo di 80 stelle in Forest World per sbloccare questo mondo. . .\n (O)<color=cyan>  ACQUISTA Versione Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "この世界のロックを解除するには、自然界で最低80個の星を取得します。 。 。\n (または)<color=cyan>  購入プロバ\u30fcジョン</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Zdobądź minimum 80 gwiazd w świecie przyrody, aby odblokować ten świat. . .\n (LUB)<color=cyan>  KUP wersję Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Obter um mínimo de 80 estrelas no mundo da Forestza para desbloquear este mundo. . .\n (OU)<color=cyan>  COMPRA versão Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Получите минимум 80 звезд в мире природы, чтобы открыть этот мир. , ,\n (ИЛИ)<color=cyan>  Версия BUY Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Obtén un mínimo de 80 estrellas en el mundo de la naturaleza para desbloquear este mundo. . .\n (O)<color=cyan>  COMPRAR versión Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Bu dünyanın kilidini açmak için doğa dünyasında en az 80 yıldız alın. . .\n (VEYA)<color=cyan>  Pro sürümü satın alın</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "在自然界中获得至少80颗星，以解锁这个世界。。。\n (要么)<color=cyan>  购买专业版</color>";
		}
		return result;
	}

	private string getSnowLockedDescriptionText()
	{
		string result = "Get minimum of 40 stars in Desert World to unlock this world . . .\n (OR)<color=cyan>  BUY Pro version</color>";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Obtenez au moins 40 étoiles dans le monde du désert pour débloquer ce monde. . .\n (OU)<color=cyan>  Acheter la version Pro</Color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "احصل على 25 نجمة على الأقل في عالم الصحراء لفتح هذا العالم. . .\n (آخر)<color=cyan>  شراء نسخة برو</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Ontvang minimaal 40 sterren in de woestijn om deze wereld te ontgrendelen. . .\n (OF)<color=cyan>  KOOP Pro-versie</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Erreiche mindestens 40 Sterne in der Wüstenwelt, um diese Welt freizuschalten. . .\n (oder)<color=cyan>  KAUFEN Pro Version</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Ottieni un minimo di 40 stelle nel mondo del deserto per sbloccare questo mondo. . .\n (O)<color=cyan>  ACQUISTA Versione Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "この世界のロックを解除するには、砂漠の世界で最低40の星を獲得してください。 。 。\n (または)<color=cyan>  購入プロバ\u30fcジョン</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Zdobądź minimum 40 gwiazd w pustynnym świecie, aby odblokować ten świat. . .\n (LUB)<color=cyan>  KUP wersję Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Obter um mínimo de 40 estrelas no mundo do deserto para desbloquear este mundo. . .\n (OU)<color=cyan>  COMPRA versão Pro</color>\";";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Получите минимум 40 звезд в мире пустыни, чтобы открыть этот мир. , ,\n (ИЛИ)<color=cyan>  Версия BUY Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Obtén un mínimo de 40 estrellas en el mundo desértico para desbloquear este mundo. . .\n (O)<color=cyan>  COMPRAR versión Pro</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Bu dünyanın kilidini açmak için çöl dünyasında en az 40 yıldız alın. . .\n (VEYA)<color=cyan>  Pro sürümü satın alın</color>";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "在沙漠世界中至少获得40颗星，以解锁这个世界。。。\n (要么)<color=cyan>  购买专业版</color>";
		}
		return result;
	}

	private string getLevelsUnlockedText()
	{
		string result = "All levels are \n Unlocked";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Tous les niveaux \n DÉVERROUILLÉ";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "جميع المستويات فتحها";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Alle niveaus ONTGRENDELD";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Alle Ebenen sind ENTSPERRT";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Tutti i livelli SBLOCCATI";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "すべてのレベルがロックされていない";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Wszystkie poziomy odblokowane";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Todos os níveis desbloqueados";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Все уровни разблокированы";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Todos los niveles desbloqueados";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Tüm seviyeler kilidi açıldı";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "Unlock all levels";
		}
		return result;
	}
}
