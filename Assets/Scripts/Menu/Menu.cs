using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Options;

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel()
    {
        string curLevel = PlayerPrefs.GetString("CurLevel");
        if(curLevel == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        SceneManager.LoadScene(curLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        Options.SetActive(true);
    }
    public void Back()
    {
        Options.SetActive(false);
    }
}
