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
                break;
        }
    }

    void Active()
    {
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
}
