using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryTooltip : MonoBehaviour {

    [SerializeField]
    Image itemIcon;

    [SerializeField]
    Text itemName;

    [SerializeField]
    Text itemDescription;

    [SerializeField]
    CanvasGroup tooltipCanvasGroup;

    public void Start()
    {
        tooltipCanvasGroup.alpha = 0;
    }

    public void showTooltip(NewItem itemToShow)
    {
        itemIcon.sprite = itemToShow.itemIcon;
        itemName.text = itemToShow.itemName;
        itemDescription.text = itemToShow.itemDescription;
        tooltipCanvasGroup.alpha = 1;
    }

    public void hideTooltip()
    {
        tooltipCanvasGroup.alpha = 0;
    }
}
