using UnityEngine;
using TMPro;

public class DialogueButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    DialogueObject dialogueObject;
    ActionData actionData;

    public GameObject passcodeInput;
    GameObject curPasscodeInput;

    private void Start()
    {
        Debug.Log(gameObject.name);
    }

    public void Setup(DialogueData dialogueData, int curLine, int curActionData, DialogueObject dialogueObj)
    {
        actionData = dialogueData.dialogueLines[curLine].actionData[curActionData];
        buttonText.text = actionData.choiceText;
        dialogueObject = dialogueObj;

        switch (actionData.actionType)
        {
            case ActionData.ActionType.PASSCODE:
                curPasscodeInput = Instantiate(passcodeInput, transform.parent);
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

            case ActionData.ActionType.ACTIVE:
                if (actionData.nextDialogue != null)
                {
                    dialogueObject.SelectDialogue(actionData.nextDialogue);
                }
                break;

            case ActionData.ActionType.PASSCODE:
                CheckPasscode();

                Destroy(curPasscodeInput);
                return;

            case ActionData.ActionType.DIE:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerHealth>().Die();
                return;
        }


        dialogueObject.DoAction(actionData);
    }

    void CheckPasscode()
    {
        Passcode passcode = curPasscodeInput.GetComponent<Passcode>();
        string input = passcode.GetInput();

        Debug.Log("Input:" + input);
        Debug.Log("a:" + actionData.passcode);

        if(input.Contains(actionData.passcode))
        {
            Debug.Log("True");
            dialogueObject.SelectDialogue(actionData.passDialogueData);
        }
        else
        {
            Debug.Log("False");
            dialogueObject.SelectDialogue(actionData.failDialogueData);
        }
    }
}
