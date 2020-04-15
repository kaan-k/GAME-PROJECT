using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essentialLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;

    void Start()
    {
        if(UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }
        if(characterScript.instance == null)
        {
           characterScript clone = Instantiate(player).GetComponent<characterScript>();
           characterScript.instance = clone;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
