using UnityEngine;

public class GameScript : MonoBehaviour
{
	public static bool isGameOver;

	public static bool isReplay;

	public static string sceneName = "LEVEL_SELECT_new";

	private AudioSource audioSource1;

	public AudioClip Nmusic;

	private void Start()
	{
		isGameOver = false;
		isReplay = false;
	}

	private void GameOver()
	{
		isGameOver = true;
		isReplay = true;
	}
}
