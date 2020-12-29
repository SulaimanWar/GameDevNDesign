using UnityEngine;

public class Guide : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject popUpPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpPanel.SetActive(false);
        }
    }
}


