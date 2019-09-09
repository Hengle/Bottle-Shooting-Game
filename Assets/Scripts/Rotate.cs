using UnityEngine;

public class Rotate : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(Vector3.forward * -180f * Time.deltaTime);
	}
}
