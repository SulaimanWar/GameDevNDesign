using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Dialogue", fileName = "dialogue_")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] dialogueLines;
}

[Serializable]
public class DialogueLine
{
    [TextArea]
    public string dialogue;
    public ActionData[] actionData;
}
