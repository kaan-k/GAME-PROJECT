using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int reqAmount;
    public int currentAmount;

    public bool isReached()
    {
        return (currentAmount >= reqAmount);
    }
    public enum GoalType
    {
        Kill,
        Gathering
    }
}
