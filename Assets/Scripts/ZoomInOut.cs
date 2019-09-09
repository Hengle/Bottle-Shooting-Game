using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
	private Camera mainCamera;

	private float touchesPrevPosDifference;

	private float touchesCurPosDifference;

	private float zoomModifier;

	private float defaultSize;

	[HideInInspector]
	public BirdState birdState;

	private Vector2 firstTouchPrevPos;

	private Vector2 secondTouchPrevPos;

	[SerializeField]
	private float zoomModifierSpeed = 0.01f;

	[HideInInspector]
	public GameObject birdToThrow;

	public Transform birdWaitPosition;

	private void Start()
	{
		mainCamera = GetComponent<Camera>();
		defaultSize = mainCamera.orthographicSize;
	}

	private void FixedUpdate()
	{
		if (birdState != BirdState.Thrown && UnityEngine.Input.touchCount == 2)
		{
			Touch touch = UnityEngine.Input.GetTouch(0);
			Touch touch2 = UnityEngine.Input.GetTouch(1);
			firstTouchPrevPos = touch.position - touch.deltaPosition;
			secondTouchPrevPos = touch2.position - touch2.deltaPosition;
			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			touchesCurPosDifference = (touch.position - touch2.position).magnitude;
			zoomModifier = (touch.deltaPosition - touch2.deltaPosition).magnitude * zoomModifierSpeed;
			if (touchesPrevPosDifference > touchesCurPosDifference)
			{
				mainCamera.orthographicSize += zoomModifier;
			}
			if (touchesPrevPosDifference < touchesCurPosDifference)
			{
				mainCamera.orthographicSize -= zoomModifier;
			}
			mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, defaultSize, 10.5f);
		}
	}
}
