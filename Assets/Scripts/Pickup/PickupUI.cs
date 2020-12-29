using UnityEngine;
using TMPro;


public class PickupUI : MonoBehaviour
{

    public TextMeshProUGUI text;
    public float displayTime = 3f;
    float targetTime;

    private void FixedUpdate()
    {
        if(Time.time > targetTime)
        {
            Destroy(gameObject);
        }
    }


    public void SetText(string targetText)
    {
        targetTime = Time.time + displayTime;
        text.text = targetText;
    }
}
