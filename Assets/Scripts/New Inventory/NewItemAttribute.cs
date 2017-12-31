using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewItemAttribute {
    public string attributeName;
    public int attributeValue;

    public NewItemAttribute(string attributeName, int attributeValue)
    {
        this.attributeName = attributeName;
        this.attributeValue = attributeValue;
    }

    public NewItemAttribute() { }
}
