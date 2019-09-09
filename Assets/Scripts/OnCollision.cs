using UnityEngine;

public class OnCollision : MonoBehaviour
{
	private bool collisionOver = true;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		UnityEngine.Debug.Log("COLLISION CO");
		if (target.gameObject.name == "bottle" && collisionOver)
		{
			UnityEngine.Debug.Log("COLLISION CO");
			target.transform.parent = base.transform;
			collisionOver = false;
		}
	}
}
