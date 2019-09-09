using System;

public static class GoEaseSinusoidal
{
	public static float EaseIn(float t, float b, float c, float d)
	{
		return (0f - c) * (float)Math.Cos((double)(t / d) * 1.5707963267948966) + c + b;
	}

	public static float EaseOut(float t, float b, float c, float d)
	{
		return c * (float)Math.Sin((double)(t / d) * 1.5707963267948966) + b;
	}

	public static float EaseInOut(float t, float b, float c, float d)
	{
		return (0f - c) / 2f * ((float)Math.Cos(3.1415926535897931 * (double)t / (double)d) - 1f) + b;
	}
}
