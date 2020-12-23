using UnityEngine;
using TMPro;

public class DialogueButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    DialogueObject dialogueObject;
    ActionData actionData;

    public void Setup(DialogueData dialogueData, int curLine, int curActionData, DialogueObject dialogueObj)
    {
        actionData = dialogueData.dialogueLines[curLine].actionData[curActionData];
        buttonText.text = actionData.choiceText;
        dialogueObject = dialogueObj;
    }

    public void Click()
    {
        switch (actionData.actionType)
        {
            case ActionData.ActionType.DIALOGUE:
                dialogueObject.SelectDialogue(actionData.dialogueData);
                return;
        }


        dialogueObject.DoAction(actionData);
    }
}
