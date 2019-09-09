using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : CommonUIActions
{
	[SerializeField]
	private UiElementSet topElements;

	[SerializeField]
	private UiElementSet bottomElements;

	[SerializeField]
	private UiElementSet leftElements;

	[SerializeField]
	private UiElementSet rightElements;

	[SerializeField]
	private UiElementSet onlyFadeElements;

	[SerializeField]
	private UiElementSet AnimElements;

	[SerializeField]
	private UiElementSet scaleElements;

	[SerializeField]
	private Ease momentEaseIn = Ease.OutBack;

	[SerializeField]
	private Ease momentEaseOut = Ease.OutBounce;

	private float outDelay = 0.1f;

	[SerializeField]
	private bool needFade = true;

	[SerializeField]
	private bool IsScaleAnim;

	private void OnEnable()
	{
		TweenInAllElements();
	}

	private void OnDisable()
	{
	}

	public void TweenInAllElements()
	{
		for (int i = 0; i < topElements.elements.Length; i++)
		{
			if (topElements.needFade)
			{
				FadeIn(topElements.elements[i], topElements.Delay + topElements.elementsDelay * (float)i, topElements.time);
			}
			topElements.elements[i].localPosition += Vector3.up * topElements.distance;
			topElements.elements[i].DOLocalMove(topElements.elements[i].localPosition - Vector3.up * topElements.distance, topElements.time).SetDelay(topElements.Delay + topElements.elementsDelay * (float)i).SetEase(momentEaseIn);
		}
		for (int j = 0; j < bottomElements.elements.Length; j++)
		{
			if (bottomElements.needFade)
			{
				FadeIn(bottomElements.elements[j], bottomElements.Delay + bottomElements.elementsDelay * (float)j, bottomElements.time);
			}
			bottomElements.elements[j].localPosition -= Vector3.up * bottomElements.distance;
			bottomElements.elements[j].DOLocalMove(bottomElements.elements[j].localPosition + Vector3.up * bottomElements.distance, bottomElements.time).SetDelay(bottomElements.Delay + bottomElements.elementsDelay * (float)j).SetEase(momentEaseIn);
		}
		for (int k = 0; k < leftElements.elements.Length; k++)
		{
			if (leftElements.needFade)
			{
				FadeIn(leftElements.elements[k], leftElements.Delay + leftElements.elementsDelay * (float)k, leftElements.time);
			}
			leftElements.elements[k].localPosition -= Vector3.right * leftElements.distance;
			leftElements.elements[k].DOLocalMove(leftElements.elements[k].localPosition + Vector3.right * leftElements.distance, leftElements.time).SetDelay(leftElements.Delay + leftElements.elementsDelay * (float)k).SetEase(momentEaseIn);
		}
		for (int l = 0; l < rightElements.elements.Length; l++)
		{
			if (rightElements.needFade)
			{
				FadeIn(rightElements.elements[l], rightElements.Delay + rightElements.elementsDelay * (float)l, rightElements.time);
			}
			rightElements.elements[l].localPosition += Vector3.right * rightElements.distance;
			rightElements.elements[l].DOLocalMove(rightElements.elements[l].localPosition - Vector3.right * rightElements.distance, rightElements.time).SetDelay(rightElements.Delay + rightElements.elementsDelay * (float)l).SetEase(momentEaseIn);
		}
		for (int m = 0; m < onlyFadeElements.elements.Length; m++)
		{
			FadeIn(onlyFadeElements.elements[m], onlyFadeElements.Delay + onlyFadeElements.elementsDelay * (float)m, onlyFadeElements.time);
		}
		ScaleAllElements();
	}

	public void TweenOutAllElements()
	{
		float num = 0f;
		for (int i = 0; i < topElements.elements.Length; i++)
		{
			if (topElements.needFade)
			{
				FadeOut(topElements.elements[i], topElements.Delay + topElements.elementsDelay * (float)i, topElements.time);
			}
			topElements.elements[i].DOLocalMove(topElements.elements[i].localPosition + Vector3.up * topElements.distance, topElements.time).SetEase(momentEaseOut);
			if (i == 0)
			{
				num += topElements.time;
			}
		}
		for (int j = 0; j < bottomElements.elements.Length; j++)
		{
			if (bottomElements.needFade)
			{
				FadeOut(bottomElements.elements[j], bottomElements.Delay + bottomElements.elementsDelay * (float)j, bottomElements.time);
			}
			bottomElements.elements[j].DOLocalMove(bottomElements.elements[j].localPosition - Vector3.up * bottomElements.distance, bottomElements.time).SetEase(momentEaseOut);
			if (j == 0)
			{
				num += bottomElements.time;
			}
		}
		for (int k = 0; k < leftElements.elements.Length; k++)
		{
			if (leftElements.needFade)
			{
				FadeOut(leftElements.elements[k], leftElements.Delay + leftElements.elementsDelay * (float)k, leftElements.time);
			}
			leftElements.elements[k].DOLocalMove(leftElements.elements[k].localPosition - Vector3.right * leftElements.distance, leftElements.time).SetEase(momentEaseOut);
			if (k == 0)
			{
				num += leftElements.time;
			}
		}
		for (int l = 0; l < rightElements.elements.Length; l++)
		{
			if (rightElements.needFade)
			{
				FadeOut(rightElements.elements[l], rightElements.Delay + rightElements.elementsDelay * (float)l, rightElements.time);
			}
			rightElements.elements[l].DOLocalMove(rightElements.elements[l].localPosition + Vector3.right * rightElements.distance, rightElements.time).SetEase(momentEaseOut);
			if (l == 0)
			{
				num += rightElements.time;
			}
		}
		for (int m = 0; m < onlyFadeElements.elements.Length; m++)
		{
			FadeOut(onlyFadeElements.elements[m], onlyFadeElements.Delay + onlyFadeElements.elementsDelay * (float)m, onlyFadeElements.time);
			if (m == 0)
			{
				num += onlyFadeElements.time;
			}
		}
		Invoke("OnCompleteTween", num + 0.2f);
	}

	public void ScaleAllElements()
	{
		for (int i = 0; i < scaleElements.elements.Length; i++)
		{
			scaleElements.elements[i].localScale = Vector3.zero;
			scaleElements.elements[i].DOScale(Vector3.one, scaleElements.time).SetDelay(scaleElements.Delay + scaleElements.elementsDelay * (float)i).SetEase(momentEaseIn);
		}
	}

	public virtual void OnCompleteTween()
	{
		for (int i = 0; i < topElements.elements.Length; i++)
		{
			topElements.elements[i].localPosition -= Vector3.up * topElements.distance;
		}
		for (int j = 0; j < bottomElements.elements.Length; j++)
		{
			bottomElements.elements[j].localPosition += Vector3.up * bottomElements.distance;
		}
		for (int k = 0; k < leftElements.elements.Length; k++)
		{
			leftElements.elements[k].localPosition += Vector3.right * leftElements.distance;
		}
		for (int l = 0; l < rightElements.elements.Length; l++)
		{
			rightElements.elements[l].localPosition -= Vector3.right * rightElements.distance;
		}
		base.gameObject.SetActive(value: false);
	}

	private void FadeIn(Transform gob, float delay, float _time)
	{
		if (needFade)
		{
			Image[] componentsInChildren = gob.GetComponentsInChildren<Image>();
			Text[] componentsInChildren2 = gob.GetComponentsInChildren<Text>();
			SpriteRenderer[] componentsInChildren3 = gob.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Color color = componentsInChildren[i].color;
				color.a = 0f;
				componentsInChildren[i].color = color;
				componentsInChildren[i].DOFade(1f, _time).SetDelay(delay).SetEase(momentEaseIn);
			}
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Color color2 = componentsInChildren2[j].color;
				color2.a = 0f;
				componentsInChildren2[j].color = color2;
				componentsInChildren2[j].DOFade(1f, _time).SetDelay(delay).SetEase(momentEaseIn);
			}
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				Color color3 = componentsInChildren3[k].color;
				color3.a = 0f;
				componentsInChildren3[k].color = color3;
				componentsInChildren3[k].DOFade(1f, _time).SetDelay(delay).SetEase(momentEaseIn);
			}
		}
	}

	public void FadeOut(Transform gob, float delay, float _time)
	{
		Image[] componentsInChildren = gob.GetComponentsInChildren<Image>();
		Text[] componentsInChildren2 = gob.GetComponentsInChildren<Text>();
		SpriteRenderer[] componentsInChildren3 = gob.GetComponentsInChildren<SpriteRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].DOFade(0f, _time).SetDelay(outDelay - outDelay).SetEase(momentEaseOut);
		}
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			componentsInChildren2[j].DOFade(0f, _time).SetDelay(outDelay - outDelay).SetEase(momentEaseOut);
		}
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			componentsInChildren3[k].DOFade(0f, _time).SetDelay(outDelay - outDelay).SetEase(momentEaseOut);
		}
	}

	public void ScaleLoopObjects()
	{
		if (IsScaleAnim)
		{
			for (int i = 0; i < AnimElements.elements.Length; i++)
			{
				AnimElements.elements[i].DOPunchScale(Vector3.one * 0.1f, 1f, 1).SetLoops(-1, LoopType.Yoyo);
			}
		}
	}

	public void StopScaleLoopObjects()
	{
		for (int i = 0; i < AnimElements.elements.Length; i++)
		{
			AnimElements.elements[i].DOKill();
		}
	}
}
