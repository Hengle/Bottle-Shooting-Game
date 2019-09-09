using UnityEngine;

public class boxFall : MonoBehaviour
{
	[SerializeField]
	private Transform box1;

	[SerializeField]
	private Transform box2;

	[SerializeField]
	private Transform box3;

	[SerializeField]
	private Transform box4;

	[SerializeField]
	private Transform box5;

	[SerializeField]
	private Transform box6;

	[SerializeField]
	private Transform box7;

	private float time;

	private void Start()
	{
		time = Time.time;
	}

	private void Update()
	{
		if ((double)Time.time > (double)time + 3.5)
		{
			box1.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 8f)
		{
			box2.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 12f)
		{
			box3.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 16f)
		{
			box4.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 20f)
		{
			box5.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 24f)
		{
			box6.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		if (Time.time > time + 28f)
		{
			box7.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
	}
}
