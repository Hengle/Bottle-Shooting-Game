using System.Collections;
using UnityEngine;

public class LevelBuildup : MonoBehaviour
{
	public static LevelBuildup Instance;

	private Transform[] objs;

	[SerializeField]
	private GameObject effect;

	private void Start()
	{
		Instance = this;
		objs = base.transform.GetComponentsInChildren<Transform>();
		Transform[] array = objs;
		foreach (Transform transform in array)
		{
			if (transform != base.transform)
			{
				transform.gameObject.SetActive(value: false);
			}
		}
		if (Global.tutorialDisplaye || Global.currentLevel >= 2)
		{
			StartCoroutine(BuildIt());
		}
	}

	public IEnumerator BuildIt()
	{
		Transform[] array = objs;
		foreach (Transform tr in array)
		{
			tr.gameObject.SetActive(value: true);
			if (tr != base.transform)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(effect);
				gameObject.transform.position = tr.position;
				UnityEngine.Object.Destroy(gameObject, 2f);
			}
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void Update()
	{
	}
}
