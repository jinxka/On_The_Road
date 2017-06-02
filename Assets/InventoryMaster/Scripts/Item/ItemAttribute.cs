using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemAttribute
{

    public string attributeName;
    public int attributeValue;
    //public int objectiveValue;
    public ItemAttribute(string attributeName, int attributeValue)//, int objectiveValue)
    {
        this.attributeName = attributeName;
        this.attributeValue = attributeValue;
        //this.objectiveValue = objectiveValue;
    }

    public ItemAttribute() { }

}

