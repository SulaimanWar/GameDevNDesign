using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEntered;

    public Questable questable;
    public QuestTarget questTarget;

    [TextArea(1, 4)]
    public string[] lines;
    [TextArea(1, 4)]
    public string[] completeLines;
    [TextArea(1, 4)]
    public string[] finalLines;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isEntered = true;

            DialogueManager.instance.currentQuestable = questable;
            DialogueManager.instance.questTarget = questTarget;
            DialogueManager.instance.talkable = this;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
            DialogueManager.instance.currentQuestable = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEntered && Input.GetKeyDown(KeyCode.E) && DialogueManager.instance.dialogueBox.activeInHierarchy == false)
        {
            if (questable == null)
            {
                DialogueManager.instance.showDialogue(lines);
            }
            else
            {
                if(questable.quest.questStatus == Quest.QuestStatus.Completed && DialogueManager.instance.currentQuestable.isFinished == true)
                {
                    DialogueManager.instance.showDialogue(finalLines);
                }
                else
                {
                    DialogueManager.instance.showDialogue(lines);
                }
            }
        }
    }
}
