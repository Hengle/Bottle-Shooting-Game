using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GoToMenu()
	{
		Global.currentLevel = 1;
		Global.fromLevelSelection = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
