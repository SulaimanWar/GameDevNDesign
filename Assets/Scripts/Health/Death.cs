using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public string levelToLoad;
    public bool restartThisLevel;


    public void LoadLevel()
    {
        if (restartThisLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
