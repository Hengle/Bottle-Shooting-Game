using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public GameObject gameOverPanel;

	private TrailRenderer lineRenderer;

	private Rigidbody2D myBody;

	private CircleCollider2D myCollider;

	private AudioSource audioSource;

	public bool birdTouch;

	private float orthoOrg;

	private float orthoCurr;

	private Vector3 posOrg;

	private Vector3 diffAdd;

	private int ballCollsionCount;

	private int groundCollisionCount;

	private float maximumVelo;

	public BirdState birdState
	{
		get;
		set;
	}

	private void Awake()
	{
		InitializeVariables();
	}

	private void Start()
	{
		orthoOrg = Camera.main.orthographicSize;
		orthoCurr = orthoOrg;
		posOrg = Camera.main.WorldToViewportPoint(base.transform.position);
	}

	private void Update()
	{
		Vector3 position = base.gameObject.transform.position;
		if (position.x > 30f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		float orthographicSize = Camera.main.orthographicSize;
		if (orthoCurr != orthographicSize)
		{
			orthoCurr = orthographicSize;
			if (birdState == BirdState.BeforeThrown)
			{
				base.transform.position = Camera.main.ViewportToWorldPoint(posOrg);
			}
		}
		if (birdState == BirdState.Thrown && myBody.velocity.sqrMagnitude <= GameVariables.MinVelocity)
		{
			StartCoroutine(DestroyAfterDelay(2f));
		}
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		Vector3 position = base.transform.position;
		if (!(position.x > -14f))
		{
			return;
		}
		Vector3 position2 = base.transform.position;
		if (!(position2.x < 25f))
		{
			return;
		}
		List<string> list = new List<string>();
		list.Add("ground");
		list.Add("pig");
		list.Add("borderwall");
		if (!list.Contains(target.gameObject.tag))
		{
			if (AudioManager.Instance != null)
			{
				AudioManager.Instance.GroundTap.pitch = myBody.velocity.magnitude / 0.1f;
			}
			ballCollsionCount++;
			if (myBody.velocity.magnitude > maximumVelo)
			{
				maximumVelo = myBody.velocity.magnitude;
			}
			if (ballCollsionCount < 5 && myBody.velocity.magnitude > 1.5f)
			{
				float value = myBody.velocity.sqrMagnitude / 10f;
				int @int = PlayerPrefs.GetInt("SOUND");
				if (@int == 1 && null != AudioManager.Instance)
				{
					AudioManager.Instance.GroundTap.volume = Mathf.Clamp(value, 0.1f, 4f);
					AudioManager.Instance.GroundTap.Play();
				}
			}
		}
		if (target.gameObject.tag == "ground")
		{
			groundCollisionCount++;
			if (groundCollisionCount < 7 && myBody.velocity.magnitude > 1.5f)
			{
				float value2 = myBody.velocity.sqrMagnitude / 10f;
				int int2 = PlayerPrefs.GetInt("SOUND");
				if (int2 == 1 && null != AudioManager.Instance)
				{
					AudioManager.Instance.WoodTap.volume = Mathf.Clamp(value2, 0.1f, 4f);
					AudioManager.Instance.WoodTap.Play();
				}
			}
		}
		if (target.gameObject.tag == "pig")
		{
			bool flag = true;
			int int3 = PlayerPrefs.GetInt("SOUND");
			if (int3 == 1 && null != AudioManager.Instance && flag)
			{
				flag = false;
			}
		}
	}

	private void FixedUpdate()
	{
		if (birdState == BirdState.Thrown && myBody.velocity.sqrMagnitude <= GameVariables.MinVelocity)
		{
			StartCoroutine(DestroyAfterDelay(2f));
		}
		else if (birdState == BirdState.Thrown)
		{
			if (Global.currentLevel == 118 || Global.currentLevel == 223)
			{
				Invoke("destroyball", 9.5f);
			}
			else
			{
				Invoke("destroyball", 7f);
			}
		}
	}

	private void InitializeVariables()
	{
		lineRenderer = GetComponent<TrailRenderer>();
		myBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<CircleCollider2D>();
		audioSource = GetComponent<AudioSource>();
		lineRenderer.enabled = false;
		lineRenderer.sortingLayerName = "Foreground";
		myBody.isKinematic = true;
		myCollider.radius = GameVariables.BirdColliderRadiusBig;
		birdState = BirdState.BeforeThrown;
	}

	public void OnThrow()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1)
		{
			audioSource.Play();
		}
		lineRenderer.enabled = true;
		myBody.isKinematic = false;
		myCollider.radius = GameVariables.BirdColliderRadiusNormal;
		birdState = BirdState.Thrown;
	}

	private IEnumerator DestroyAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		object[] anArray = Global.brokenBotList.ToArray();
		if (anArray != null && anArray.Length > 0)
		{
			for (int i = 0; i < anArray.Length; i++)
			{
				((Explodable)anArray[i]).deleteFragments();
			}
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void destroyball()
	{
		if (null != base.gameObject && base.gameObject.activeSelf)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
