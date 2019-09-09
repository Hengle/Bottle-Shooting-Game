using System;
using UnityEngine;

public static class GoEaseAnimationCurve
{
	public static Func<float, float, float, float, float> EaseCurve(GoTween tween)
	{
		if (tween == null)
		{
			UnityEngine.Debug.LogError("no tween to extract easeCurve from");
		}
		if (tween.easeCurve == null)
		{
			UnityEngine.Debug.LogError("no curve found for tween");
		}
		return (float t, float b, float c, float d) => tween.easeCurve.Evaluate(t / d) * c + b;
	}
}
