using UnityEngine;

public class SkipLvlClick : MonoBehaviour
{
	[SerializeField]
	private static GameObject skipLevelPopUp;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void showWatchVideoPopUp()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(skipLevelPopUp, base.transform);
		gameObject.transform.localScale = Vector3.one;
	}
}
