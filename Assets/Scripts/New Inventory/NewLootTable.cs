using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewLootTable : MonoBehaviour {

    public List<NewItem> itemList;
    private float[] randomNumbers;

    private void Start()
    {
        randomNumbers = new float[itemList.Count];
    }

    public NewItem GenerateItem()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            switch (itemList[i].itemRarity)
            {
                case NewItem.itemRarities.common:
                    randomNumbers[i] = Random.Range(0, 100);
                    break;
                case NewItem.itemRarities.rare:
                    randomNumbers[i] = Random.Range(0, 60);
                    break;
                case NewItem.itemRarities.epic:
                    randomNumbers[i] = Random.Range(0, 40);
                    break;
                case NewItem.itemRarities.legendary:
                    randomNumbers[i] = Random.Range(0, 20);
                    break;
            }
        }

        for (int j = 0; j < itemList.Count; j++)
        {
            if (randomNumbers[j] == randomNumbers.Max())
                return itemList[j];
        }

        return null;
    }
}
