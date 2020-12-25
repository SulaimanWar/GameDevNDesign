using UnityEngine;
using TMPro;

public class DialogueButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    DialogueObject dialogueObject;
    ActionData actionData;

    public GameObject passcodeInput;

    public void Setup(DialogueData dialogueData, int curLine, int curActionData, DialogueObject dialogueObj)
    {
        actionData = dialogueData.dialogueLines[curLine].actionData[curActionData];
        buttonText.text = actionData.choiceText;
        dialogueObject = dialogueObj;

        switch (actionData.actionType)
        {
            case ActionData.ActionType.PASSCODE:
                Instantiate(passcodeInput, transform.parent);
                break;
        }
    }

    public void Click()
    {
        switch (actionData.actionType)
        {
            case ActionData.ActionType.DIALOGUE:
                dialogueObject.SelectDialogue(actionData.dialogueData);
                return;

            case ActionData.ActionType.PASSCODE:
                CheckPasscode();
                return;
        }


        dialogueObject.DoAction(actionData);
    }

    void CheckPasscode()
    {
        Passcode passcode = passcodeInput.GetComponent<Passcode>();
        string input = passcode.GetInput();

        if(input == actionData.passcode)
        {
            dialogueObject.SelectDialogue(actionData.passDialogueData);
        }
        else
        {
            dialogueObject.SelectDialogue(actionData.failDialogueData);
        }
    }
}
