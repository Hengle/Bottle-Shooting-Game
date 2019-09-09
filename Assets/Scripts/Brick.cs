using UnityEngine;

public class Brick : MonoBehaviour
{
	private AudioSource audioSource;

	public float health = 70f;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.GetComponent<Rigidbody2D>() == null)
		{
			return;
		}
		float num = target.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;
		if (num > 10f)
		{
			int @int = PlayerPrefs.GetInt("SOUND");
			if (@int == 1)
			{
				audioSource.Play();
			}
		}
		health -= num;
		if (health <= 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
