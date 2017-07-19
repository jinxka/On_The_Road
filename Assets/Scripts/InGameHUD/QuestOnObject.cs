using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestOnObject : MonoBehaviour                   //Saves the Item in the slot
{
    public Item item;                                       //Item 
    private Text text;                                      //text for the itemValue
    private Image image;
    public int[] counters;

    private QuestTracker tracker;
    private Button trackButton;

    void Update()
    {
        text.text = "" + item.itemName;                     //sets the itemValue         
        image.sprite = item.itemIcon;
    }

    void Start()
    {
        image = transform.GetChild(1).GetComponent<Image>();
        transform.GetChild(1).GetComponent<Image>().sprite = item.itemIcon;                 //set the sprite of the Item 
        text = transform.GetChild(0).GetComponent<Text>();                                  //get the text(itemValue GameObject) of the item
        counters = new int[item.itemAttributes.Count + 1];
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            counters[i] = 0;
        }

        if (tracker == null)
            tracker = GameObject.FindGameObjectWithTag("Objective").GetComponent<QuestTracker>();
        trackButton = GameObject.FindGameObjectWithTag("QuestLog").transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(5).GetComponent<Button>();
        trackButton.onClick.AddListener(onTrackQuest);

    }

    public void onTrackQuest()
    {
        tracker.trackQuest(item);
    }
}
