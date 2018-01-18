using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour {

    #region UnityCompliant Singleton
    public static NewInventory Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    #endregion

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

    private void Update()
    {
        if (Input.GetKeyDown(NewInputManager.Instance.Inventory))
            GUIManager.Instance.TogglePanel(GetComponent<CanvasGroup>());
    }

    public bool addItemToBackpack(string name)
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
                return true;
            }
            else
                ErrorScript.Instance.DisplayErrorMessage("Inventory is full!");
        }
        return false;
    }

    public void ConsumeItem(NewItem itemToConsume)
    {
        itemToConsume.gameObject.GetComponent<NewConsumable>().Consume(itemToConsume);
        Destroy(itemToConsume.gameObject);
        UpdateItemList();
    }

    public void EquipItem(NewItem itemToEquip)
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
                    UpdatePlayerStats(itemToEquip, true);
                    break;
                }
                else
                {
                    Transform itemToMove = slot.gameObject.transform.GetChild(0);
                    NewItem movingItem = itemToMove.GetComponent<NewItem>();
                    itemToMove.SetParent(itemToEquip.transform.parent);
                    itemToMove.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    itemToEquip.transform.SetParent(slot.gameObject.transform);
                    itemToEquip.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    UpdatePlayerStats(itemToEquip, true);
                    UpdatePlayerStats(movingItem, false);
                    break;
                }
            }
            else
                ErrorScript.Instance.DisplayErrorMessage("Can't equip item!");
        }
        UpdateItemList();
    }
    
    public void AddToPlayerStats(NewItem item)
    {
        foreach (NewItemAttribute attribute in item.itemAttributes)
        {
            switch (attribute.attributeName)
            {
                case "Health":
                    PlayerHealth.Instance.currentHealth += attribute.attributeValue;
                    break;
                case "Movement Speed":
                    PlayerHealth.Instance.playerMovement.speed += attribute.attributeValue;
                    break;
                case "Damage":
                    PlayerHealth.Instance.playerShooting.BulletDmg += attribute.attributeValue;
                    break;
            }
        }
    }

    void UpdatePlayerStats(NewItem item, bool add)
    {
        int multiplier = (add == true) ? 1 : -1; 
        foreach (NewItemAttribute attribute in item.itemAttributes)
        {
            switch (attribute.attributeName)
            {
                case "Health":
                    PlayerHealth.Instance.maxHealth += (attribute.attributeValue * multiplier);
                    break;
                case "Movement Speed":
                    PlayerHealth.Instance.playerMovement.speed += (attribute.attributeValue * multiplier);
                    break;
                case "Damage":
                    PlayerHealth.Instance.playerShooting.BulletDmg += (attribute.attributeValue * multiplier);
                    break;
            }
        }
    }

    void UpdateItemList()
    {
        equippedItemList.Clear();
        backpackItemList.Clear();

        foreach (NewInventorySlot equippedSlot in equippedItemSlots)
        {
            if (equippedSlot.transform.childCount > 0)
            {
                equippedItemList.Add(equippedSlot.transform.GetChild(0).GetComponent<NewItem>());
            }
        }

        foreach (NewInventorySlot backpackSlot in backpackItemSlots)
        {
            if (backpackSlot.transform.childCount > 0)
            {
                equippedItemList.Add(backpackSlot.transform.GetChild(0).GetComponent<NewItem>());
            }
        }
    }
}
