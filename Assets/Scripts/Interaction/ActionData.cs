using UnityEngine;

[CreateAssetMenu(menuName = "Data/Action", fileName = "action_")]
public class ActionData : ScriptableObject
{
    public string choiceText;
    public enum ActionType
    {
        DIALOGUE
    }
    public ActionType actionType;

    [Space(15)]

    [Header("DIALOGUE")]
    public DialogueData dialogueData;
}
