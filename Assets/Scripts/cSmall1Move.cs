using UnityEngine;

public class cSmall1Move : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform transfB;

	private Vector3 posA;

	private Vector3 posB;

	private Vector3 nextPosition;

	[SerializeField]
	private Transform childTransf;

	private void Start()
	{
		posA = childTransf.localPosition;
		posB = transfB.localPosition;
		nextPosition = posB;
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
			childTransf.localPosition = posA;
		}
	}
}
