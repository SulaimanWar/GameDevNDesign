using UnityEngine;

public class ActionObject : MonoBehaviour
{
    public enum ActiveState
    {
        TOGGLE, ENABLED, DISABLED
    }



    [Header("ACTIVE")]
    public GameObject activeActionTarget;
    public ActiveState activeState;



    public void DoAction(ActionData actionData)
    {
        switch (actionData.actionType)
        {
            case ActionData.ActionType.ACTIVE:
                Active();
                GameObject targetGO = GameObject.Find(actionData.lookForString);
                SecondaryActive(targetGO);
                break;
        }
    }

    void Active()
    {
        if(activeActionTarget == null)
        {
            return;
        }

        switch (activeState)
        {
            case ActiveState.TOGGLE:
                activeActionTarget.SetActive(activeActionTarget.activeInHierarchy);
                break;

            case ActiveState.DISABLED:
                activeActionTarget.SetActive(false);
                break;

            case ActiveState.ENABLED:
                activeActionTarget.SetActive(true);
                break;
        }
    }

    void SecondaryActive(GameObject secondaryGO)
    {
        if(secondaryGO == null)
        {
            return;
        }

        switch (activeState)
        {
            case ActiveState.TOGGLE:
                secondaryGO.SetActive(activeActionTarget.activeInHierarchy);
                break;

            case ActiveState.DISABLED:
                secondaryGO.SetActive(false);
                break;

            case ActiveState.ENABLED:
                secondaryGO.SetActive(true);
                break;
        }
    }
}
