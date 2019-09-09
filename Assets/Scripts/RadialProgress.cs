using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
	public Image LoadingBar;

	private float currentValue;

	public float speed;

	private GameManager gm;

	private void Start()
	{
		gm = UnityEngine.Object.FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		if (currentValue < 100f)
		{
			currentValue += speed * Time.deltaTime;
		}
		LoadingBar.fillAmount = currentValue / 100f;
		if (currentValue > 100f)
		{
			gm.skipRewardVideo();
		}
	}
}
