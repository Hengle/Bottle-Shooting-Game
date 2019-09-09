using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "ground")
		{
			Invoke("destritBox", 2f);
		}
	}

	private void destritBox()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
