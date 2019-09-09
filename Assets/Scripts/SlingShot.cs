using System;
using System.Threading;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
	public delegate void BirdThrown();

	private Vector3 slingShootMiddleVector;

	[HideInInspector]
	public SlingshotState slingShootState;

	public Transform leftSlingShootOrigin;

	public Transform rightSlingShootOrigin;

	public Transform leftOrgin2;

	public Transform rightOrigin2;

	public LineRenderer slingShootLineRenderer1;

	public LineRenderer slingShootLineRenderer2;

	public LineRenderer trajectoryLineRenderer;

	public LineRenderer slingBeltRenderer;

	[HideInInspector]
	public GameObject birdToThrow;

	public Transform birdWaitPosition;

	public float throwSpeed;

	[HideInInspector]
	public float timeSinceThrown;

	private Touch firstTouch;

	public Vector2 dragDist;

	private bool ribbonPullSoundPlayed;

	private Vector2 segVelocity;

	private float _interval = 0.7f;

	[SerializeField]
	private bool oldLine = true;

	private float maxScale = 0.15f;

	private float scaleDecreaseRate = 0.01f;

	[SerializeField]
	private GameObject _dot;

	private GameObject[] spots;

	private bool created;

	private Transform[] objs;

	public event BirdThrown birdThrown;

	private void Awake()
	{
		Global.count = 0;
		Global.birdCount = 0;
		ribbonPullSoundPlayed = false;
		trajectoryLineRenderer.sortingLayerName = "Foreground";
		slingShootState = SlingshotState.Idle;
		slingShootLineRenderer1.SetPosition(0, leftSlingShootOrigin.position);
		slingShootLineRenderer2.SetPosition(0, rightSlingShootOrigin.position);
		Vector3 position = leftSlingShootOrigin.position;
		float x = position.x;
		Vector3 position2 = rightSlingShootOrigin.position;
		float x2 = (x + position2.x) / 2f;
		Vector3 position3 = leftSlingShootOrigin.position;
		float y = position3.y;
		Vector3 position4 = rightSlingShootOrigin.position;
		slingShootMiddleVector = new Vector3(x2, (y + position4.y) / 2f, 0f);
	}

	private void Update()
	{
		switch (slingShootState)
		{
		case SlingshotState.Idle:
			InitializeBird();
			DisplaySlingshootLineRenderers();
			if (Input.GetMouseButtonDown(0))
			{
				Vector3 v = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				if (birdToThrow.GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(v))
				{
					birdToThrow.GetComponent<CircleCollider2D>().radius = GameVariables.BirdColliderRadiusZero;
					slingShootState = SlingshotState.UserPulling;
				}
			}
			break;
		case SlingshotState.UserPulling:
			SetSlingshotLinerenderersActive(active: true);
			if (UnityEngine.Input.touchCount > 0)
			{
				firstTouch = UnityEngine.Input.GetTouch(0);
				if (UnityEngine.Input.GetTouch(0).phase == TouchPhase.Moved)
				{
					dragDist = firstTouch.deltaPosition;
					if (firstTouch.deltaPosition.magnitude / firstTouch.deltaTime > 150f && !ribbonPullSoundPlayed)
					{
						int @int = PlayerPrefs.GetInt("SOUND");
						if (@int == 1)
						{
							AudioManager.Instance.SlingPull.pitch = 1.5f;
							AudioManager.Instance.SlingPull.Play();
							ribbonPullSoundPlayed = true;
						}
					}
				}
			}
			DisplaySlingshootLineRenderers();
			if (Input.GetMouseButton(0))
			{
				Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				vector.z = 0f;
				float num = 1.5f;
				if (Global.currentLevel == 18)
				{
					num = 1.5f;
				}
				if (Vector3.Distance(vector, slingShootMiddleVector) > num)
				{
					Vector3 position = (vector - slingShootMiddleVector).normalized * num + slingShootMiddleVector;
					birdToThrow.transform.position = position;
				}
				else
				{
					birdToThrow.transform.position = vector;
				}
				float x = vector.x;
				Vector3 position2 = leftSlingShootOrigin.transform.position;
				if (x > position2.x)
				{
					float x2 = vector.x;
					Vector3 position3 = rightSlingShootOrigin.transform.position;
					if (x2 < position3.x + 0.2f)
					{
						float y = vector.y;
						Vector3 position4 = rightSlingShootOrigin.transform.position;
						if (y < position4.y - 0.7f)
						{
							birdToThrow.transform.position = birdWaitPosition.position;
						}
					}
				}
				float distance = Vector3.Distance(slingShootMiddleVector, birdToThrow.transform.position);
				DisplayTrajectoryLineRenderer(distance);
			}
			else
			{
				timeSinceThrown = Time.time;
				float num2 = Vector3.Distance(slingShootMiddleVector, birdToThrow.transform.position);
				if (num2 > 1f)
				{
					SetSlingshotLinerenderersActive(active: false);
					SetTrajectoryLineRendererActive(active: false);
					slingShootState = SlingshotState.BirdFlying;
					ThrowBird(num2);
				}
				else
				{
					birdToThrow.transform.positionTo(num2 / 10f, birdWaitPosition.position);
					InitializeBird();
				}
			}
			break;
		}
	}

	private void InitializeBird()
	{
		birdToThrow.transform.position = birdWaitPosition.position;
		slingShootState = SlingshotState.Idle;
		object[] array = Global.brokenBotList.ToArray();
		if (array != null && array.Length > 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				((Explodable)array[i]).deleteFragments();
			}
		}
	}

	public void SetSlingshotLinerenderersActive(bool active)
	{
		slingShootLineRenderer1.enabled = active;
		slingShootLineRenderer2.enabled = active;
		slingBeltRenderer.enabled = active;
	}

	private void DisplaySlingshootLineRenderers()
	{
		Vector3 position = birdToThrow.transform.position;
		float x = position.x;
		Vector3 position2 = birdToThrow.transform.position;
		float x2 = position2.x;
		Vector3 position3 = leftOrgin2.position;
		Vector2 v = default(Vector2);
		v.x = x + (x2 - position3.x) / Vector2.Distance(birdToThrow.transform.position, leftOrgin2.position) * 0.25f;
		Vector3 position4 = birdToThrow.transform.position;
		float y = position4.y;
		Vector3 position5 = birdToThrow.transform.position;
		float y2 = position5.y;
		Vector3 position6 = leftOrgin2.position;
		v.y = y + (y2 - position6.y) / Vector2.Distance(birdToThrow.transform.position, leftOrgin2.position) * 0.25f;
		slingShootLineRenderer1.SetPosition(1, v);
		slingShootLineRenderer2.SetPosition(1, v);
		Vector3 position7 = birdToThrow.transform.position;
		Vector3 position8 = default(Vector3);
		position8.x = position7.x;
		Vector3 position9 = birdToThrow.transform.position;
		position8.y = position9.y;
		position8.z = 0f;
		slingBeltRenderer.SetPosition(0, position8);
		slingBeltRenderer.SetPosition(1, v);
	}

	private void SetTrajectoryLineRendererActive(bool active)
	{
		trajectoryLineRenderer.enabled = active;
	}

	private void DisplayTrajectoryLineRenderer(float distance)
	{
		SetTrajectoryLineRendererActive(active: true);
		Vector3 vector = slingShootMiddleVector - birdToThrow.transform.position;
		int num = 25;
		Vector2[] array = new Vector2[num];
		array[0] = birdToThrow.transform.position;
		segVelocity = new Vector2(vector.x, vector.y) * throwSpeed * distance;
		for (int i = 1; i < num; i++)
		{
			float num2 = (float)i * Time.fixedDeltaTime * _interval;
			array[i] = array[0] + segVelocity * num2 + 0.5f * Physics2D.gravity * Mathf.Pow(num2, 2f);
		}
		if (oldLine)
		{
			trajectoryLineRenderer.SetVertexCount(num);
			for (int j = 0; j < num; j++)
			{
				trajectoryLineRenderer.SetPosition(j, array[j]);
			}
		}
		else
		{
			CreateDotsLine(array);
		}
		float num3 = Mathf.Abs(array[0].x - array[array.Length - 1].x);
		trajectoryLineRenderer.material.mainTextureScale = new Vector2(num3 * 0.25f, 1f);
	}

	private void CreateDotsLine(Vector2[] poses)
	{
		if (!created)
		{
			spots = new GameObject[poses.Length];
			for (int i = 0; i < poses.Length; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_dot);
				gameObject.transform.localScale = new Vector3(0.3f - (float)i * scaleDecreaseRate, 0.3f - (float)i * scaleDecreaseRate, 1f);
				spots[i] = gameObject;
			}
			created = true;
			spots[0].SetActive(value: false);
		}
		for (int j = 0; j < poses.Length; j++)
		{
			spots[j].transform.position = new Vector3(poses[j].x, poses[j].y, 0f);
		}
	}

	private void ClearDots()
	{
		if (!oldLine)
		{
			GameObject[] array = spots;
			foreach (GameObject obj in array)
			{
				UnityEngine.Object.Destroy(obj);
			}
			created = false;
		}
	}

	private void ThrowBird(float distance)
	{
		ClearDots();
		Global.birdCount++;
		Vector3 vector = slingShootMiddleVector - birdToThrow.transform.position;
		birdToThrow.GetComponent<Bird>().OnThrow();
		birdToThrow.GetComponent<Rigidbody2D>().velocity = new Vector2(vector.x, vector.y) * throwSpeed * distance;
		if (this.birdThrown != null)
		{
			this.birdThrown();
		}
		ribbonPullSoundPlayed = false;
		if (!(BirdAnimations.Instance != null))
		{
			return;
		}
		objs = BirdAnimations.Instance.GetComponentsInChildren<Transform>();
		GameManager gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
		if (gameManager.currentBirdIndex == 1)
		{
			Transform[] array = objs;
			foreach (Transform transform in array)
			{
				transform.transform.localPosition = new Vector2(4f, 1f);
			}
		}
		if (gameManager.currentBirdIndex == 2)
		{
			Transform[] array2 = objs;
			foreach (Transform transform2 in array2)
			{
				transform2.transform.localPosition = new Vector2(-2f, 2f);
			}
		}
		if (gameManager.currentBirdIndex == 3)
		{
			Transform[] array3 = objs;
			foreach (Transform transform3 in array3)
			{
				transform3.transform.localPosition = new Vector2(3f, -1f);
			}
		}
		if (gameManager.currentBirdIndex == 4)
		{
			Transform[] array4 = objs;
			foreach (Transform transform4 in array4)
			{
				transform4.transform.localPosition = new Vector2(-1f, 3f);
			}
		}
		BirdAnimations.Instance.PlayAnimations();
	}
}
