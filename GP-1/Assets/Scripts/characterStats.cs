using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour
{
    public string charName;
    public int playerLevel;
    public int currentEXP;
    public int[] expTonextLVL;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP;
    public int currentMP;
    public int maxMP=30;
    public int[] mpLvlBonus;
    public int str;
    public int def;
    public int wpnStr;
    public int armStr;
    public string equippedWpn;
    public string equippedArm;
    public Sprite charImg;
    void Start()
    {
        expTonextLVL = new int[maxLevel];
        expTonextLVL[1] = baseEXP;
        for(int i = 2;i<expTonextLVL.Length;i++)
        {
            expTonextLVL[i] = Mathf.FloorToInt(expTonextLVL[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            AddExp(1000);
        }
    }
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if(playerLevel < maxLevel)
        {
            if(currentEXP > expTonextLVL[playerLevel])
            {
            currentEXP -= expTonextLVL[playerLevel];

            playerLevel++;

                if(playerLevel%2 == 0)
                {
                    str++;
                }
                else
                {
                    def++;
                }

            maxHP = Mathf.FloorToInt(maxHP*1.05f);
            currentHP = maxHP;
            maxMP = maxMP+mpLvlBonus[playerLevel];
            currentMP = maxMP;
          }
        }
        
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
