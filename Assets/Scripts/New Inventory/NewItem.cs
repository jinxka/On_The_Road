using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewItem : MonoBehaviour, IPointerDownHandler
{

    [Header("Item Display Properties")]
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    
    [Space(10)]
    [Header("Item Characteristics")]
    public itemTypes itemType;
    public enum itemTypes { weapon, head, shoulders, legs, boots, gloves };

    NewInventoryTooltip inventoryTooltip;
    NewInventory inventory;

    void Start()
    {
        inventoryTooltip = GameObject.FindGameObjectWithTag("NewInventoryTooltip").GetComponent<NewInventoryTooltip>();
        inventory = GameObject.FindGameObjectWithTag("NewInventory").GetComponent<NewInventory>();
    }

    public void showItemInfo()
    {
        inventoryTooltip.showTooltip(this);
    }

    public void hideItemInfo()
    {
        inventoryTooltip.hideTooltip();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            inventory.equipItem(this);
        }
    }
}
