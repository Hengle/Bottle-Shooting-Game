using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	public float timeLeft = 1.5f;

	public Text countdown;

	private GameManager gm;

	private void Start()
	{
		StartCoroutine("LoseTime");
		Time.timeScale = 1f;
		gm = UnityEngine.Object.FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		countdown.text = string.Empty + timeLeft;
		if (timeLeft < 1f)
		{
			GameScript.isGameOver = true;
		}
	}

	private IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			timeLeft -= 1f;
		}
	}
}
