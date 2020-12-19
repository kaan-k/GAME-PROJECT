using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string QuestName;
    public string QuestText;
    bool getQuest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       getQuest = this.gameObject.GetComponent<dialogueManager>().isActive;

       if(getQuest)
       {
           QuestManager2.instance.acceptQuest(QuestName,QuestText,null);
       }
    }
}
