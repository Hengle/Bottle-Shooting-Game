using UnityEngine;

public class BreakBrick : MonoBehaviour
{
	private Explodable _explodable;

	private void Start()
	{
		_explodable = GetComponent<Explodable>();
	}

	private void explodebottle()
	{
		_explodable.explode();
		ExplosionForce explosionForce = UnityEngine.Object.FindObjectOfType<ExplosionForce>();
		explosionForce.doExplosion(base.transform.position);
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Bird" && null != _explodable)
		{
			Invoke("explodebottle", 0.5f);
		}
	}

	private void Update()
	{
	}
}
