using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLoader : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        if(characterScript.instance == null)
        {
            Instantiate(player);
        }
    }
}
