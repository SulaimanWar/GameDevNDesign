using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Action", fileName = "action_")]
public class ActionData : ScriptableObject
{
    public Condition condition;

    [Space(20)]

    public string choiceText;
    public enum ActionType
    {
        DIALOGUE, ACTIVE, PASSCODE, DIE
    }
    public ActionType actionType;

    [Space(15)]

    [Header("DIALOGUE")]
    public DialogueData dialogueData;

    [Space(15)]

    [Header("ACTIVE")]
    public DialogueData nextDialogue;

    [Space(15)]

    [Header("PASSCODE")]
    public string passcode;
    public DialogueData passDialogueData;
    public DialogueData failDialogueData;
}

[Serializable]
public class Condition
{
    public bool haveCondition;
    public string playerPrefKey;

    public enum KeyType
    {
        FLOAT, INT, STRING
    }
    public KeyType keyType;

    public float targetFloatKey;
    public int targetIntKey;
    public string targetStringKey;
}
