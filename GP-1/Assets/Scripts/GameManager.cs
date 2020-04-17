using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public characterStats[] characterStats;
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
        DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
