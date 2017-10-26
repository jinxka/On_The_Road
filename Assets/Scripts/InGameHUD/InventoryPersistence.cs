using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPersistence : MonoBehaviour {
    public static InventoryPersistence inventoryPers;

    void Awake()
    {
        if (inventoryPers == null)
        {
            DontDestroyOnLoad(gameObject);
            inventoryPers = this;
        }
        else if (inventoryPers != this)
            Destroy(gameObject);
    }
}
