using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterTypes
    {
        Player,
        AI
    }

    [SerializeField] private CharacterTypes characterType;

    #if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    #endif

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "EnemyDetect")
        {
            AIDetect aiDetect = col.GetComponent<AIDetect>();
            aiDetect.detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "EnemyDetect")
        {
            AIDetect aiDetect = col.GetComponent<AIDetect>();
            aiDetect.detecting = false;
        }
    }
}