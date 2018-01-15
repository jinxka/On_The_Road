using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewLootBoxContent : MonoBehaviour, IPointerClickHandler {

    [SerializeField]
    NewLootBox lootbox;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            lootbox.PickUpLoot();
    }
}
