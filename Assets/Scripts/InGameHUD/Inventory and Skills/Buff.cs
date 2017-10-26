using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff {
    public int id;
    public string name;
    public string description;
    public float duration;
    public Sprite icon;
    public PlayerHealth playerHealth;

    public Buff (int _id, string _name, string _description, float _duration, Sprite _icon, PlayerHealth _pH)
    {
        id = _id;
        name = _name;
        description = _description;
        duration = _duration;
        icon = _icon;
        playerHealth = _pH;
    }
}
