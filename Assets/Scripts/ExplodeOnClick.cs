using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
	private Explodable _explodable;

	private void Start()
	{
		_explodable = GetComponent<Explodable>();
	}

	private void OnMouseDown()
	{
	}
}
