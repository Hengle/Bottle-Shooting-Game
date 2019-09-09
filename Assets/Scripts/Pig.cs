using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Pig : MonoBehaviour
{
	private AudioSource audioSource;

	public float health = 150f;

	public Sprite spriteShownWhenHurt;

	private float changeSpriteHealth;

	public GameObject gameOverPanel;

	public GameObject pauseBtn;

	public GameObject replayBtn;

	private static GameManager gameMngr;

	public GameObject star1;

	public GameObject star2;

	public GameObject star3;

	public GameObject star0;

	public AudioClip broke;

	private Explodable _explodable;

	[SerializeField]
	public int count;

	private int bottleSoundCount = 10;

	private bool firstTime = true;

	public bool bottlesfound;

	private bool hitonce;

	[SerializeField]
	private GameObject[] stars;

	private void Start()
	{
		try
		{
			Invoke("startSound", 2f);
			gameMngr = UnityEngine.Object.FindObjectOfType<GameManager>();
			GetComponent<AudioSource>().playOnAwake = false;
			GetComponent<AudioSource>().clip = broke;
			_explodable = GetComponent<Explodable>();
			audioSource = GetComponent<AudioSource>();
			changeSpriteHealth = health - 30f;
		}
		catch (Exception)
		{
		}
	}

	private void startSound()
	{
		bottleSoundCount = 0;
	}

	private void explodebottle()
	{
		_explodable.explode();
		ExplosionForce explosionForce = UnityEngine.Object.FindObjectOfType<ExplosionForce>();
		explosionForce.doExplosion(base.transform.position);
		Global.brokenBotList.Add(_explodable);
	}

	private void OnTriggerEnter2D(Collider2D target)
	{
		if (!(target.gameObject.tag == "water"))
		{
			return;
		}
		GameManager.gameFailedMsg2.text = getLevelFailedText();
		if (!GameManager.gameFailed2.activeSelf)
		{
			GameManager.gameFailed2.SetActive(value: true);
			star0.SetActive(value: true);
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1 && AudioManager.Instance != null)
			{
				AudioManager.Instance.LevFail.Play();
			}
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
			gameMngr.blackBg.SetActive(value: true);
			gameMngr.failMenu.SetActive(value: true);
			gameMngr.failRetry.SetActive(value: true);
		}
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "pig" && bottleSoundCount < 4)
		{
			bottleSoundCount++;
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1 && null != AudioManager.Instance)
			{
				AudioManager.Instance.bottleBottle.volume = Mathf.Clamp(2f, 0.1f, 4f);
				AudioManager.Instance.bottleBottle.Play();
			}
		}
		if (target.gameObject.tag == "Bird")
		{
			bool flag = true;
			int int2 = PlayerPrefs.GetInt("SOUND");
			if (int2 == 1 && null != AudioManager.Instance && flag)
			{
				AudioManager.Instance.ballToBottle.Play();
				flag = false;
			}
		}
		firstTime = false;
		if (!(target.gameObject.tag == "ground"))
		{
			return;
		}
		int int3 = PlayerPrefs.GetInt("SOUND");
		if (int3 == 1 && !Global.botList.Contains(base.gameObject))
		{
			audioSource.Play();
		}
		if (Global.botList.Contains(base.gameObject))
		{
			return;
		}
		Global.count++;
		Global.isBottleCollission = true;
		Global.botList.Add(base.gameObject);
		if (Global.count >= Global.target && !gameOverPanel.activeSelf)
		{
			try
			{
				Analytics.CustomEvent(Global.currentLevel + "- Completed2 ", new Dictionary<string, object>
				{
					{
						"LEVEL",
						Global.retryCount
					}
				});
			}
			catch (Exception)
			{
			}
			GameManager.blackBg2.SetActive(value: true);
			gameOverPanel.SetActive(value: true);
			if (int3 == 1 && null != AudioManager.Instance)
			{
				AudioManager.Instance.LevClear.Play();
			}
			pauseBtn.SetActive(value: false);
			replayBtn.SetActive(value: false);
			GameManager.txt2.text = getLevelClearedText();
			if ((Global.TotalbirdCount - Global.birdCount > 1 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 3) || Global.currentLevel == 213 || Global.currentLevel == 135)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 3);
			}
			else if (Global.TotalbirdCount - Global.birdCount > 0 && PlayerPrefs.GetInt("level" + Global.currentLevel) < 2)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 2);
			}
			else if (PlayerPrefs.GetInt("level" + Global.currentLevel) < 1)
			{
				PlayerPrefs.SetInt("level" + Global.currentLevel, 1);
			}
			if (Global.TotalbirdCount - Global.birdCount > 1 || Global.currentLevel == 213 || Global.currentLevel == 135)
			{
				ShowStars(3);
			}
			else if (Global.TotalbirdCount - Global.birdCount > 0)
			{
				ShowStars(2);
			}
			else
			{
				ShowStars(1);
			}
		}
		if (null != _explodable)
		{
			try
			{
				Invoke("explodebottle", 0.5f);
			}
			catch (Exception)
			{
			}
		}
	}

	private IEnumerator FindAllBottlesMoved()
	{
		bottlesfound = true;
		yield return new WaitForSeconds(0.3f);
		Pig[] bottles = UnityEngine.Object.FindObjectsOfType<Pig>();
		int totaleffected = 0;
		Pig[] array = bottles;
		foreach (Pig pig in array)
		{
			if (pig.GetComponent<Rigidbody2D>().velocity.magnitude > 1f)
			{
				totaleffected++;
			}
		}
		if (totaleffected >= bottles.Length)
		{
			Time.timeScale = 0.75f;
			UnityEngine.Debug.Log("totaleffected");
		}
		yield return new WaitForSeconds(0.25f);
		if (totaleffected >= bottles.Length)
		{
			Time.timeScale = 0.5f;
			UnityEngine.Debug.Log("totaleffected");
		}
		yield return new WaitForSeconds(0.25f);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		try
		{
			if (Global.count >= Global.target && gameOverPanel.activeSelf)
			{
				if (Global.currentLevel == 150 || Global.currentLevel == 224 || Global.currentLevel == 36)
				{
					GameManager.txt2.fontSize = 25;
					GameManager.txt2.lineSpacing = 1f;
					if (GameManager.retry2.activeSelf && !GameManager.levelup2.activeSelf)
					{
						GameManager.levelup2.SetActive(value: true);
					}
				}
				else if (GameManager.retry2.activeSelf)
				{
					UnityEngine.Debug.Log("TTRWERTWEYWERYWREYWEY");
					if (!GameManager.levelup2.activeSelf)
					{
						GameManager.levelup2.SetActive(value: true);
					}
				}
			}
		}
		catch (Exception)
		{
		}
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

	private IEnumerator DestroyAfterDelay(float delay, Explodable _explodable)
	{
		yield return new WaitForSeconds(delay);
		_explodable.deleteFragments();
	}

	public void ShowStars(int count)
	{
		UnityEngine.Debug.Log("Show Stars" + count);
		for (int i = 0; i < count; i++)
		{
			stars[i].SetActive(value: true);
			stars[i].transform.DOLookAt(Vector3.back, 0.8f).From().SetDelay((float)i * 0.42f)
				.SetEase(Ease.OutBounce)
				.OnComplete(PlayStarSound);
			stars[i].transform.DOLocalMoveY(500f, 1.2f).From().SetDelay((float)i * 0.3f + 0.5f)
				.SetEase(Ease.OutBounce);
			stars[i].transform.DOScale(0f, 1.2f).From().SetDelay((float)i * 0.5f + 0.5f)
				.SetEase(Ease.OutCirc);
		}
	}

	private void PlayStarSound()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			SoundsHandler.Instance.PlaySource1Clip(0, 0f);
		}
	}
}
