using UnityEngine;
using UnityEngine.UI;

public class TextLocalization : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Text>().text = getSkipLevelText();
	}

	private void Update()
	{
	}

	private string getSkipLevelText()
	{
		string result = "Watch video to\n skip level";
		if (Application.systemLanguage == SystemLanguage.French)
		{
			GetComponent<Text>().fontSize = 28;
			result = "Regarder la vidéo pour\nSauter niveau";
		}
		else if (Application.systemLanguage == SystemLanguage.Arabic)
		{
			GetComponent<Text>().fontStyle = FontStyle.Bold;
			result = "شاهد الفيديو لتخطي المستوى";
		}
		else if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			result = "Bekijk video naar\nsla level over";
		}
		else if (Application.systemLanguage == SystemLanguage.German)
		{
			GetComponent<Text>().fontSize = 22;
			result = "Sehen Sie sich das Video an\num die Ebene zu überspringen";
		}
		else if (Application.systemLanguage == SystemLanguage.Italian)
		{
			result = "Guarda il video \nper saltare il livello";
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			GetComponent<Text>().fontSize = 23;
			result = "レベルをスキップするために\nビデオを見る";
		}
		else if (Application.systemLanguage == SystemLanguage.Polish)
		{
			result = "Obejrzyj wideo, \naby pominąć poziom";
		}
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			result = "Assista ao vídeo \npara pular o nível";
		}
		else if (Application.systemLanguage == SystemLanguage.Russian)
		{
			GetComponent<Text>().fontSize = 22;
			GetComponent<Text>().fontStyle = FontStyle.Bold;
			result = "Смотреть видео,\nчтобы пропустить уровень";
		}
		else if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			result = "Ver video para saltar de nivel";
		}
		else if (Application.systemLanguage == SystemLanguage.Turkish)
		{
			result = "Seviyeyi atlamak için\nvideoyu izleyin";
		}
		else if (Application.systemLanguage == SystemLanguage.Chinese)
		{
			result = "观看视频以跳过级别";
		}
		return result;
	}
}
