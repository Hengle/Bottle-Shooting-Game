using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class GoTweenUtils
{
	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache0;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache2;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache3;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache4;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache5;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache6;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache7;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache8;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache9;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheA;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheB;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheC;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheD;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheE;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cacheF;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache10;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache11;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache12;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache13;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache14;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache15;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache16;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache17;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache18;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache19;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1A;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1B;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1C;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1D;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1E;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache1F;

	[CompilerGenerated]
	private static Func<float, float, float, float, float> _003C_003Ef__mg_0024cache20;

	public static Func<float, float, float, float, float> easeFunctionForType(GoEaseType easeType, GoTween tween = null)
	{
		switch (easeType)
		{
		case GoEaseType.Linear:
			return GoEaseLinear.EaseNone;
		case GoEaseType.BackIn:
			return GoEaseBack.EaseIn;
		case GoEaseType.BackOut:
			return GoEaseBack.EaseOut;
		case GoEaseType.BackInOut:
			return GoEaseBack.EaseInOut;
		case GoEaseType.BounceIn:
			return GoEaseBounce.EaseIn;
		case GoEaseType.BounceOut:
			return GoEaseBounce.EaseOut;
		case GoEaseType.BounceInOut:
			return GoEaseBounce.EaseInOut;
		case GoEaseType.CircIn:
			return GoEaseCircular.EaseIn;
		case GoEaseType.CircOut:
			return GoEaseCircular.EaseOut;
		case GoEaseType.CircInOut:
			return GoEaseCircular.EaseInOut;
		case GoEaseType.CubicIn:
			return GoEaseCubic.EaseIn;
		case GoEaseType.CubicOut:
			return GoEaseCubic.EaseOut;
		case GoEaseType.CubicInOut:
			return GoEaseCubic.EaseInOut;
		case GoEaseType.ElasticIn:
			return GoEaseElastic.EaseIn;
		case GoEaseType.ElasticOut:
			return GoEaseElastic.EaseOut;
		case GoEaseType.ElasticInOut:
			return GoEaseElastic.EaseInOut;
		case GoEaseType.Punch:
			return GoEaseElastic.Punch;
		case GoEaseType.ExpoIn:
			return GoEaseExponential.EaseIn;
		case GoEaseType.ExpoOut:
			return GoEaseExponential.EaseOut;
		case GoEaseType.ExpoInOut:
			return GoEaseExponential.EaseInOut;
		case GoEaseType.QuadIn:
			return GoEaseQuadratic.EaseIn;
		case GoEaseType.QuadOut:
			return GoEaseQuadratic.EaseOut;
		case GoEaseType.QuadInOut:
			return GoEaseQuadratic.EaseInOut;
		case GoEaseType.QuartIn:
			return GoEaseQuartic.EaseIn;
		case GoEaseType.QuartOut:
			return GoEaseQuartic.EaseOut;
		case GoEaseType.QuartInOut:
			return GoEaseQuartic.EaseInOut;
		case GoEaseType.QuintIn:
			return GoEaseQuintic.EaseIn;
		case GoEaseType.QuintOut:
			return GoEaseQuintic.EaseOut;
		case GoEaseType.QuintInOut:
			return GoEaseQuintic.EaseInOut;
		case GoEaseType.SineIn:
			return GoEaseSinusoidal.EaseIn;
		case GoEaseType.SineOut:
			return GoEaseSinusoidal.EaseOut;
		case GoEaseType.SineInOut:
			return GoEaseSinusoidal.EaseInOut;
		case GoEaseType.AnimationCurve:
			return GoEaseAnimationCurve.EaseCurve(tween);
		default:
			return GoEaseLinear.EaseNone;
		}
	}

	public static T setterForProperty<T>(object targetObject, string propertyName)
	{
		PropertyInfo property = targetObject.GetType().GetProperty(propertyName);
		if (property == null)
		{
			UnityEngine.Debug.Log("could not find property with name: " + propertyName);
			return default(T);
		}
		return (T)(object)Delegate.CreateDelegate(typeof(T), targetObject, property.GetSetMethod());
	}

	public static T getterForProperty<T>(object targetObject, string propertyName)
	{
		PropertyInfo property = targetObject.GetType().GetProperty(propertyName);
		if (property == null)
		{
			UnityEngine.Debug.Log("could not find property with name: " + propertyName);
			return default(T);
		}
		return (T)(object)Delegate.CreateDelegate(typeof(T), targetObject, property.GetGetMethod());
	}

	public static Color unclampedColorLerp(Color c1, Color diff, float value)
	{
		return new Color(c1.r + diff.r * value, c1.g + diff.g * value, c1.b + diff.b * value, c1.a + diff.a * value);
	}

	public static Vector2 unclampedVector2Lerp(Vector2 v1, Vector2 diff, float value)
	{
		return new Vector2(v1.x + diff.x * value, v1.y + diff.y * value);
	}

	public static Vector3 unclampedVector3Lerp(Vector3 v1, Vector3 diff, float value)
	{
		return new Vector3(v1.x + diff.x * value, v1.y + diff.y * value, v1.z + diff.z * value);
	}

	public static Vector4 unclampedVector4Lerp(Vector4 v1, Vector4 diff, float value)
	{
		return new Vector4(v1.x + diff.x * value, v1.y + diff.y * value, v1.z + diff.z * value, v1.w + diff.w * value);
	}
}
