using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	[HideInInspector]
	public AudioSource audio;

	[HideInInspector]
	public AudioSource BGMusic;

	[HideInInspector]
	public AudioSource Nmusic;

	[HideInInspector]
	public AudioSource Dmusic;

	[HideInInspector]
	public AudioSource Smusic;

	[HideInInspector]
	public AudioSource LevFail;

	[HideInInspector]
	public AudioSource LevClear;

	[HideInInspector]
	public AudioSource ClickSound;

	[HideInInspector]
	public AudioSource SlingPull;

	[HideInInspector]
	public AudioSource GroundTap;

	[HideInInspector]
	public AudioSource WoodTap;

	[HideInInspector]
	public AudioSource bottleBottle;

	[HideInInspector]
	public AudioSource ballToBottle;

	private static AudioManager instance;

	public static AudioManager Instance => instance;

	private void Start()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		BGMusic = components[0];
		Nmusic = components[1];
		Dmusic = components[2];
		Smusic = components[3];
		LevClear = components[4];
		LevFail = components[5];
		ClickSound = components[6];
		SlingPull = components[7];
		GroundTap = components[8];
		WoodTap = components[9];
		bottleBottle = components[10];
		ballToBottle = components[11];
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			if (!BGMusic.isPlaying)
			{
				BGMusic.Play();
			}
		}
		else
		{
			BGMusic.Stop();
		}
	}

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "LEVEL_SELECT_new" || SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Tutorial Scene")
		{
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1)
			{
				if (!BGMusic.isPlaying)
				{
					BGMusic.Play();
				}
				Nmusic.Stop();
				Dmusic.Stop();
				Smusic.Stop();
			}
			else
			{
				BGMusic.Stop();
			}
		}
		else
		{
			BGMusic.Stop();
		}
	}
}
