using UnityEngine;
using UnityEngine.UI;

public class LocalizatioWatchToContinue : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Text>().text = getText();
	}

	private void Update()
	{
	}

	private string getText()
	{
		string result = "Watch video to\n continue Playing..";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			GetComponent<Text>().fontSize = 25;
			result = "Regarder vidéo\n pour continuer à jouer ..";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			GetComponent<Text>().fontSize = 25;
			GetComponent<Text>().fontStyle = FontStyle.Bold;
			result = " شاهد  الفيديولمواصلة اللعب";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			GetComponent<Text>().fontSize = 20;
			result = "Bekijk video\n om door te gaan met spelen ..";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			result = "Schau Video\n weiter spielen ..";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			GetComponent<Text>().fontSize = 23;
			result = "Guarda un video\n per continuare a giocare ..";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			result = "ビデオを見る\n 遊び続けるために..";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			GetComponent<Text>().fontSize = 25;
			result = "Obejrzyj wideo\n aby kontynuować grę..";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			GetComponent<Text>().fontSize = 25;
			result = "Assista vídeo\n para continuar jogando..";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			GetComponent<Text>().fontSize = 25;
			GetComponent<Text>().fontStyle = FontStyle.Bold;
			result = "Смотреть видео на\n продолжить играть ..";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Ver video para\n sigue jugando ..";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "İçin Video İzle\n oynamaya devam et..";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "观看视频 继续玩..";
		}
		return result;
	}
}
