﻿using UnityEngine;

public class DialogueObject : MonoBehaviour
{
    public DialogueData dialogueData;
    public KeyCode nextLineKey = KeyCode.Space;
    public KeyCode endConvoKey = KeyCode.Escape;

    GameObject playerGO;
    DialogueSystem dialogueSystem;
    int curLine = 0;
    bool choiceButton;

    ActionObject actionObject;

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        dialogueSystem = playerGO.GetComponentInChildren<DialogueSystem>();

        if(GetComponent<ActionObject>() != null)
        {
            actionObject = GetComponent<ActionObject>();
        }
    }

    private void Update()
    {
        if (!choiceButton)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                StartConversation();
            }

            if (Input.GetKeyDown(nextLineKey))
            {
                NextLine();
            }
        }

        if (Input.GetKeyDown(endConvoKey))
        {
            EndConversation();
        }
    }

    public void StartConversation()
    {
        curLine = 0;

        dialogueSystem.DialogueMode(true);
        choiceButton = false;
        DisplayLine();
    }

    void DisplayLine()
    {
        if(dialogueData.dialogueLines[curLine].actionData.Length > 0)
        {
            dialogueSystem.SetupActionData(dialogueData, curLine, this);
            choiceButton = true;
            return;
        }

        string lineToDisplay = dialogueData.dialogueLines[curLine].dialogue;
        dialogueSystem.DisplayText(lineToDisplay);
    }

    void NextLine()
    {
        curLine++;

        if(curLine >= dialogueData.dialogueLines.Length)
        {
            EndConversation();
        }

        DisplayLine();
    }

    void EndConversation()
    {
        curLine = 0;
        dialogueSystem.DialogueMode(false);
        choiceButton = false;
    }

    public void SelectDialogue(DialogueData newDialogueData)
    {
        dialogueData = newDialogueData;
        choiceButton = false;
        StartConversation();
        dialogueSystem.ResetChoices();
    }

    public void DoAction(ActionData actionData)
    {
        actionObject.DoAction(actionData);
    }
}