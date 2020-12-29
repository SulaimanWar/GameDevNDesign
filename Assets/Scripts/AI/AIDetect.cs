using UnityEngine;
using UnityEngine.UI;

public class AIDetect : MonoBehaviour
{
    [HideInInspector] public bool detecting;
    public float detectRate = 2f;
    float detectMeter;
    bool detected;

    [Space(20)]

    public Slider detectBar;
    AIChase aiChase;

    private void Start()
    {
        aiChase = GetComponentInParent<AIChase>();
    }

    private void Update()
    {
        if (!detected)
        {
            if (detecting)
            {
                detectMeter += detectRate * Time.deltaTime;

                if (detectMeter > 100f)
                {
                    Detected();
                }
            }
            else
            {
                detectMeter -= (detectRate / 2) * Time.deltaTime;
            }

            detectBar.value = detectMeter / 100f;
        }
    }

    void Detected()
    {
        detected = true;
        aiChase.Chase();
    }

    public void ResetDetect()
    {
        detected = false;
    }
}