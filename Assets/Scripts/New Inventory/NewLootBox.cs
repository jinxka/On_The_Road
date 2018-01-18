using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLootBox : MonoBehaviour {
    
    public NewItem lootboxItem;
    [SerializeField]
    float distanceToOpenBox;
    [SerializeField]
    CanvasGroup lootboxContent;
    [SerializeField]
    NewLootboxTooltip tooltip;
    [SerializeField]
    Image itemIcon;
    [SerializeField]
    ParticleSystem particles;
    private GameObject player;
    private bool isDisplayed = false;

    private void Start()
    {
        var main = particles.main;
        player = GameObject.FindGameObjectWithTag("Player");
        itemIcon.sprite = lootboxItem.itemIcon;
        switch (lootboxItem.itemRarity)
        {
            case NewItem.itemRarities.common:
                main.startColor = new Color(167, 167, 167, 255);
                break;
            case NewItem.itemRarities.rare:
                main.startColor = new Color(0, 23, 255, 255);
                break;
            case NewItem.itemRarities.epic:
                main.startColor = new Color(158, 0, 193, 255);
                break;
            case NewItem.itemRarities.legendary:
                main.startColor = new Color(255, 142, 0, 255);
                break;
        }
    }

    public void ShowTooltip()
    {
        tooltip.ShowTooltip(lootboxItem);
    }
    
    public void HideTooltip()
    {
        tooltip.HideTooltip();
    }

    public void FixedUpdate()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (distance <= distanceToOpenBox && Input.GetKeyDown(NewInputManager.Instance.PickUpLoot))
        {
            GUIManager.Instance.TogglePanel(lootboxContent);
            isDisplayed = !isDisplayed;
        }
        if ((distance > distanceToOpenBox) && isDisplayed)
        {
            HideTooltip();
            GUIManager.Instance.TogglePanel(lootboxContent);
            isDisplayed = !isDisplayed;
        }
    }

    public void PickUpLoot()
    {
        if (NewInventory.Instance.addItemToBackpack(lootboxItem.itemName))
        {
            Destroy(gameObject);
        }
    }
}
