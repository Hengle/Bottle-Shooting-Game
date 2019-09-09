using UnityEngine;
using UnityEngine.UI;

namespace AudienceNetwork
{
	public class AdChoices : MonoBehaviour
	{
		[Header("Ad Choices:")]
		[SerializeField]
		private Image image;

		[SerializeField]
		private Text text;

		[SerializeField]
		private CanvasGroup canvasGroup;

		private string linkURL;

		private void Awake()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
		}

		public void SetNativeAd(NativeAd nativeAd)
		{
			image.sprite = nativeAd.AdChoicesImage;
			text.text = nativeAd.AdChoicesText;
			linkURL = nativeAd.AdChoicesLinkURL;
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
		}

		public void AdChoicesTapped()
		{
			Application.OpenURL(linkURL);
		}
	}
}
