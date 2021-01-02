using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExplorationNotification : MonoBehaviour
{
    public static ExplorationNotification instance; 
    public GameObject explorationNotificat;
    public Image explorationImage;
    public Text explorationText;
    void start()
    {
        instance = this;

    }
    public void displayExplorationNotification(string placeName)
    {
        explorationNotificat.gameObject.SetActive(true);
        explorationImage.gameObject.SetActive(true);
        explorationText.text+=placeName;
    }
    
}
