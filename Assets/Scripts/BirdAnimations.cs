using UnityEngine;

public class BirdAnimations : MonoBehaviour
{
	public static BirdAnimations Instance;

	private ParticleSystem[] anims;

	private Transform[] objs;

	private GameManager gm;

	private SlingshotState bs;

	private void Start()
	{
		Instance = this;
		anims = base.transform.GetComponentsInChildren<ParticleSystem>();
	}

	public void PlayAnimations()
	{
		ParticleSystem[] array = anims;
		foreach (ParticleSystem particleSystem in array)
		{
			var _temp_val_677 = particleSystem.emission; _temp_val_677.enabled = true;
			particleSystem.Emit(1);
		}
	}
}
