using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialogueBox;
    public Text dialogueText;
    public Image Icon;
    public Sprite face1, face2;

    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine;

    private bool isScrolling;
    [SerializeField] private float textSpeed;

    public Questable currentQuestable;
    public QuestTarget questTarget;
    public Talkable talkable;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space) && dialogueText.text == dialogueLines[currentLine])
            {
                if (isScrolling == false)
                {
                    currentLine++;

                    if (currentLine < dialogueLines.Length)
                    {
                        CheckName();
                        StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        print(CheckQuestIsComplete());

                        if(CheckQuestIsComplete() && currentQuestable.isFinished == false)
                        {
                            showDialogue(talkable.completeLines);
                            currentQuestable.isFinished = true;
                        }
                        else
                        {
                            dialogueBox.SetActive(false);

                            Time.timeScale = 1f;

                            if (currentQuestable == null)
                                Debug.Log("There is no Quest in this person");
                            else
                            {
                                currentQuestable.DelegateQuest();
                                if(CheckQuestIsComplete() && currentQuestable.isFinished == false)
                                {
                                    showDialogue(talkable.completeLines);
                                    currentQuestable.isFinished = true;
                                }
                            }

                            if (questTarget != null)
                            {
                                for (int i = 0; i < PlayerQuest.instance.questList.Count; i++)
                                {
                                    if (PlayerQuest.instance.questList[i].questName == questTarget.questName)
                                    {
                                        questTarget.hasTalked = true;
                                        questTarget.QuestComplete();
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        
                    }
                }
            }
        }
    }

    public void showDialogue(string[] _newLines)
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);

        Time.timeScale = 0f;
    }

    private void CheckName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            switch (dialogueLines[currentLine])
            {
                case "n-A":
                    Icon.sprite = face1;
                    currentLine++;
                    break;
                case "n-B":
                    Icon.sprite = face2;
                    currentLine++;
                    break;
            }
        }
    }

    IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        isScrolling = false;
    }

    public bool CheckQuestIsComplete()
    {
        if(currentQuestable == null)
        {
            return false;
        }

        for(int i = 0; i < PlayerQuest.instance.questList.Count;i++ )
        {
            if(currentQuestable.quest.questName == PlayerQuest.instance.questList[i].questName
                && PlayerQuest.instance.questList[i].questStatus == Quest.QuestStatus.Completed)
            {
                currentQuestable.quest.questStatus = Quest.QuestStatus.Completed;
                return true;
            }
        }
        return false;
    }
}
