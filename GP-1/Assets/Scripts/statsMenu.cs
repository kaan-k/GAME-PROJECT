using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statsMenu : MonoBehaviour
{
    public GameObject Player;
    public Text Name;
    public Text EXP;
    public Text playerLVL;
    string currentLvlExp;
    string nextLvlExp;

    string currentHPtext, maxHPtext;
    public Text HP;
    string currentMPtext, maxMPtext;
    public Text MP;
    public Text str;
    public Text def;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        characterStats PlayerObject = Player.GetComponent<characterStats>();
        Name.text = "Name: " + PlayerObject.charName;
        currentLvlExp = PlayerObject.currentEXP.ToString();
        nextLvlExp = PlayerObject.expTonextLVL[PlayerObject.playerLevel].ToString();
        EXP.text = "Experience: "+currentLvlExp + " / " + nextLvlExp;
        currentHPtext = PlayerObject.currentHP.ToString();
        maxHPtext = PlayerObject.maxHP.ToString();
        HP.text = "HP: "+currentHPtext  + "/" + maxHPtext;
        currentMPtext = PlayerObject.currentMP.ToString();
        maxMPtext = PlayerObject.maxMP.ToString();
        MP.text  = "MP: "+currentMPtext + "/" + maxMPtext;

        str.text = "Strenght: "+PlayerObject.str.ToString();
        def.text = "Defence: "+PlayerObject.def.ToString();

        playerLVL.text = "Level: "+PlayerObject.playerLevel.ToString();

    }
}
