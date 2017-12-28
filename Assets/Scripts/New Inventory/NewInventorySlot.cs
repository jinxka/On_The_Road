using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventorySlot : MonoBehaviour {

    public enum inventorySlotTypes {head, torso, gloves, pants, boots, common};

    public inventorySlotTypes slotType;

    public bool isAvailable = true;

}
