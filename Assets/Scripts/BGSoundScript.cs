using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
	private static BGSoundScript instance;

	public static BGSoundScript Instance => instance;

	private void Start()
	{
	}

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
	}
}
