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
    public int lvlReq;
    public int goldReward;
    public int expReward;
    const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
    //public gameobject item reward -- possibly
    //enum for reward types
    //locking quests behind level or achievment requirements

    public QuestGoal questGoal;
    void Start()
    {
        //automaticly create questCode
        for(int i=0; i<5; i++)
        {
            questCode += glyphs[Random.Range(0, glyphs.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
