using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConsumable : MonoBehaviour {
    public void Consume(NewItem item)
    {
        if (item.gameObject.name == "Mine")
        { }
        else
            NewInventory.Instance.AddToPlayerStats(item);
    }
}
