using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueActivator : MonoBehaviour
{
    
    public string[] lines;
    public int testvar;
    public bool dialogueOn;
    public bool canActivate;
<<<<<<< Updated upstream
    public bool acceptQuest;

=======
    public bool acceptQuestOnce;
>>>>>>> Stashed changes
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Change dialogue start button to something else.
        if(canActivate && Input.GetKeyDown(KeyCode.E) && !dialogueManager.instance.dialogueBox.activeInHierarchy)
        {
            dialogueManager.instance.ShowDialogue(lines);
            dialogueOn=true;
            int c = this.gameObject.GetComponent<QuestGiver>().quest.Count;
            dialogueManager.instance.ActivateQuestWindows(c);
            //this.gameObject.GetComponent<QuestGiver>()
            //dialogueManager.instance.GetQuestNames()
           
            testvar++;
            
            
            
        }
        else
        {
            dialogueOn=false;
        }
        
        //AcceptQuestButton = null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            //AcceptQuestButton = GameObject.FindGameObjectWithTag("accept-quest-button").GetComponent<Button>();
            canActivate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            canActivate = false;
            this.gameObject.GetComponent<QuestGiver>().AcceptQuestButton=null;
        }
    }
    public void test()
    {
        
    }
}
