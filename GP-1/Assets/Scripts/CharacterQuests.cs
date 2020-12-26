using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterQuests : MonoBehaviour
{
    public static CharacterQuests instance;
    public List<Quest> quests = new List<Quest>();

    void Start()
    {
        if(instance == null)
        {
            //Instance if null.
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                //Destroy duplicate if instance exists.
                Destroy(gameObject);
            } 
        }
    }

    void Update()
    {
        
    }

}
