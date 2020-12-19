using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager2 : MonoBehaviour
{
    public static QuestManager2 instance;
    public List<string> ActiveQuests;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void acceptQuest(string questName, string questDescription, List<string> questReqs)
    {
        ActiveQuests.Add(questName);
    }
}
