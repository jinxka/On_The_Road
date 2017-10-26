using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem {
    public int id;
    public string name;
    public string description;
    public bool stackable;
    public int currentStacks;
    public int maxStacks;
    public Sprite icon;
    public enum type { gear, skill, consummable, artifact };
    public type itemType;
    public enum rarity { civilian, military, otherworldly };
    public rarity itemRarity;
    public bool locked;
    public InventoryScript inventory;

    public InventoryItem(int _id, string _name, string _description, bool _stackable, int _currentStacks, int _maxStacks, Sprite _icon, type _type, rarity _rarity, bool _locked, InventoryScript _inventory)
    {
        id = _id;
        name = _name;
        description = _description;
        stackable = _stackable;
        currentStacks = _currentStacks;
        maxStacks = _maxStacks;
        icon = _icon;
        itemType = _type;
        itemRarity = _rarity;
        locked = _locked;
    }
}
