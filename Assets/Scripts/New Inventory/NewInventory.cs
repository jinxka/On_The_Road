using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour {

    public NewInventorySlot[] equippedItemSlots;
    public NewInventorySlot[] backpackItemSlots;

    public List<NewItem> backpackItemList;
    public List<NewItem> equippedItemList;

    void Start()
    {
        addItemToBackpack("Knife");
        addItemToBackpack("Hamburger");
        addItemToBackpack("Baseball Helmet");
        addItemToBackpack("Baseball Helmet");
    }

    public void addItemToBackpack(string name)
    {
        foreach (NewInventorySlot slot in backpackItemSlots)
        {
            if (slot.isAvailable)
            {
                GameObject item = Instantiate(Resources.Load("Prefabs/Items/" + name, typeof(GameObject))) as GameObject;
                item.transform.SetParent(slot.gameObject.transform);
                item.GetComponent<RectTransform>().localPosition = Vector3.zero;
                backpackItemList.Add(item.GetComponent<NewItem>());
                slot.isAvailable = false;
                break;
            }
            else
                ErrorScript.Instance.DisplayErrorMessage("Inventory is full!");
        }
    }

    public void equipItem(NewItem itemToEquip)
    {
        foreach (NewInventorySlot slot in equippedItemSlots)
        {
            if (slot.slotType.ToString() == itemToEquip.itemType.ToString())
            {
                if (slot.isAvailable)
                {
                    itemToEquip.transform.SetParent(slot.gameObject.transform);
                    itemToEquip.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    slot.isAvailable = false;
                    break;
                }
                else
                {
                    Transform itemToMove = slot.gameObject.transform.GetChild(0);
                    itemToMove.SetParent(itemToEquip.transform.parent);
                    itemToMove.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    itemToEquip.transform.SetParent(slot.gameObject.transform);
                    itemToEquip.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    break;
                }
            }
            else
                ErrorScript.Instance.DisplayErrorMessage("Can't equip item!");
        }
    }
}
