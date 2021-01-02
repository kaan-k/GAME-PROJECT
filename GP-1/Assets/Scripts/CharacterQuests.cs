using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuests : MonoBehaviour
{
    public List<Quest> characterQuests;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RemoveCompletedQuestFromList(){

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="exploration-trigger")
        {
            //ExplorationNotification.instance.displayExplorationNotification(coll.gameObject.GetComponent<Exploration>().areaName);
            for(int i = 0;i<characterQuests.Count;i++)
            {
                if(!characterQuests[i].questGoal.isCompleted)
                {
                    if(characterQuests[i].questGoal.goalType==QuestGoal.GoalType.Exploring)
                    {
                        characterQuests[i].questGoal.AreaExplored(coll.gameObject.GetComponent<Exploration>().areaName);
                        if(characterQuests[i].questGoal.isCompleted)
                        {
                            this.gameObject.GetComponent<characterStats>().AddExp(characterQuests[i].expReward);
                            QuestDisplay.instance.RemoveQuest(characterQuests[i].questTitle);
                        }
                    }
                }
                
            }
        }
        
    }
}
