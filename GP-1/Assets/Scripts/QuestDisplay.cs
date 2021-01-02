using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
   public Button[] questButtons;
   public GameObject questWindow;
   public Text[] questTitle;
   public static QuestDisplay instance;
   public int buttonToGenerate;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayQuests()
    {
        questWindow.SetActive(true);
        buttonToGenerate = characterScript.instance.GetComponent<CharacterQuests>().characterQuests.Count;
        if(buttonToGenerate > 6)
        {
            buttonToGenerate = 6;
        }
        for(int i = 0;i<buttonToGenerate;i++)
        {
            if(characterScript.instance.GetComponent<CharacterQuests>().characterQuests[i].questGoal.isCompleted)
            {
                //questButtons[i-1].gameObject.SetActive(true);
                //questTitle[i-1].text = characterScript.instance.GetComponent<CharacterQuests>().characterQuests[i-1].questTitle;
            }
            else
            {
                questButtons[i].gameObject.SetActive(true);
                questTitle[i].text = characterScript.instance.GetComponent<CharacterQuests>().characterQuests[i].questTitle;
            }
            
        }
    }

    public void RemoveQuest(string title)
    {
        for(int i = 0;i<questTitle.Length;i++)
        {
            if(title == questTitle[i].text)
            {
                Debug.Log("Removing "+title+" now.");
                questButtons[i].gameObject.SetActive(false);
                DisplayQuests();
            }
        }
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }
}
