using UnityEngine;

public class HintActive : MonoBehaviour
{
	public GameObject hintLine;

	public GameObject bottle1;

	public GameObject bottle2;

	public GameObject bottle3;

	public bool firstTime = true;

	private void Start()
	{
	}

	private void Update()
	{
		if (bottle1 == null && bottle2 == null && bottle3 == null && firstTime)
		{
			hintLine.SetActive(value: true);
			firstTime = false;
		}
	}
}
