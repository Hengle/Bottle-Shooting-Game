using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private Image loaderImage;

	private Canvas thisCanvas;

	private static SceneLoader Instance;

	private Vector2 pos;

	private Vector2 viewportPoint;

	[SerializeField]
	private RectTransform rectTransform;

	[SerializeField]
	private RectTransform ballRect;

	[CompilerGenerated]
	private static TweenCallback _003C_003Ef__mg_0024cache0;

	[CompilerGenerated]
	private static TweenCallback _003C_003Ef__mg_0024cache1;

	private void Awake()
	{
		Instance = this;
		thisCanvas = GetComponent<Canvas>();
		thisCanvas.enabled = false;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnEnable()
	{
		if (Global.currentLevel >= 1)
		{
			pos = GameObject.Find("Bird Wait Position (1)").transform.position;
			viewportPoint = Camera.main.WorldToViewportPoint(pos);
			rectTransform.anchorMin = viewportPoint;
			rectTransform.anchorMax = viewportPoint;
		}
	}

	public static void LoadAScene(string _sceneName)
	{
		Vector3 endValue = new Vector3(0f, 0f, 180f);
		if (Instance != null && Instance.loaderImage != null && Instance.loaderImage.transform != null)
		{
			Instance.loaderImage.transform.localScale = Vector3.one * 1f;
			Instance.loaderImage.transform.DOLocalRotate(endValue, 1.5f);
			Instance.ballRect.transform.DOLocalMove(Instance.rectTransform.transform.localPosition, 1.5f);
			Instance.loaderImage.transform.DOScale(Vector3.zero, 1.5f).OnComplete(HideLoaderImage);
			Instance.loaderImage.transform.DOShakePosition(0.2f, 1f, 2).OnComplete(EnableCanvas);
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
	}

	private static void EnableCanvas()
	{
		Instance.thisCanvas.enabled = true;
	}

	private static void HideLoaderImage()
	{
		Vector3 endValue = new Vector3(0f, 0f, 0f);
		Instance.thisCanvas.enabled = false;
		Instance.loaderImage.transform.DOLocalRotate(endValue, 0f);
	}
}
