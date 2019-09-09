using UnityEngine;

public class Fadeoutsplash : MonoBehaviour
{
	private float fadeTime = 2f;

	private bool isFading;

	private float startTime;

	private float timeLeft;

	private void Start()
	{
		startFading(0.5f);
	}

	private void Update()
	{
		float num = Time.time - startTime;
		timeLeft = fadeTime - num;
		if (timeLeft > 0f)
		{
			float a = timeLeft / fadeTime;
			Color color = base.gameObject.GetComponent<SpriteRenderer>().color;
			color.a = a;
			base.gameObject.GetComponent<SpriteRenderer>().color = color;
		}
	}

	public void startFading(float fadeTimeInput)
	{
		fadeTime = fadeTimeInput;
		startTime = Time.time;
	}
}
