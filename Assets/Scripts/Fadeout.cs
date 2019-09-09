using UnityEngine;

public class Fadeout : MonoBehaviour
{
	private int fadeTime = 10;

	private bool isFading;

	private float startTime;

	private float timeLeft;

	private void Start()
	{
		startFading(12);
	}

	private void Update()
	{
		float num = Time.time - startTime;
		timeLeft = (float)fadeTime - num;
		if (timeLeft > 0f)
		{
			float a = timeLeft / (float)fadeTime;
			Color color = base.gameObject.GetComponent<SpriteRenderer>().color;
			color.a = a;
			base.gameObject.GetComponent<SpriteRenderer>().color = color;
		}
	}

	public void startFading(int fadeTimeInput)
	{
		fadeTime = fadeTimeInput;
		startTime = Time.time;
	}
}
