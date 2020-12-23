using UnityEngine;

public class Clue : MonoBehaviour
{
    public enum ClueType
    {
        POPUP, HOLD
    }
    public ClueType clueType;

    [Header("POPUP")]
    public GameObject popupGO;
    public float stayUpTime = 3f;
    float closeTime;
    bool poppedUp;

    [Header("HOLD")]
    public GameObject holdGO;

    private void Start()
    {
        if(popupGO != null)
        {
            popupGO.SetActive(false);
        }

        if(holdGO != null)
        {
            holdGO.SetActive(false);
        }
    }

    public void ActivateClue()
    {
        switch (clueType)
        {
            case ClueType.POPUP:
                closeTime = Time.time + stayUpTime;
                popupGO.SetActive(true);
                poppedUp = true;
                break;

            case ClueType.HOLD:
                holdGO.SetActive(true);
                break;
        }
    }

    private void Update()
    {
        if (poppedUp)
        {
            if (Time.time > closeTime)
            {
                popupGO.SetActive(false);
                poppedUp = false;
            }
        }
    }
}