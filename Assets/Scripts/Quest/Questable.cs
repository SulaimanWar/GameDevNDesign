using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questable : MonoBehaviour
{
    public Quest quest;
    public bool isFinished;
    public QuestTarget questTarget;
    public void DelegateQuest()
    {
        if (isFinished == false)
        {
            if (quest.questStatus == Quest.QuestStatus.Waitting)
            {
                PlayerQuest.instance.questList.Add(quest);
                quest.questStatus = Quest.QuestStatus.Accepted;

                if(quest.questType == Quest.QuestType.Gathering)
                {
                    questTarget.QuestComplete();
                }
            }
            else
            {
                Debug.Log(string.Format("Quest : {0} is been taken away!", quest.questName));
                //Debug.Log("Object: " + quest.questName + "is been taken away!");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
