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
        GameObject questObject = (GameObject)Instantiate(prefabQuest);
        QuestOnObject questOnObject = questObject.GetComponent<QuestOnObject>();
        questOnObject.item = quest;
        questObject.transform.SetParent(SlotContainer.transform);
        questObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        updateQuestList();
    }

    public void unTrackQuest(Item quest)
    {

    }

    private void updateQuestList()
    {
        questList.Clear();
        for (int i = 0; i < SlotContainer.transform.childCount; i++)
        {
            questList.Add(SlotContainer.transform.GetChild(i).GetComponent<QuestOnObject>().item);
        }
    }   
}
