using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class areaExit : MonoBehaviour
{
    // Strings defined.
    public string areaToLoad;
    public string areaTransitionName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check collision with player.
        if(other.tag == "Player")
        {
            //If collided load area.
            SceneManager.LoadScene(areaToLoad);
            //Get the instance areaTransitionName and set to be equal to this areaTransitionName.
            characterScript.instance.areaTransitionName = areaTransitionName;
        }
    }
}
