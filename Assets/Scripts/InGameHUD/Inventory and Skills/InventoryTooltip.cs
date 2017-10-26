using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTooltip : MonoBehaviour {
    public Text itemName;
    public Text itemDescription;
    public Image itemIcon;

    public void showTooltip(InventoryItem item)
    {
        itemName.text = item.name;
        itemDescription.text = item.description;
        itemIcon.sprite = item.icon;
    }
}
