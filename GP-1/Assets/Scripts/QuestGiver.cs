using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public SpriteRenderer questMarkerQuest;
    public SpriteRenderer questMarkerCompletedQuest;
    string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
    void Start()
    {
        SynchronizeQuestData();
        //GenerateQuestCodes();

    }
    // Update is called once per frame
    void Update()
    {
        if(quests.Count>0)
        {
            for(int i = 0;i<quests.Count;i++)
            {
                if(characterScript.instance.GetComponent<characterStats>().playerLevel >= quests[i].lvlReq)
                {
                    questMarkerQuest.enabled=true;
                }
            }
            
            
        }
        else
        {
            questMarkerQuest.enabled=false;

        }
        if(this.gameObject.GetComponent<dialogueActivator>().canActivate)
        {
            SynchronizeQuestData();
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
    public void SynchronizeQuestData()
    {
        for(int i = 0;i<quests.Count;i++)
            {
                for(int j = 0;j<characterScript.instance.GetComponent<CharacterQuests>().characterQuests.Count;j++)
                {
                    if(quests[i].questCode == characterScript.instance.GetComponent<CharacterQuests>().characterQuests[j].questCode)
                    {
                        Debug.Log(quests[i].questCode);
                        Debug.Log(characterScript.instance.GetComponent<CharacterQuests>().characterQuests[j].questCode);
                        quests.Remove(quests[i]);
                    }
                }
            }
    }
    public void GenerateQuestCodes()
    {
        for(int i = 0;i<quests.Count;i++)
        {
            if(!quests[i].codeGenerated)
            {
                for(int j=0; j<6; j++)
                {
                //save codeGenerated between scenes
                quests[i].questCode += glyphs[Random.Range(0, glyphs.Length)];
                }
                quests[i].codeGenerated = true;
                GlobalQuestCodes.instance.SaveQuestCode(quests[i].questCode);
                if(GlobalQuestCodes.instance.createdQuestCodes.Contains(quests[i].questCode+quests[i].questTitle))
                {
                    quests[i].codeGenerated = true;
                }
                else
                {
                    //Debug.Log("Saving " +quests[i].questTitle);
                }
            }
                
            
        }
    }
}
