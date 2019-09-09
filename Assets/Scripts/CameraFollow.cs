using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[HideInInspector]
	public Vector3 startingPosition;

	private float minCameraX;

	private float maxCameraX = 12f;

	[HideInInspector]
	public bool isFollowing;

	[HideInInspector]
	public Transform birdToFollow;

	private void Awake()
	{
		startingPosition = base.transform.position;
		float x = Mathf.Clamp(1f, minCameraX, maxCameraX);
		base.transform.position = new Vector3(x, startingPosition.y, startingPosition.z);
	}

	private void Update()
	{
		if (isFollowing)
		{
			if (birdToFollow != null)
			{
				Vector3 position = birdToFollow.position;
				float x = Mathf.Clamp(position.x, minCameraX, maxCameraX);
				base.transform.position = new Vector3(x, startingPosition.y, startingPosition.z);
			}
			else
			{
				isFollowing = false;
			}
		}
	}
}
