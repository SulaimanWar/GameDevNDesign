using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    public string questName;
    public enum QuestType { Gathering, Talk, Reach };
    public QuestType questType;

    [Header("Gatehering Type Quest")]
    public int amount = 1;


    [Header("Talk Type Quest")]
    public bool hasTalked;

    [Header("Gatehering Type Quest")]
    public bool hasReached;

    public void QuestComplete()
    {
        for(int i = 0; i< PlayerQuest.instance.questList.Count; i++)
        {
            if(questName == PlayerQuest.instance.questList[i].questName && PlayerQuest.instance.questList[i].questStatus == Quest.QuestStatus.Accepted)
            {
                switch(questType)
                {
                    case QuestType.Gathering:
                        if(PlayerQuest.instance.itemAmount >= PlayerQuest.instance.questList[i].requireAmount)
                        {
                            PlayerQuest.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                        }
                        break;
                    case QuestType.Talk:
                        if(hasTalked)
                        {
                            PlayerQuest.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                        }
                        break;
                    case QuestType.Reach:
                        if (hasReached)
                        {
                            PlayerQuest.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < PlayerQuest.instance.questList.Count; i++)
            {
                if (PlayerQuest.instance.questList[i].questName == questName)
                {

                    if (questType == QuestType.Reach)
                    {
                      hasReached = true;
                      QuestComplete();
                    }

                        #region
                        //if (questType == QuestType.Gathering)
                        //{
                        //   QuestComplete();
                        //}
                        //else if (questType == QuestType.Reach)
                        //{
                        //   hasReached = true;
                        //  QuestComplete();
                        //}
                        #endregion
                }
            }
        }
    }
}
