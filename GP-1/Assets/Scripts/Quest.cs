using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questTitle;
    public string questDescription;
    public string questCode;
    public bool isActive;
    public bool isVisible;
    public bool codeGenerated;
    public int lvlReq;
    public int goldReward;
    public int expReward;
    //public gameobject item reward -- possibly
    //enum for reward types
    //locking quests behind level or achievment requirements

    public QuestGoal questGoal;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
