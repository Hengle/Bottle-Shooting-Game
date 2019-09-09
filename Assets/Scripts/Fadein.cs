using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
	private Image rend;

	private void Start()
	{
		rend = GetComponent<Image>();
		Color color = rend.material.color;
		color.a = 0f;
		rend.material.color = color;
	}

	private IEnumerator FadeIn()
	{
		for (float f = 0.05f; f <= 1f; f += 0.05f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void startFadin()
	{
		StartCoroutine("FadeIn");
	}

	private void Update()
	{
		startFadin();
	}
}
