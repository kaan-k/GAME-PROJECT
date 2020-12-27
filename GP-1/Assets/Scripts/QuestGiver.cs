using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public SpriteRenderer questMarkerQuest;
    public SpriteRenderer questMarkerCompletedQuest;
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        for(int i = 0;i<quests.Count;i++)
        {
    
            //if(characterScript.instance.GetComponent<CharacterQuests>()
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(quests.Count>0)
        {
            questMarkerQuest.enabled=true;
        }
        else
        {
            questMarkerQuest.enabled=false;

        }
        if(this.gameObject.GetComponent<dialogueActivator>().canActivate)
        {
            for(int i = 0;i<quests.Count;i++)
            {
                if(quests[i].isActive)
                {
                    quests.Remove(quests[i]);
                }
            }
        }
        
        

        if(this.gameObject.GetComponent<dialogueActivator>().isNull && Input.GetKeyDown(KeyCode.E) && this.gameObject.GetComponent<dialogueActivator>().canActivate)
        {
            StartQuestDialogue();
            QuestManager.instance.currentQuest = quests;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuestManager.instance.DeactivateButtons();
            //QuestManager.instance.questWindow.SetActive(false);
        }
    }
    public void StartQuestDialogue()
    {
        QuestManager.instance.DeactivateButtons();
        QuestManager.instance.GenerateButtons(quests);
    }
}
