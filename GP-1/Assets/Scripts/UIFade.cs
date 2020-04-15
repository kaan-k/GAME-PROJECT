using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;
    // Start is called before the first frame update
    void Start()
    {
        //Make this only instance;
        //---instance = this; !REMOVED CODE! MOVED TO LINE 19
        //---DontDestroyOnLoad(gameObject); !REMOVED CODE! MOVED TO LINE 32
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
    void Update()
    {
        if(shouldFadeToBlack)
        {
            //++ alpha
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,1f,fadeSpeed*Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if(shouldFadeFromBlack)
        {
            //-- alpha
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,0f,fadeSpeed*Time.deltaTime));
            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
        
    }
    public void fadetoBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    public void fadefromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
