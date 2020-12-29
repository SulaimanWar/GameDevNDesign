using UnityEngine;
using UnityEngine.SceneManagement;

public class end: MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitToHome()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GamePaused = false;
        SceneManager.LoadScene("Main Menu");
    }
}

