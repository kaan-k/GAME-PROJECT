using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueActivator : MonoBehaviour
{
    public string[] lines;
    public bool canActivate;
    public bool isNull;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change dialogue start button to something else.
        if(canActivate && Input.GetButtonDown("Fire1") && !dialogueManager.instance.dialogueBox.activeInHierarchy)
        {
            if(lines.Length>0)
            {
                dialogueManager.instance.ShowDialogue(lines);
                isNull=false;
            }
            else
            {
                isNull=true;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            canActivate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            canActivate = false;
        }
    }
}
