using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSetup : MonoBehaviour
{
    public string curLevel;

    private void Start()
    {
        curLevel = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurLevel", curLevel);
    }
}
