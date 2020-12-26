using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class Quest : MonoBehaviour
{
    public string QuestName;
    public string QuestText;
    bool getQuest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       getQuest = this.gameObject.GetComponent<dialogueManager>().isActive;

       if(getQuest)
       {
           QuestManager2.instance.acceptQuest(QuestName,QuestText,null);
       }
=======
[System.Serializable]
public class Quest
{   
    public bool isActive;
   public string title;
   public string desc;
   public int expReward;
   public int goldReward;


   public QuestGoal goal;


   public void GenerateQuest(string Qtitle, string Qdesc, int Qexp, int Qgold, QuestGoal Qgoal)
    {
        title = Qtitle;
        desc = Qdesc;
        expReward = Qexp;
        goldReward = Qgold;
        goal = Qgoal;

>>>>>>> Stashed changes
    }
}
