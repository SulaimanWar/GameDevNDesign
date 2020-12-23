using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Action", fileName = "action_")]
public class ActionData : ScriptableObject
{
    public Condition condition;

    public string choiceText;
    public enum ActionType
    {
        DIALOGUE, ACTIVE
    }
    public ActionType actionType;

    [Space(15)]

    [Header("DIALOGUE")]
    public DialogueData dialogueData;
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
