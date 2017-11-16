using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestTooltip : MonoBehaviour {

    public Item item;
    public QuestOnObject itemVariables;

    [SerializeField]
    private Text tooltipNameText;
    [SerializeField]
    private Text tooltipDescText;
    [SerializeField]
    private Text tooltipRewardText;
    [SerializeField]
    private Text tooltipObjText;
    [SerializeField]
    CanvasGroup questDetail;

	// Update is called once per frame
	void Update () {
        if (questDetail.alpha == 1)
            tooltipObjText.text = item.itemAttributes[0].attributeName + "         " + item.itemValue + " / " + item.itemAttributes[0].attributeValue;
    }

    public void activateTooltip()
    {
        tooltipNameText.text = item.itemName;
        tooltipDescText.text = item.itemDesc;
        tooltipObjText.text = item.itemAttributes[0].attributeName + "         " + item.itemValue + " / " + item.itemAttributes[0].attributeValue;
        tooltipRewardText.text = item.itemAttributes[1].attributeName;
        questDetail.alpha = 1;
    }
}
