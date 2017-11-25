using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryPersistence : MonoBehaviour {

    #region UnityCompliant Singleton
    public static InventoryPersistence Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    #endregion

    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    [SerializeField]
    CanvasGroup inventoryUI;

    public void hideInventory()
    {
        inventoryUI.blocksRaycasts = false;
        inventoryUI.alpha = 0f;
        inventoryUI.interactable = false;
    }

    public void showInventory()
    {
        inventoryUI.blocksRaycasts = true;
        inventoryUI.alpha = 1f;
        inventoryUI.interactable = true;
    }
}
