using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public string exploringName;
    public bool isCompleted;


    public bool isReached()
    {
        return(currentAmount>=requiredAmount);
    }
    public void EnemyKilled()
    {
        if(goalType==GoalType.Kill)
        {
            currentAmount++;
        }
    }
    public void AreaExplored(string name)
    {
        if(goalType==GoalType.Exploring)
        {
            if(name==exploringName)
            {
                if(!isReached())
                {
                    currentAmount++;
                }
                else
                {
                    isCompleted=true;
                }
            }
            
        }
    }
    public enum GoalType
    {
        Kill,
        Gathering,
        Exploring
    }
}
