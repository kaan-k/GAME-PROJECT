﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public string[] questMarkerNames;
    //public List<string> actQuests;
    public bool[] questMarkersComplete;
    void Start()
    {
       
        instance = this;
        
        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //questTracker = new bool[activeQuests.Count];
    }
    public int GetQuestNumber(string questToFind)
    {
        for(int i = 0;i <questMarkerNames.Length;i++)
        {
            if(questMarkerNames[i] == questToFind)
            {
                return i;
            }
        }
        Debug.LogError("Quest "+questToFind+" does not exist.");
        return 0;
    }
    public bool CheckIfComplete(string questToCheck)
    {
        if(GetQuestNumber(questToCheck)!=0)
        {
            return questMarkersComplete[GetQuestNumber(questToCheck)];
        }
        return false;

    }
    public void MarkQuestComplete(string questToMark)
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = true;
    }

    public void MarkQuestIncomplete(string questToMark)
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = false;
    }
    
}
