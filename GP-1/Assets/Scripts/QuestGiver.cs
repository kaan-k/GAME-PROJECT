using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quest;
    public Button AcceptQuestButton;
    public EventTrigger eventTrigger;

    public CharacterQuests player;

    void Start()
    {
        
    }
    void Update()
    {
        if(this.gameObject.GetComponent<dialogueActivator>().dialogueOn)
        {
            AcceptQuestButton = GameObject.FindGameObjectWithTag("accept-quest-button").GetComponent<Button>();
            //eventTrigger = GameObject.FindGameObjectWithTag("accept-quest-button").GetComponent<EventTrigger>();
            eventTrigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener( ( data ) => { OnPointerDownDelegate( ( PointerEventData ) data ); } );
        }
        
        

        
        
 
    }
    void LateUpdate()
    {
        //AcceptQuestButton.onClick.AddListener(AcceptQuest);
    }
    public void OnPointerDownDelegate( PointerEventData data )
         {
             AcceptQuest();
         }
    public void AcceptQuest()
    {

        for(int i = 0;i <quest.Count;i++)
        {
            //Quest a = new Quest();
            quest[i].isActive = true;
            quest[i].GenerateQuest(quest[i].title,quest[i].desc,quest[i].expReward,quest[i].goldReward,quest[i].goal);
            CharacterQuests.instance.quests.Add(quest[i]);
        }
        
    }
    
    
}
