using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public GameObject questWindow;
    public Text playerCurrentQuestList;
    public Button[] questButtons;
    public Button acceptQuestButton;
    public Text[] questTexts;

    public Text questDesc;
    public Text questName;
    public GameObject questNameObject;
    public List<Quest> currentQuest;
    public List<Quest> acceptedFromNPC;
    public int questToAccept;


    int buttonsToGenerate;

    public static QuestManager instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateButtons(List<Quest> questList)
    {
        DeactivateButtons();
        buttonsToGenerate = questList.Count;
        questWindow.SetActive(true);
        for(int i = 1;i<=buttonsToGenerate;i++)
        {
            if(questList[i-1].lvlReq <= characterScript.instance.GetComponent<characterStats>().playerLevel)
            {
                questButtons[i-1].gameObject.SetActive(true);
                questTexts[i-1].text = questList[i-1].questTitle;
            }
            
        }

    }
    public void DeactivateButtons()
    {
        for(int i = 1;i<=questButtons.Length;i++)
        {
            questButtons[i-1].gameObject.SetActive(false);
            questTexts[i-1].text = null;
        }
        questDesc.gameObject.SetActive(false);
        questNameObject.SetActive(false);
        questName.text = null;
        questDesc.text = null;
        questWindow.SetActive(false);
    }
    public void OpenQuestOne()
    {
        questToAccept=0;
        
        DeactivateButtons();
        questWindow.SetActive(true);
        questDesc.gameObject.SetActive(true);
        questNameObject.SetActive(true);
        questName.text =currentQuest[0].questTitle;
        questDesc.text=currentQuest[0].questDescription;
        
        
    }
    public void OpenQuestTwo()
    {
        questToAccept=1;
        DeactivateButtons();
        questWindow.SetActive(true);
        questDesc.gameObject.SetActive(true);
        questNameObject.SetActive(true);
        questName.text =currentQuest[1].questTitle;
        questDesc.text=currentQuest[1].questDescription;
    }
    public void AcceptQuest()
    {
        characterScript.instance.GetComponent<CharacterQuests>().characterQuests.Add(currentQuest[questToAccept]);
        currentQuest[questToAccept].isActive=true;
        acceptedFromNPC.Add(currentQuest[questToAccept]);
    }
    public void SaveQuestData()
    {
        for(int i = 0;i<currentQuest.Count;i++)
        {
            PlayerPrefs.SetInt("isActive",currentQuest[i].isActive ? 1 : 0); 
        }
    }
}
