using System.Collections;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
	private AudioSource audioSource;

	private Explodable _explodable;

	[SerializeField]
	public int count;

	private bool firstTime = true;

	private void Start()
	{
	}

	private void explodebottle()
	{
		_explodable.explode();
		ExplosionForce explosionForce = UnityEngine.Object.FindObjectOfType<ExplosionForce>();
		explosionForce.doExplosion(base.transform.position);
		Global.brokenBotList.Add(_explodable);
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		firstTime = false;
		if (target.gameObject.tag == "Brick" && null != _explodable)
		{
			Invoke("explodebottle", 0.5f);
		}
	}

	private void Update()
	{
	}

	private IEnumerator DestroyAfterDelay(float delay, Explodable _explodable)
	{
		yield return new WaitForSeconds(delay);
		_explodable.deleteFragments();
	}
}
