using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalQuestCodes : MonoBehaviour
{
    public List<string> createdQuestCodes;
    public List<List<string>> test;
    public static GlobalQuestCodes instance;
    int count;
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SaveQuestCode(string quest_Code)
    {
        if(createdQuestCodes.Contains(quest_Code))
        {
            //generate another quest code
        }
        else
        {
            createdQuestCodes.Add(quest_Code);
        }
        
    }
}