using AudienceNetwork;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdViewTest : MonoBehaviour
{
	public AdView adView;

	public AdPosition currentAdViewPosition;

	public Text headlineText;

	private void Awake()
	{
		headlineText.text += "  Point 1\n";
		AdView adView = new AdView("177562949545239_199005874067613", AdSize.BANNER_HEIGHT_50);
		headlineText.text = "  Point 2\n";
		this.adView = adView;
		headlineText.text += "  Point 3\n";
		this.adView.Register(base.gameObject);
		headlineText.text += "  Point 4\n";
		currentAdViewPosition = AdPosition.CUSTOM;
		this.adView.AdViewDidLoad = delegate
		{
			UnityEngine.Debug.Log("Ad view loaded.");
			this.adView.Show(100.0);
			headlineText.text += "  Point 5\n";
		};
		headlineText.text += "  Point 6\n";
		adView.AdViewDidFailWithError = delegate(string error)
		{
			UnityEngine.Debug.Log("Ad view failed to load with error: " + error);
			headlineText.text += "  Point 7\n";
		};
		adView.AdViewWillLogImpression = delegate
		{
			UnityEngine.Debug.Log("Ad view logged impression.");
			headlineText.text += "  Point 8\n";
		};
		adView.AdViewDidClick = delegate
		{
			UnityEngine.Debug.Log("Ad view clicked.");
			headlineText.text += "  Point 9\n";
		};
		adView.LoadAd();
		headlineText.text += "  Point10\n";
	}

	private void OnDestroy()
	{
		if ((bool)adView)
		{
			adView.Dispose();
		}
		UnityEngine.Debug.Log("AdViewTest was destroyed!");
	}

	public void NextScene()
	{
		SceneManager.LoadScene("NativeAdScene");
	}

	public void ChangePosition()
	{
		switch (currentAdViewPosition)
		{
		case AdPosition.TOP:
			adView.Show(AdPosition.BOTTOM);
			currentAdViewPosition = AdPosition.BOTTOM;
			break;
		case AdPosition.BOTTOM:
			adView.Show(100.0);
			currentAdViewPosition = AdPosition.CUSTOM;
			break;
		case AdPosition.CUSTOM:
			adView.Show(AdPosition.TOP);
			currentAdViewPosition = AdPosition.TOP;
			break;
		}
	}
}
