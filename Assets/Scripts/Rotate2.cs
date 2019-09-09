using UnityEngine;

public class Rotate2 : MonoBehaviour
{
	public int degrees;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(Vector3.forward * degrees * Time.deltaTime);
	}
}
