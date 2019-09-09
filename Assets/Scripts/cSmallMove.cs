using UnityEngine;

public class cSmallMove : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform transfB;

	private Vector3 posA;

	private Vector3 posB;

	private Vector3 nextPosition;

	private Vector3 nextLoopStart;

	[SerializeField]
	private Transform childTransf;

	[SerializeField]
	private Transform nextLoopObj;

	private void Start()
	{
		posA = childTransf.localPosition;
		posB = transfB.localPosition;
		nextPosition = posB;
		nextLoopStart = nextLoopObj.localPosition;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		childTransf.localPosition = Vector3.MoveTowards(childTransf.localPosition, nextPosition, speed * Time.deltaTime);
		if ((double)Vector3.Distance(childTransf.localPosition, nextPosition) <= 0.1)
		{
			childTransf.localPosition = nextLoopStart;
		}
	}

	private void changeDestination()
	{
		nextPosition = ((!(nextPosition != posA)) ? posB : posA);
	}
}
