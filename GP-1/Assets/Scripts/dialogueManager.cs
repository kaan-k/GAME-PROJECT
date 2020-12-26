using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    int sizeofList;
    public List<string> questNames = new List<string>();
    public bool dialogueActive;
    
    public Text[] questTexts;
    //public Text quest2Text;
    //public Text quest3Text;
    public GameObject[] questBoxes;
    //public GameObject quest2Box;
    //public GameObject quest3Box;
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;
    public int currentLine;
    public bool isActive;
    private bool justStarted;

    public static dialogueManager instance;
    void Start()
    {
        instance = this;
        //dialogueText.text = dialogueLines[currentLine];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.activeInHierarchy)
        {
           //ProgressDialogue();
        }
    }

    public void ProgressDialogue()
    {
                dialogueActive = true;
                characterScript.instance.onLoadingScreen=true;
                if(!justStarted)
                {
                        currentLine++;
                    if(currentLine >= dialogueLines.Length)
                    {
                        dialogueActive = false;
                        //Dialogue Ended
                        dialogueBox.SetActive(false);
                        nameBox.SetActive(false);
                        characterScript.instance.onLoadingScreen=false;
<<<<<<< Updated upstream
                        isActive=false;
=======
                        DeactivateQuestWindows();
>>>>>>> Stashed changes
                        
                    }
                    else
                    {
                        CheckName();
                        dialogueText.text = dialogueLines[currentLine];
                        
                        //write quest names here
                    }
                }
                else
                {
                    justStarted = false;
                }
        
    }
    public void ShowDialogue(string[] newLines)
    {
        dialogueLines = newLines;
        currentLine = 0;

        CheckName();

        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        nameBox.SetActive(true);
        justStarted = true;
        isActive=true;
    }
    public void CheckName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }

    public void ActivateQuestWindows(int QuestCount)
    {
        for(int x=0; x<=QuestCount-1;x++)
        {
            questBoxes[x].SetActive(true);
            //questTexts[x].text = questNames[x];
            
        }

    }
    public void DeactivateQuestWindows()
    {
        foreach(GameObject go in questBoxes)
        {
            go.SetActive(false);
        }
    
    }
    public void GetQuestNames(string questName)
    {
        questNames.Add(questName);
    }
}
