using System;
using UnityEngine;

[Serializable]
public class UiElementSet
{
	public Transform[] elements;

	public float distance = 500f;

	public float time = 0.4f;

	public float Delay;

	public float elementsDelay = 0.01f;

	public bool needFade = true;
}
