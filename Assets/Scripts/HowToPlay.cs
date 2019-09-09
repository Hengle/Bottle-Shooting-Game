using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
	public Text howToPlay;

	private void Start()
	{
		howToPlay.text = gettext();
	}

	private string gettext()
	{
		string result = "How to Play ";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			result = "Comment jouer";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			result = "كيف ألعب";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Hoe te spelen";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Spielanleitung";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Come giocare";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "遊び方";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Jak grać";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Como jogar";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			result = "Как играть";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Cómo jugar";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Seviye Temizlendi";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "怎么玩";
		}
		return result;
	}
}
