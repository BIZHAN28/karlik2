using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSequence
{
    // Загрузка обычных сцен
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene("Scene" + index, LoadSceneMode.Single);
    }

    // Загрузка сцены паузы поверх текущей
    public static void LoadPauseSceneAdditive()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    // Возврат к предыдущей сцене
    public static void UnloadPauseScene()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }
}

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame(){
        Application.Quit();
    }

	public void GoToMenu(){
		SceneManager.LoadScene(0);
	}

    public void ResumeGame(){
        Time.timeScale = 1;
		SceneSequence.UnloadPauseScene();
	}

    public void PauseGame(){
        Time.timeScale = 0;
		SceneSequence.LoadPauseSceneAdditive();
	}
}
