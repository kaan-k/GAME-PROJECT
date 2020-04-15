using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaEnterance : MonoBehaviour
{
    public string transitionName;
    void Start()
    {
        //If instance areaTransitionName = transitionName (Player used the exit that leads to this enterance)
        if(transitionName == characterScript.instance.areaTransitionName)
        {
            //Set player position to enterance position.
            characterScript.instance.transform.position = transform.position;
        }
        UIFade.instance.fadefromBlack();
        characterScript.instance.Move();
    }
}
