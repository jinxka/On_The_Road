﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    public GameObject questLog;
    public GameObject questLogPanel;
    public GameObject skillsPanel;
    private Inventory craftSystemInventory;
    private CraftSystem cS;
    private Inventory mainInventory;
    private Inventory characterSystemInventory;
    private Inventory skillsInventory;
    private QuestLogController questController;
    private Tooltip toolTip;

    private InputManager inputManagerDatabase;

    public GameObject HPMANACanvas;

    Text hpText;
    Text manaText;
    Image hpImage;
    Image manaImage;

    public PlayerHealth playerHealth;
    public Tir_normal playerShooting;
    public PlayerMovement playerMovement;

    int normalSize = 3;

    public void OnEnable()
    {
        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        Inventory.ItemEquip += OnGearItem;
        Inventory.ItemConsumed += OnConsumeItem;
        Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }

    public void OnDisable()
    {
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        Inventory.ItemEquip -= OnGearItem;
        Inventory.ItemConsumed -= OnConsumeItem;
        Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }

    void EquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //add the weapon if you unequip the weapon
        }
    }

    void UnEquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //delete the weapon if you unequip the weapon
        }
    }

    void OnBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
        {
            for (int i = 0; i < item.itemAttributes.Count; i++)
            {
                if (mainInventory == null)
                    mainInventory = inventory.GetComponent<Inventory>();
                mainInventory.sortItems();
                if (item.itemAttributes[i].attributeName == "Slots")
                    changeInventorySize(item.itemAttributes[i].attributeValue);
            }
        }
    }

    void UnEquipBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
            changeInventorySize(normalSize);
    }

    void changeInventorySize(int size)
    {
        dropTheRestItems(size);

        if (mainInventory == null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (size == 3)
        {
            mainInventory.width = 3;
            mainInventory.height = 1;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        if (size == 6)
        {
            mainInventory.width = 3;
            mainInventory.height = 2;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 12)
        {
            mainInventory.width = 4;
            mainInventory.height = 3;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 16)
        {
            mainInventory.width = 4;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 24)
        {
            mainInventory.width = 6;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
    }

    void dropTheRestItems(int size)
    {
        if (size < mainInventory.ItemsInInventory.Count)
        {
            for (int i = size; i < mainInventory.ItemsInInventory.Count; i++)
            {
                GameObject dropItem = (GameObject)Instantiate(mainInventory.ItemsInInventory[i].itemModel);
                dropItem.AddComponent<PickUpItem>();
                dropItem.GetComponent<PickUpItem>().item = mainInventory.ItemsInInventory[i];
                dropItem.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            }
        }
    }

    void Start()
    {
        //if (HPMANACanvas != null)
        //{
        //    hpText = HPMANACanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>();

        //    manaText = HPMANACanvas.transform.GetChild(2).GetChild(0).GetComponent<Text>();

        //    hpImage = HPMANACanvas.transform.GetChild(1).GetComponent<Image>();
        //    manaImage = HPMANACanvas.transform.GetChild(1).GetComponent<Image>();

        //    UpdateHPBar();
        //    UpdateManaBar();
        //}

        if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");

        if (craftSystem != null)
            cS = craftSystem.GetComponent<CraftSystem>();

        if (GameObject.FindGameObjectWithTag("Tooltip") != null)
            toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
        if (inventory != null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (characterSystem != null)
            characterSystemInventory = characterSystem.GetComponent<Inventory>();
        if (craftSystem != null)
            craftSystemInventory = craftSystem.GetComponent<Inventory>();
        if (questLog != null)
            questController = questLog.GetComponent<QuestLogController>();
        if (skillsPanel != null)
            skillsInventory = skillsPanel.GetComponent<Inventory>();

        playerHealth = GetComponent<PlayerHealth>();
        playerShooting = transform.GetChild(2).GetComponent<Tir_normal>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    //void UpdateHPBar()
    //{
    //    hpText.text = (currentHealth + "/" + maxHealth);
    //    float fillAmount = currentHealth / maxHealth;
    //    hpImage.fillAmount = fillAmount;
    //}

    //void UpdateManaBar()
    //{
    //    manaText.text = (currentMana + "/" + maxMana);
    //    float fillAmount = currentMana / maxMana;
    //    manaImage.fillAmount = fillAmount;
    //}


    public void OnConsumeItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
            {
                if ((playerHealth.currentHealth + item.itemAttributes[i].attributeValue) > playerHealth.startingHealth)
                    playerHealth.currentHealth = playerHealth.startingHealth;
                else
                {
                    playerHealth.currentHealth += item.itemAttributes[i].attributeValue;
                    playerHealth.SetHealthUI();
                }
            }
            /*if (item.itemAttributes[i].attributeName == "Mana")
            {
                if ((currentMana + item.itemAttributes[i].attributeValue) > maxMana)
                    currentMana = maxMana;
                else
                    currentMana += item.itemAttributes[i].attributeValue;
            }*/
            if (item.itemAttributes[i].attributeName == "Armor")
            {
                if ((playerHealth.armor + item.itemAttributes[i].attributeValue) > playerHealth.startingArmor)
                    playerHealth.armor = playerHealth.startingArmor;
                else
                    playerHealth.armor += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Damage")
            {
                //if ((playerShooting.BulletDmg) + item.itemAttributes[i].attributeValue) > playerShooting.maxDamage)
                    //playerShooting.damagePerShot = playerShooting.maxDamage;
                //else
                    playerShooting.BulletDmg += item.itemAttributes[i].attributeValue;
            }
        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }

    public void OnGearItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
               playerHealth.startingHealth += item.itemAttributes[i].attributeValue;
            /*if (item.itemAttributes[i].attributeName == "Mana")
                maxMana += item.itemAttributes[i].attributeValue;*/
            if (item.itemAttributes[i].attributeName == "Armor")
                playerHealth.startingArmor += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                playerShooting.BulletDmg += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "AttackSpeed")
                playerShooting.fireRate = (1 / (float)(item.itemAttributes[i].attributeValue));
        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }

    public void OnUnEquipItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                playerHealth.startingHealth -= item.itemAttributes[i].attributeValue;
            /*if (item.itemAttributes[i].attributeName == "Mana")
                maxMana -= item.itemAttributes[i].attributeValue;*/
            if (item.itemAttributes[i].attributeName == "Armor")
                playerHealth.startingArmor -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                playerShooting.BulletDmg -= item.itemAttributes[i].attributeValue;
        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputManagerDatabase.CharacterSystemKeyCode))
        {
            if (!characterSystem.activeSelf)
            {
                characterSystemInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                characterSystemInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.QuestPanelKeyCode))
        {
            if (!questLogPanel.activeSelf)
            {
                questController.openQuestLog();
            }
            else
            {
                questController.closeQuestLog();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode))
        {
            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.SkillsPanelKeyCode))
        {
            if (!skillsPanel.activeSelf)
            {
                skillsInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                skillsInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode))
        {
            if (!craftSystem.activeSelf)
                craftSystemInventory.openInventory();
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();
            }
        }

    }

}
