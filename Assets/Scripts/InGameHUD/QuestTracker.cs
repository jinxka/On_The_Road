using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour {

    #region UnityCompliant Singleton
    public static QuestTracker Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    #endregion

    [SerializeField]
    private GameObject prefabQuest;
    [SerializeField]
    GameObject grid;
    public List<Item> questList = new List<Item>();

    // Use this for initialization
    void Start () {
        if (prefabQuest == null)
            prefabQuest = Resources.Load("Prefabs/Objective") as GameObject;
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
            questObject.transform.SetParent(grid.transform);
            questObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            questObject.transform.localScale = new Vector3(1, 1, 1);
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
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            if (grid.transform.GetChild(i).GetComponent<ObjectiveOnObject>().item.itemID == quest.itemID)
                Destroy(grid.transform.GetChild(i).gameObject);
        }
    }

    private void updateQuestList()
    {
        questList.Clear();
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            questList.Add(grid.transform.GetChild(i).GetComponent<ObjectiveOnObject>().item);
        }
    }   
}
