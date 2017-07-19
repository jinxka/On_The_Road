using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour {

    [SerializeField]
    private GameObject prefabQuest;
    [SerializeField]
    private GameObject SlotContainer;
    public List<Item> questList = new List<Item>();

    // Use this for initialization
    void Start () {
        if (prefabQuest == null)
            prefabQuest = Resources.Load("Prefabs/Objective") as GameObject;
        SlotContainer = transform.GetChild(3).GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void trackQuest(Item quest)
    {
        int j = 0;
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].itemID == quest.itemID)
                j = 1;        
        }

        if (j == 0)
        {
            GameObject questObject = (GameObject)Instantiate(prefabQuest);
            ObjectiveOnObject objOnObject = questObject.GetComponent<ObjectiveOnObject>();
            objOnObject.item = quest;
            questObject.transform.SetParent(SlotContainer.transform);
            questObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            updateQuestList();
            Debug.Log("Combien d'occurences ?");
        }
    }

    public void unTrackQuest(Item quest)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].itemID == quest.itemID)
                questList.Remove(questList[i]);
        }
        for (int i = 0; i < SlotContainer.transform.childCount; i++)
        {
            if (SlotContainer.transform.GetChild(i).GetComponent<ObjectiveOnObject>().item.itemID == quest.itemID)
                Destroy(SlotContainer.transform.GetChild(i).gameObject);
        }
    }

    private void updateQuestList()
    {
        questList.Clear();
        for (int i = 0; i < SlotContainer.transform.childCount; i++)
        {
            questList.Add(SlotContainer.transform.GetChild(i).GetComponent<ObjectiveOnObject>().item);
        }
    }   
}
