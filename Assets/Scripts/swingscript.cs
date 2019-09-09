using UnityEngine;

public class swingscript : MonoBehaviour
{
	public Rigidbody2D body2d;

	public float leftPushRange;

	public float rightPushRange;

	public float velocityThreshold;

	private void Start()
	{
		body2d = GetComponent<Rigidbody2D>();
		body2d.angularVelocity = velocityThreshold;
	}

	private void Update()
	{
		Push();
	}

	public void Push()
	{
		Quaternion rotation = base.transform.rotation;
		if (rotation.z > 0f)
		{
			Quaternion rotation2 = base.transform.rotation;
			if (rotation2.z < rightPushRange && body2d.angularVelocity > 0f && body2d.angularVelocity < velocityThreshold)
			{
				body2d.angularVelocity = velocityThreshold;
				return;
			}
		}
		Quaternion rotation3 = base.transform.rotation;
		if (rotation3.z < 0f)
		{
			Quaternion rotation4 = base.transform.rotation;
			if (rotation4.z > leftPushRange && body2d.angularVelocity < 0f && body2d.angularVelocity > velocityThreshold * -1f)
			{
				body2d.angularVelocity = velocityThreshold * -1f;
			}
		}
	}
}
