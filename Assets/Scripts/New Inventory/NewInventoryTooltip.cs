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
        string description = itemToShow.itemDescription;
        itemIcon.sprite = itemToShow.itemIcon;
        itemName.text = itemToShow.itemName + ", " + itemToShow.itemRarity + " " + itemToShow.itemType;
        foreach (NewItemAttribute attribute in itemToShow.itemAttributes)
        description += ("\n" + attribute.attributeName + ": +" + attribute.attributeValue);
        itemDescription.text = description;
        tooltipCanvasGroup.alpha = 1;
    }

    public void hideTooltip()
    {
        tooltipCanvasGroup.alpha = 0;
    }
}
