using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectiveOnObject : MonoBehaviour                   //Saves the Item in the slot
{
    public Item item;                                       //Item 
    private Text text;                                      //text for the itemValue
    private Image image;
    private Text objective;
    public int[] counters;

    private QuestTracker tracker;
    private Button trackButton;
    private Button untrackButton;

    void Update()
    {
        text.text = "" + item.itemAttributes[0].attributeName;                     //sets the itemValue         
        image.sprite = item.itemIcon;
        objective.text = item.itemValue + "/" + item.itemAttributes[0].attributeValue;
    }

    void Start()
    {
        image = transform.GetChild(1).GetComponent<Image>();
        transform.GetChild(1).GetComponent<Image>().sprite = item.itemIcon;                 //set the sprite of the Item 
        text = transform.GetChild(0).GetComponent<Text>();                                  //get the text(itemValue GameObject) of the item
        objective = transform.GetChild(2).GetComponent<Text>();
        counters = new int[item.itemAttributes.Count + 1];
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            counters[i] = 0;
        }

        if (tracker == null)
            tracker = GameObject.FindGameObjectWithTag("Objective").GetComponent<QuestTracker>();
        trackButton = GameObject.FindGameObjectWithTag("QuestLog").transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(5).GetComponent<Button>();
        untrackButton = this.transform.GetChild(3).GetComponent<Button>();
        trackButton.onClick.AddListener(onTrackQuest);
        untrackButton.onClick.AddListener(onUntrackQuest);

    }

    public void onTrackQuest()
    {
        tracker.trackQuest(item);
    }

    public void onUntrackQuest()
    {
        tracker.unTrackQuest(item);
    }
}
