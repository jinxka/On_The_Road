using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuest : MonoBehaviour
{

    private questManager questManager;
    private QuestTracker questTracker;
    private Inventory playerInv;


    // Use this for initialization
    void Start()
    {
        questTracker = GameObject.FindGameObjectWithTag("Objective").GetComponent<QuestTracker>();
        questManager = GameObject.FindGameObjectWithTag("QuestLog").transform.GetChild(0).GetChild(0).GetComponent<questManager>();
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateQuest()
    {
        /*for (int i = 0; i < questTracker.questList.Count; i++)
        {
            if (questTracker.questList[i].itemID == 1)
            {
                if (questTracker.questList[i].itemValue < questTracker.questList[i].itemAttributes[0].attributeValue)
                    questTracker.questList[i].itemValue += 1;
                else
                    questTracker.questList[i].itemIcon = Resources.Load("Sprites/HUD/Check-sprite-ltr-1.svg", typeof(Sprite)) as Sprite;
            }
         
        }*/

        for (int j = 0; j < questManager.ItemsInInventory.Count; j++)
        {
            if (questManager.ItemsInInventory[j].itemID == 2)
            {
                if (questManager.ItemsInInventory[j].itemValue < questManager.ItemsInInventory[j].itemAttributes[0].attributeValue)
                {
                    questManager.ItemsInInventory[j].itemValue += 1;
                    if (questManager.ItemsInInventory[j].itemValue == questManager.ItemsInInventory[j].itemAttributes[0].attributeValue)
                    {
                        questManager.ItemsInInventory[j].itemIcon = Resources.Load("Sprites/HUD/Check-sprite-ltr-1.svg", typeof(Sprite)) as Sprite;
                        playerInv.addItemToInventory(40);
                    }
                }
                else
                    return;
            }

        }
    }

}
