using UnityEngine;

public class moveToRight : MonoBehaviour
{
	private float time;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform bottle1;

	[SerializeField]
	private Transform bottle2;

	[SerializeField]
	private Transform bottle3;

	[SerializeField]
	private Transform bottle4;

	private Vector3 posB;

	private Vector3 nextPosition;

	[SerializeField]
	private Transform targetPosObj;

	private void Start()
	{
		time = Time.time;
		posB = targetPosObj.localPosition;
		nextPosition = posB;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		if (bottle1 != null && Time.time > time + 2f)
		{
			bottle1.localPosition = Vector3.MoveTowards(bottle1.localPosition, nextPosition, speed * Time.deltaTime);
		}
		if (bottle2 != null && Time.time > time + 10f)
		{
			bottle2.localPosition = Vector3.MoveTowards(bottle2.localPosition, nextPosition, speed * Time.deltaTime);
		}
		if (bottle3 != null && Time.time > time + 18f)
		{
			bottle3.localPosition = Vector3.MoveTowards(bottle3.localPosition, nextPosition, speed * Time.deltaTime);
		}
		if (bottle4 != null && Time.time > time + 24f)
		{
			bottle4.localPosition = Vector3.MoveTowards(bottle4.localPosition, nextPosition, speed * Time.deltaTime);
		}
	}
}
