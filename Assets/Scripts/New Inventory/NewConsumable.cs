using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConsumable : MonoBehaviour {
    public void Consume(NewItem item)
    {
        switch (item.gameObject.name)
        {
            case "Mine":
                break;
            default:
                NewInventory.Instance.AddToPlayerStats(item);
                break;
        }
    }
}
