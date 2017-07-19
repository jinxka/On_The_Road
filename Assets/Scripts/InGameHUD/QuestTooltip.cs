using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestTooltip : MonoBehaviour {

    public Item item;
    public QuestOnObject itemVariables;

    [SerializeField]
    private GameObject tooltipNameText;
    [SerializeField]
    private GameObject tooltipDescText;
    [SerializeField]
    private GameObject tooltipRewardText;
    [SerializeField]
    private GameObject tooltipObjText;

    // Use this for initialization
    void Start () {
        setVariables();
        deactivateTooltip();
    }
	
	// Update is called once per frame
	void Update () {
        tooltipObjText.GetComponent<Text>().text = item.itemAttributes[0].attributeName + "         " + item.itemValue + " / " + item.itemAttributes[0].attributeValue;
    }

    public void activateTooltip()
    {
        tooltipNameText.SetActive(true);
        tooltipDescText.SetActive(true);
        tooltipRewardText.SetActive(true);
        tooltipObjText.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        tooltipNameText.GetComponent<Text>().text = item.itemName;
        tooltipDescText.GetComponent<Text>().text = item.itemDesc;
        tooltipObjText.GetComponent<Text>().text = item.itemAttributes[0].attributeName + "         " + item.itemValue + " / " + item.itemAttributes[0].attributeValue;
        tooltipRewardText.GetComponent<Text>().text = item.itemAttributes[1].attributeName;
    }

    public void deactivateTooltip()
    {
        tooltipNameText.SetActive(false);
        tooltipDescText.SetActive(false);
        tooltipRewardText.SetActive(false);
        tooltipObjText.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void setVariables()
    {
        tooltipNameText = this.transform.GetChild(0).GetChild(0).gameObject;
        tooltipNameText.SetActive(false);
        tooltipDescText = this.transform.GetChild(0).GetChild(2).GetChild(0).gameObject;
        tooltipDescText.SetActive(false);
        tooltipRewardText = this.transform.GetChild(0).GetChild(1).gameObject;
        tooltipRewardText.SetActive(false);
        tooltipObjText = this.transform.GetChild(0).GetChild(4).gameObject;
        tooltipObjText.SetActive(false);
    }
}
