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
    public enum itemTypes { weapon, helmet, armor, pants, boots, gloves, consumable };
    [SerializeField]
    public List<NewItemAttribute> itemAttributes = new List<NewItemAttribute>();
    public enum itemRarities { common, rare, epic, legendary };
    public itemRarities itemRarity;

    NewInventoryTooltip inventoryTooltip;
    NewInventory inventory;

    void Start()
    {
        inventoryTooltip = GameObject.FindGameObjectWithTag("NewInventoryTooltip").GetComponent<NewInventoryTooltip>();
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
            TriggerItem();
        }
    }

    public void TriggerItem()
    {
        if (itemType == itemTypes.consumable)
            NewInventory.Instance.ConsumeItem(this);
        else
            NewInventory.Instance.EquipItem(this);
    }
}
