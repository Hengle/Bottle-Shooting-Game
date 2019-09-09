using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
	public float parallaxFactor;

	private Vector3 previousCameraPosition;

	private void Start()
	{
		previousCameraPosition = Camera.main.transform.position;
	}

	private void Update()
	{
		Vector3 a = Camera.main.transform.position - previousCameraPosition;
		a.y = 0f;
		a.z = 0f;
		base.transform.position += a / parallaxFactor;
		previousCameraPosition = Camera.main.transform.position;
	}
}
