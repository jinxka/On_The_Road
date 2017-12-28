using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutIconsController : MonoBehaviour {

    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    Text tooltipText;

    public void onInventoryClick()
    {
        
    }

    public void onQuestClick()
    {
        if (QuestLogController.Instance.questLogCanvas.alpha == 0)
            QuestLogController.Instance.openQuestLog();
        else
            QuestLogController.Instance.closeQuestLog();
    }

    public void showTooltip(string iconName)
    {
        tooltipText.text = iconName;
        tooltip.SetActive(true);
    }

    public void hideTooltip()
    {
        tooltip.SetActive(false);
    }
}
