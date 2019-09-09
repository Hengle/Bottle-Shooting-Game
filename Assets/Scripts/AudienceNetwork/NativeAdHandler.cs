using UnityEngine;

namespace AudienceNetwork
{
	[RequireComponent(typeof(RectTransform))]
	public class NativeAdHandler : AdHandler
	{
		public int minViewabilityPercentage;

		public float minAlpha;

		public int maxRotation;

		public int checkViewabilityInterval;

		public Camera camera;

		public FBNativeAdHandlerValidationCallback validationCallback;

		private float lastImpressionCheckTime;

		private bool impressionLogged;

		private bool shouldCheckImpression;

		public void startImpressionValidation()
		{
			if (!base.enabled)
			{
				base.enabled = true;
			}
			shouldCheckImpression = true;
		}

		public void stopImpressionValidation()
		{
			shouldCheckImpression = false;
		}

		private void OnGUI()
		{
			checkImpression();
		}

		private bool checkImpression()
		{
			float time = Time.time;
			float num = time - lastImpressionCheckTime;
			if (shouldCheckImpression && !impressionLogged && num > (float)checkViewabilityInterval)
			{
				lastImpressionCheckTime = time;
				GameObject gameObject = base.gameObject;
				Camera x = camera;
				if (x == null)
				{
					x = GetComponent<Camera>();
				}
				if (x == null)
				{
					x = Camera.main;
				}
				while (gameObject != null)
				{
					Canvas component = gameObject.GetComponent<Canvas>();
					if (component != null && component.renderMode == RenderMode.WorldSpace)
					{
						break;
					}
					if (!checkGameObjectViewability(x, gameObject))
					{
						if (validationCallback != null)
						{
							validationCallback(success: false);
						}
						return false;
					}
					gameObject = null;
				}
				if (validationCallback != null)
				{
					validationCallback(success: true);
				}
				impressionLogged = true;
			}
			return impressionLogged;
		}

		private bool logViewability(bool success, string message)
		{
			if (!success)
			{
				UnityEngine.Debug.Log("Viewability validation failed: " + message);
			}
			else
			{
				UnityEngine.Debug.Log("Viewability validation success! " + message);
			}
			return success;
		}

		private bool checkGameObjectViewability(Camera camera, GameObject gameObject)
		{
			if (gameObject == null)
			{
				return logViewability(success: false, "GameObject is null.");
			}
			if (camera == null)
			{
				return logViewability(success: false, "Camera is null.");
			}
			if (!gameObject.activeInHierarchy)
			{
				return logViewability(success: false, "GameObject is not active in hierarchy.");
			}
			Canvas canvas = getCanvas(gameObject);
			if (canvas == null)
			{
				return logViewability(success: false, "GameObject is missing a Canvas parent.");
			}
			CanvasGroup[] components = gameObject.GetComponents<CanvasGroup>();
			CanvasGroup[] array = components;
			foreach (CanvasGroup canvasGroup in array)
			{
				if (canvasGroup.alpha < minAlpha)
				{
					return logViewability(success: false, "GameObject has a CanvasGroup with less than the minimum alpha required.");
				}
			}
			RectTransform rectTransform = gameObject.transform as RectTransform;
			if (rectTransform.rect.width <= 0f || rectTransform.rect.height <= 0f)
			{
				return logViewability(success: false, "GameObject's height/width is less than or equal to zero.");
			}
			Vector3[] array2 = new Vector3[4];
			rectTransform.GetWorldCorners(array2);
			Vector3 position = array2[0];
			Vector3 position2 = array2[2];
			Vector3 vector = camera.pixelRect.min;
			Vector3 vector2 = camera.pixelRect.max;
			if (canvas.renderMode != 0)
			{
				position = camera.WorldToScreenPoint(position);
				position2 = camera.WorldToScreenPoint(position2);
			}
			if (position.x < vector.x || position2.x > vector2.x)
			{
				return logViewability(success: false, "Less than 100% of the width of the GameObject is inside the viewport.");
			}
			int num = (int)(camera.pixelRect.height * (float)(100 - minViewabilityPercentage) / 100f);
			if (vector2.y - position2.y > (float)num)
			{
				return logViewability(success: false, "Less than " + minViewabilityPercentage + "% visible from the top.");
			}
			if (position.y - vector.y > (float)num)
			{
				return logViewability(success: false, "Less than " + minViewabilityPercentage + "% visible from the bottom.");
			}
			Vector3 eulerAngles = rectTransform.eulerAngles;
			int num2 = Mathf.FloorToInt(eulerAngles.x);
			int num3 = Mathf.FloorToInt(eulerAngles.y);
			int num4 = Mathf.FloorToInt(eulerAngles.z);
			int num5 = 360 - maxRotation;
			int num6 = maxRotation;
			if (num2 < num5 && num2 > num6)
			{
				return logViewability(success: false, "GameObject is rotated too much. (x axis)");
			}
			if (num3 < num5 && num3 > num6)
			{
				return logViewability(success: false, "GameObject is rotated too much. (y axis)");
			}
			if (num4 < num5 && num4 > num6)
			{
				return logViewability(success: false, "GameObject is rotated too much. (z axis)");
			}
			return logViewability(success: true, "--------------- VALID IMPRESSION REGISTERED! ----------------------");
		}

		private Canvas getCanvas(GameObject gameObject)
		{
			if (gameObject.GetComponent<Canvas>() != null)
			{
				return gameObject.GetComponent<Canvas>();
			}
			if (gameObject.transform.parent != null)
			{
				return getCanvas(gameObject.transform.parent.gameObject);
			}
			return null;
		}
	}
}
