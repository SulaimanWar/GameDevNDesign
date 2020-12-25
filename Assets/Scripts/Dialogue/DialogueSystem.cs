using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public CharacterMovement charMovement;
    public WeaponObject weaponObject;

    public GameObject dialogueGO;
    public TextMeshProUGUI dialogueText;
    Transform playerTransform;

    [Space(10)]

    public Transform dialogueButtonGroup;
    public GameObject dialogueButton;
    List<GameObject> dialogueButtonList = new List<GameObject>();
    bool dialogueMode;
    enum Direction
    {
        LEFT, UP, RIGHT, DOWN
    }
    Direction dirEnum;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        DialogueMode(false);
    }

    private void Update()
    {
        if (!dialogueMode)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h > 0.5f)
            {
                dirEnum = Direction.RIGHT;
            }
            else if (h < -0.5f)
            {
                dirEnum = Direction.LEFT;
            }

            if (v > 0.5f)
            {
                dirEnum = Direction.UP;
            }
            else if (v < -0.5f)
            {
                dirEnum = Direction.DOWN;
            }

            Vector2 rayDir = GetDirection();

            RaycastHit2D rayHit = Physics2D.Raycast(playerTransform.position, rayDir * 2f);
            if (rayHit.collider == null)
            {
                return;
            }
            if (rayHit.collider.tag == "Dialogue")
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    DialogueObject dialogueObj = rayHit.collider.gameObject.GetComponent<DialogueObject>();
                    dialogueObj.StartConversation();
                }
            }
        }
    }

    Vector2 GetDirection()
    {
        Vector2 rayDir = new Vector2();

        switch (dirEnum)
        {
            case Direction.LEFT:
                rayDir = -transform.right;
                break;

            case Direction.UP:
                rayDir = transform.up;
                break;

            case Direction.RIGHT:
                rayDir = transform.right;
                break;

            case Direction.DOWN:
                rayDir = -transform.up;
                break;
        }

        return rayDir;
    }

    public void DialogueMode(bool newDialogueMode)
    {
        dialogueMode = newDialogueMode;
        charMovement.enabled = !dialogueMode;
        weaponObject.enabled = !dialogueMode;
        dialogueGO.SetActive(dialogueMode);
    }

    public void DisplayText(string textToDisplay)
    {
        dialogueText.text = textToDisplay;
    }

    public void SetupActionData(DialogueData dialogueData, int curLine, DialogueObject dialogueObj)
    {
        for(int i=0; i<dialogueButtonList.Count; i++)
        {
            Destroy(dialogueButtonList[i]);
        }
        dialogueButtonList.Clear();

        for (int i=0; i<dialogueData.dialogueLines[curLine].actionData.Length; i++)
        {
            ActionData curActionData = dialogueData.dialogueLines[curLine].actionData[i];

            if (curActionData.condition.haveCondition)
            {
                Condition curCondition = curActionData.condition;

                switch (curCondition.keyType)
                {
                    case Condition.KeyType.FLOAT:
                        if(PlayerPrefs.GetFloat(curCondition.playerPrefKey)
                            == curCondition.targetFloatKey)
                        {
                            break;
                        }
                        return;

                    case Condition.KeyType.INT:
                        if (PlayerPrefs.GetInt(curCondition.playerPrefKey)
                            == curCondition.targetIntKey)
                        {
                            break;
                        }
                        return;

                    case Condition.KeyType.STRING:
                        if (PlayerPrefs.GetString(curCondition.playerPrefKey)
                            == curCondition.targetStringKey)
                        {
                            break;
                        }
                        return;
                }
            }

            //Spawn dialogue button
            GameObject spawnDialogueGO = Instantiate(dialogueButton, dialogueButtonGroup);
            DialogueButton dialogueButtonScript = spawnDialogueGO.GetComponent<DialogueButton>();
            dialogueButtonScript.Setup(dialogueData, curLine, i, dialogueObj);
            dialogueButtonList.Add(spawnDialogueGO);
        }
    }

    public void ResetChoices()
    {
        for(int i=0; i<dialogueButtonList.Count; i++)
        {
            Destroy(dialogueButtonList[i]);
        }

        dialogueButtonList.Clear();
    }
}
