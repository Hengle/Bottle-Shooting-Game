using UnityEngine;

public class RenderText : MonoBehaviour
{
	private int fadeTime = 10;

	private bool isFading;

	private float startTime;

	private float timeLeft;

	public Color textColor = Color.black;

	private void Start()
	{
		if (Global.currentLevel == 25 || Global.currentLevel == 28)
		{
			if (Application.systemLanguage == SystemLanguage.English)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Bottles should not fall in water\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.French)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Les bouteilles ne devraient pas\n          tomber dans l'eau\n                    ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Arabic)
			{
				base.gameObject.GetComponent<TextMesh>().text = "يجب ألا تقع الزجاجات في الماء\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Dutch)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Flessen mogen niet in water vallen\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.German)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Flaschen sollten nichtins Wasser\n                   fallen\n                    ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Italian)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Le bottiglie non dovrebbero cadere\n                   in acqua\n                    ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Japanese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "ボトルは水に落ちてはいけません\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Polish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Butelki nie powinny spaść do wody\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Portuguese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Garrafas não devem cair na água\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Russian)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Бутылки не должны падать в воду\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Spanish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Las botellas no deben caer en el agua\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Turkish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Şişeler suya düşmemelidir\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Chinese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "          瓶不应该落入水中\n                    ↓↓↓\n                     ↓↓";
			}
		}
		if (Global.currentLevel == 27)
		{
			if (Application.systemLanguage == SystemLanguage.English)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Bottles should not fall in water\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.French)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Les bouteilles ne devraient pas\n          tomber dans l'eau\n            ↓↓↓                         ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Arabic)
			{
				base.gameObject.GetComponent<TextMesh>().text = "يجب ألا تقع الزجاجات في الماء\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Dutch)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Flessen mogen niet in water vallen\n                    ↓↓↓\n                     ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.German)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Flaschen sollten nichtins Wasser\n                   fallen\n            ↓↓↓                         ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Italian)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Le bottiglie non dovrebbero cadere\n                   in acqua\n            ↓↓↓                         ↓↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Japanese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "ボトルは水に落ちてはいけません\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Polish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Butelki nie powinny spaść do wody\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Portuguese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Garrafas não devem cair na água\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Russian)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Бутылки не должны падать в воду\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Spanish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Las botellas no deben caer en el agua\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Turkish)
			{
				base.gameObject.GetComponent<TextMesh>().text = "Şişeler suya düşmemelidir\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
			else if (Application.systemLanguage == SystemLanguage.Chinese)
			{
				base.gameObject.GetComponent<TextMesh>().text = "          瓶不应该落入水中\n            ↓↓↓                         ↓↓↓                           \n             ↓↓                          ↓↓";
			}
		}
		base.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
		base.gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;
		StartFading(fadeTime);
	}

	private void Update()
	{
		float num = Time.time - startTime;
		timeLeft = (float)fadeTime - num;
		if (timeLeft > 0f)
		{
			float a = timeLeft / (float)fadeTime;
			Color color = base.gameObject.GetComponent<MeshRenderer>().material.color;
			color.a = a;
			base.gameObject.GetComponent<MeshRenderer>().material.color = color;
		}
	}

	public void StartFading(int fadeTimeInput)
	{
		fadeTime = fadeTimeInput;
		startTime = Time.time;
	}
}
