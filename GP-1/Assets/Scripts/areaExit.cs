using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class areaExit : MonoBehaviour
{
    // Strings defined.
    public string areaToLoad;
    public string areaTransitionName;

    public areaEnterance theEnterance;

    public float waitToLoad = 1f;

    private bool shouldLoadAfterFade;

    void Start()
    {
        theEnterance.transitionName = areaTransitionName;
    }
    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check collision with player.
        if(other.tag == "Player")
        {
            characterScript.instance.DontMove();
            //If collided load area.
            //--SceneManager.LoadScene(areaToLoad); !REMOVED CODE! MOVED TO LINE 30
            shouldLoadAfterFade = true;
            UIFade.instance.fadetoBlack();
            //Get the instance areaTransitionName and set to be equal to this areaTransitionName.
            characterScript.instance.areaTransitionName = areaTransitionName;
        }
    }
}
