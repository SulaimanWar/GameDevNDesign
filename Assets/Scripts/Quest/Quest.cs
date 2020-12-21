using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QuestType { Gathering, Talk, Reach }; 
    public enum QuestStatus { Waitting, Accepted, Completed };

    public string questName;
    public QuestType questType;
    public QuestStatus questStatus;

    [Header("Gathering Type Quest")]
    public int requireAmount;
}