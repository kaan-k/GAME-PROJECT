using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class CharacterCreation : MonoBehaviour
{
    public InputField iField;
    public Text descriptionText;
    public Text raceText;
    public Text error;
    int counter=0;
    int haircounter=0;
    int classcounter=0;
    public string playerName;
    bool thereisGear = false;
    public string[] classDescriptions;
    public string[] raceDescriptions;

    public Sprite[] skinColors;
    public Sprite[] hairStyles;

    public Transform startingGear;
    public GameObject currentGear;
    public GameObject player;
    public GameObject[] classStart;
    
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer hairRenderer;
    public SpriteRenderer classRenderer;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        spriteRenderer.sprite = skinColors[counter];
        hairRenderer.sprite = hairStyles[haircounter];
        
        //currentGear = Instantiate(classStart[classcounter],startingGear); 
        //currentGear.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void skinColorLeft()
    {
        counter++;
        if(counter >= skinColors.Length)
        {
            Debug.Log("test");
            counter=0;
        }
        spriteRenderer.sprite = skinColors[counter];
        Debug.Log(counter);
        raceText.text = raceDescriptions[counter];
    }
    public void skinColorRight()
    {
        counter--;
        if(counter == 0)
        {
            spriteRenderer.sprite = skinColors[counter];
            counter = skinColors.Length;
        }
        spriteRenderer.sprite = skinColors[counter];
        Debug.Log(counter);
        raceText.text = raceDescriptions[counter];
    }

    public void hairStyleLeft()
    {
        haircounter++;
        if(haircounter >= hairStyles.Length)
        {
            haircounter=0;
        }
        hairRenderer.sprite = hairStyles[haircounter];
        Debug.Log(haircounter);
    }
    public void hairStyleRight()
    {
        haircounter--;
        if(haircounter == 0)
        {
            hairRenderer.sprite = hairStyles[haircounter];
            haircounter = hairStyles.Length;
        }
        hairRenderer.sprite = hairStyles[haircounter];
    }


    public void classLeft()
    {
        classcounter++;
        if(classcounter >= classStart.Length)
        {
            Debug.Log("test");
            classcounter=0;
        }
        
        if(currentGear==null)
        {
            currentGear = Instantiate(classStart[classcounter],startingGear);
            currentGear.transform.parent = this.transform;
        }
        else
        {
            Destroy(currentGear);
            currentGear = Instantiate(classStart[classcounter],startingGear);
            currentGear.transform.parent = this.transform;
        }
        if(classcounter==0) //if the player choose mage
        {
            characterStats PlayerObject = player.GetComponent<characterStats>();
            PlayerObject.maxHP = 100;
            PlayerObject.maxMP = 400;
            PlayerObject.str = 5;
            PlayerObject.def = 3;
        }
        else if(classcounter==1)//if the player choose warrior
        {
            characterStats PlayerObject = player.GetComponent<characterStats>();
            PlayerObject.maxHP = 125;
            PlayerObject.maxMP = 70;
            PlayerObject.str = 9;
            PlayerObject.def = 6;
        }
        //startingGear = classStart[classcounter].gameObject;
        //this.gameObject = classStart[classcounter].gameObject;
        descriptionText.text = classDescriptions[classcounter];
        Debug.Log(classcounter);
    }
    public void classRight()
    {
        classcounter--;
        if(classcounter == 0)
        {
            classcounter = classStart.Length;
        }
        if(currentGear==null)
        {
            currentGear = Instantiate(classStart[classcounter],startingGear); 
        }
        else
        {
            Destroy(currentGear);
            currentGear = Instantiate(classStart[classcounter],startingGear); 
        }
        if(classcounter==0) //if the player choose mage
        {
            characterStats PlayerObject = player.GetComponent<characterStats>();
            PlayerObject.maxHP = 100;
            PlayerObject.maxMP = 400;
            PlayerObject.str = 5;
            PlayerObject.def = 3;
        }
        else if(classcounter==1)//if the player choose warrior
        {
            characterStats PlayerObject = player.GetComponent<characterStats>();
            PlayerObject.maxHP = 125;
            PlayerObject.maxMP = 70;
            PlayerObject.str = 9;
            PlayerObject.def = 6;
        }
        //startingGear = classStart[classcounter].gameObject;
        //this.gameObject = classStart[classcounter].gameObject;
        descriptionText.text = classDescriptions[classcounter];
    }
    public void LoadGame()
    {
        
        //PrefabUtility.ApplyPrefabInstance(this.gameObject,InteractionMode.AutomatedAction);
        if(currentGear==null || playerName==null)
        {
            if(playerName==null)
            {
                error.text = "You must choose a name before starting the game.";
            }
            else
            {
                error.text = "You must choose a class before starting the game.";
            }
            
        }
        else
        {
            characterStats PlayerObject = player.GetComponent<characterStats>();
            playerName =  iField.text;
            PlayerObject.charName = playerName;
            SceneManager.LoadScene("SampleScene");
        }
        
    }



}
