using UnityEngine;

public class MovePlanks11 : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform positionB;

	private Vector3 posA;

	private Vector3 posB;

	private Vector3 posC;

	private Vector3 nextPosition;

	[SerializeField]
	private Transform positionA;

	[SerializeField]
	private Transform positionC;

	private void Start()
	{
		posA = positionA.localPosition;
		posB = positionB.localPosition;
		posC = positionC.localPosition;
		nextPosition = posB;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		positionA.localPosition = Vector3.MoveTowards(positionA.localPosition, nextPosition, speed * Time.deltaTime);
		if ((double)Vector3.Distance(positionA.localPosition, nextPosition) <= 0.1)
		{
			changeDestination();
		}
	}

	private void changeDestination()
	{
		nextPosition = ((!(nextPosition != posB)) ? posC : posB);
	}
}
