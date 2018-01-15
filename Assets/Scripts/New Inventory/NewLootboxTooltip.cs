using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLootboxTooltip : MonoBehaviour {

    [SerializeField]
    CanvasGroup tooltipCanvas;
    [SerializeField]
    Text itemName;
    [SerializeField]
    Text itemDesc;
    [SerializeField]
    Image itemIcon;


    public void ShowTooltip(NewItem item)
    {
        itemName.text = item.itemName + ", " + item.itemRarity + " " + item.itemType;
        itemDesc.text = item.itemDescription;
        itemIcon.sprite = item.itemIcon;
        if (tooltipCanvas.alpha == 0)
            GUIManager.Instance.TogglePanel(tooltipCanvas);
    }

    public void HideTooltip()
    {
        if (tooltipCanvas.alpha == 1)
            GUIManager.Instance.TogglePanel(tooltipCanvas);
    }
}
