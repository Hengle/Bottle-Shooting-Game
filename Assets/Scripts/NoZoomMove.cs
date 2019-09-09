using UnityEngine;

public class NoZoomMove : MonoBehaviour
{
	private float orthoOrg;

	private float orthoCurr;

	private Vector3 posOrg;

	private Vector3 diffAdd;

	private void Start()
	{
		orthoOrg = Camera.main.orthographicSize;
		orthoCurr = orthoOrg;
		posOrg = Camera.main.WorldToViewportPoint(base.transform.position);
	}

	private void Update()
	{
		float orthographicSize = Camera.main.orthographicSize;
		if (orthoCurr != orthographicSize)
		{
			orthoCurr = orthographicSize;
			base.transform.position = Camera.main.ViewportToWorldPoint(posOrg);
		}
	}
}
