using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownSplash : MonoBehaviour
{
	public float timeLeft;

	public Text countdown;

	private Fadeoutsplash fadeScript;

	private void Start()
	{
		StartCoroutine("LoseTime");
		Time.timeScale = 1f;
		fadeScript = GetComponent<Fadeoutsplash>();
	}

	private void Update()
	{
		if (timeLeft < 1f)
		{
		}
		if (timeLeft == 1f)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
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
