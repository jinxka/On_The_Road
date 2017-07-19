using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class questManager : MonoBehaviour {

    [SerializeField]
    private ItemDataBaseList questDatabase;
    [SerializeField]
    private GameObject prefabQuest;
    [SerializeField]
    private GameObject SlotContainer;
    [SerializeField]
    public List<Item> ItemsInInventory = new List<Item>();


    // Use this for initialization
    void Start () {
        if (questDatabase == null)
            questDatabase = (ItemDataBaseList)Resources.Load("QuestDatabase");
        if(prefabQuest == null)
            prefabQuest = Resources.Load("Prefabs/Quest") as GameObject;
        SlotContainer = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;

        addQuestToLog(3);
        addQuestToLog(1);
        addQuestToLog(2);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject addQuestToLog(int id)
    {
       GameObject quest = (GameObject)Instantiate(prefabQuest);
       QuestOnObject questOnObject = quest.GetComponent<QuestOnObject>();
       questOnObject.item = questDatabase.getItemByID(id);
       quest.transform.SetParent(SlotContainer.transform);
       quest.GetComponent<RectTransform>().localPosition = Vector3.zero;
       quest.transform.GetChild(1).GetComponent<Image>().sprite = questOnObject.item.itemIcon;
       questOnObject.item.indexItemInList = 0;
       updateItemList();
       return quest;  
    }

    public void updateItemList()
    {
        ItemsInInventory.Clear();
        for (int i = 0; i < SlotContainer.transform.childCount; i++)
        {
            ItemsInInventory.Add(SlotContainer.transform.GetChild(i).GetComponent<QuestOnObject>().item);
        }
    }
}
