using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowQuestTooltip : MonoBehaviour {

    public QuestTooltip tooltip;                                    
    public GameObject tooltipGameObject;
    private Item item;
    private Button button;

    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectWithTag("QuestTooltip") != null)
        {
            tooltip = GameObject.FindGameObjectWithTag("QuestTooltip").GetComponent<QuestTooltip>();
            tooltipGameObject = GameObject.FindGameObjectWithTag("QuestTooltip");
        }
        button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void TaskOnClick()
    {
        if (tooltip != null)
        {
            item = GetComponent<QuestOnObject>().item;
            tooltip.item = item;
            tooltip.itemVariables = GetComponent<QuestOnObject>();
            tooltip.activateTooltip();
        }
    }
}
