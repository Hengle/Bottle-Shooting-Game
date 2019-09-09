using UnityEngine;

public class Destroyer : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Bird" || target.tag == "Pig" || target.tag == "Brick")
		{
			UnityEngine.Object.Destroy(target.gameObject);
		}
	}
}
