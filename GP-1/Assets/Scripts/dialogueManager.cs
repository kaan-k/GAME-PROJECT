using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;
    public int currentLine;

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
            if(Input.GetButtonUp("Fire1"))
            {
                characterScript.instance.onLoadingScreen=true;
                if(!justStarted)
                {
                        currentLine++;
                    if(currentLine >= dialogueLines.Length)
                    {
                        dialogueBox.SetActive(false);
                        nameBox.SetActive(false);
                        characterScript.instance.onLoadingScreen=false;
                        
                    }
                    else
                    {
                        CheckName();
                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
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
    }
    public void CheckName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
