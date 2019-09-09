using UnityEngine;

public class CameraMove : MonoBehaviour
{
	private float dragSpeed = 0.01f;

	private float timeDragStarted;

	private Vector3 previousPosition;

	public SlingShot slingShot;

	private void Update()
	{
		if (slingShot.slingShootState != 0 || GameManager.gameState != GameState.Playing)
		{
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			timeDragStarted = Time.time;
			dragSpeed = 0f;
			previousPosition = UnityEngine.Input.mousePosition;
		}
		else if (Input.GetMouseButton(0) && Time.time - timeDragStarted > 0.005f)
		{
			Vector3 mousePosition = UnityEngine.Input.mousePosition;
			float num = (previousPosition.x - mousePosition.x) * dragSpeed;
			float num2 = (previousPosition.y - mousePosition.y) * dragSpeed;
			Vector3 position = base.transform.position;
			float num3 = Mathf.Clamp(position.x + num, 0f, 0f);
			Vector3 position2 = base.transform.position;
			float num4 = Mathf.Clamp(position2.y + num2, 0f, 2.7f);
			previousPosition = mousePosition;
			if (dragSpeed < 0.1f)
			{
				dragSpeed += 0.002f;
			}
		}
	}
}
