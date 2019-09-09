using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
	public delegate void musicStatus();

	public AudioSource MusicSource;

	public AudioSource AudioSource1;

	public AudioSource AudioSource2;

	public AudioClip[] music_clips;

	public AudioClip[] source1clips = new AudioClip[0];

	public AudioClip[] source2clips = new AudioClip[0];

	public static bool ismutemusic;

	public static bool ismutesound;

	public static SoundsHandler Instance;

	public bool PlayMusicDefault = true;

	public bool PlayMusicLoop = true;

	public float bgMusicDelay;

	private void Awake()
	{
		Instance = this;
		if (PlayMusicDefault)
		{
			PlayMusic(PlayMusicLoop, bgMusicDelay);
		}
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public void EnableSounds()
	{
		ismutesound = false;
		if ((bool)AudioSource1)
		{
			AudioSource1.enabled = true;
		}
		if ((bool)AudioSource2)
		{
			AudioSource2.enabled = true;
		}
		if ((bool)AudioSource1)
		{
			AudioSource1.mute = false;
		}
		if ((bool)AudioSource2)
		{
			AudioSource2.mute = false;
		}
	}

	public void DisableSounds()
	{
		ismutesound = true;
		if ((bool)AudioSource1)
		{
			AudioSource1.enabled = false;
		}
		if ((bool)AudioSource2)
		{
			AudioSource2.enabled = false;
		}
		if ((bool)AudioSource1)
		{
			AudioSource1.mute = true;
		}
		if ((bool)AudioSource2)
		{
			AudioSource2.mute = true;
		}
	}

	public void EnableMusic()
	{
		MusicSource.enabled = true;
		MusicSource.mute = false;
		ismutemusic = false;
		PlayMusic(sloop: true);
		MonoBehaviour.print("EnableMusic");
	}

	public void DisableMusic()
	{
		MonoBehaviour.print("DisableMusic");
		ismutemusic = true;
		MusicSource.enabled = false;
		MusicSource.mute = true;
	}

	public void PlayMusic(bool sloop, float _delay = 0f)
	{
		if (!ismutemusic)
		{
			MusicSource.clip = music_clips[0];
			MusicSource.loop = sloop;
			MusicSource.PlayDelayed(_delay);
		}
	}

	public void StopMusic()
	{
		if (!ismutemusic)
		{
			MusicSource.Stop();
		}
	}

	public void PlaySource1Clip(int clipindex, float delayy)
	{
		if (clipindex <= source1clips.Length && !ismutesound)
		{
			AudioSource1.clip = source1clips[clipindex];
			AudioSource1.PlayDelayed(delayy);
		}
	}

	public void PlaySource2Clip(int clipindex, float delayy)
	{
		if (clipindex <= source2clips.Length && !ismutesound && clipindex < source2clips.Length)
		{
			AudioSource2.clip = source2clips[clipindex];
			AudioSource2.PlayDelayed(delayy);
		}
	}
}
