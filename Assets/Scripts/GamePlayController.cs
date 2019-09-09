using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GamePlayController : MonoBehaviour
{
	private int score;

	public GameObject gamePausePanel;

	public GameObject pauseBtn;

	public GameObject replayBtn;

	public GameObject sound;

	public GameObject mute;

	private void Awake()
	{
		Application.targetFrameRate = 60;
	}

	public void Load(int level)
	{
		Global.tutorialDisplaye = true;
		Global.noOfTries++;
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && null != AudioManager.Instance)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Time.timeScale = 1f;
		Global.retryCount++;
		GameScript.sceneName = "LEVEL" + Global.currentLevel;
		GameScript.isReplay = true;
	}

	private void Start()
	{
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

	private void Update()
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

	public void GoToMain()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
	}

	public void UpdateScore()
	{
		score++;
	}

	public void pause()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Time.timeScale = 0f;
		pauseBtn.SetActive(value: false);
		replayBtn.SetActive(value: false);
		gamePausePanel.SetActive(value: true);
	}

	public void resume()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Time.timeScale = 1f;
		gamePausePanel.SetActive(value: false);
		pauseBtn.SetActive(value: true);
		replayBtn.SetActive(value: true);
	}

	public void Sound()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
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
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		sound.SetActive(value: false);
		mute.SetActive(value: true);
		PlayerPrefs.SetInt("SOUND", 0);
	}
}
