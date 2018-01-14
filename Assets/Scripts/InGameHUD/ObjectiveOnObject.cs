using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectiveOnObject : MonoBehaviour                   //Saves the Item in the slot
{
    public Item item;                                       //Item 
    [SerializeField]
    Text questName;                                      //text for the itemValue
    [SerializeField]
    Image image;
    [SerializeField]
    Text objective;
    public int[] counters;

    private QuestTracker tracker;
    [SerializeField]
    Button untrackButton;

    void Update()
    {
        questName.text = "" + item.itemAttributes[0].attributeName;                     //sets the itemValue         
        image.sprite = item.itemIcon;
        objective.text = item.itemValue + "/" + item.itemAttributes[0].attributeValue;
    }

    void Start()
    {
        image.sprite = item.itemIcon;                 //set the sprite of the Item 
        counters = new int[item.itemAttributes.Count + 1];
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            counters[i] = 0;
        }

        if (tracker == null)
            tracker = GameObject.FindGameObjectWithTag("Objective").GetComponent<QuestTracker>();     
        untrackButton.onClick.AddListener(onUntrackQuest);
    }

    public void onUntrackQuest()
    {
        tracker.unTrackQuest(item);
    }
}
