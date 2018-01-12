using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {
	private string baseName = "saveFile_";
	private string FileName = "saveFile_";
    private questManager questManager;

    public void save (int nbrSave = 0) {
		Debug.Log("Save start");
		FileName = baseName + nbrSave + ".otr";
		Debug.Log("FileName = " + FileName);
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream = File.Create (Application.persistentDataPath + FileName);

		SaveManager saver = new SaveManager ();
		saver.nbrSave = nbrSave;
		saver.scene = SceneManager.GetActiveScene ().name;
		saver.modified = DateTime.Now;
        saver.currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth;
//        saver.test = Test.Instance.gameObject;
        Debug.Log("modified = " + saver.modified);
        Debug.Log("currentHealth = " + saver.currentHealth);
        Debug.Log("Scene = " + saver.scene);
        binary.Serialize (fStream, saver);
		fStream.Close ();
		Debug.Log("Game saved");
	}

	public void load (int nbrSave = 0) {
		Debug.Log("load start");
		FileName = baseName + nbrSave + ".otr";
		Debug.Log("FileName = " + FileName);
		if (File.Exists (Application.persistentDataPath + FileName)) {
			Debug.Log(FileName + " exists");
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (Application.persistentDataPath + FileName, FileMode.Open);
			SaveManager saver = (SaveManager)binary.Deserialize (fStream);
// GameObject test = Instantiate(saver.test) as GameObject;
            Debug.Log ("Scene = " + saver.scene);
			Debug.Log ("nbrSave = " + saver.nbrSave);
			fStream.Close ();
            SceneLoading.Instance.loadScene(saver.scene);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth = saver.currentHealth;
        }
		Debug.Log("Load over");
	}

    void updateQuest()
    {
        for (int j = 0; j < questManager.ItemsInInventory.Count; j++)
        {
            if (questManager.ItemsInInventory[j].itemID == 1)
            {
                if (questManager.ItemsInInventory[j].itemValue < questManager.ItemsInInventory[j].itemAttributes[0].attributeValue)
                    questManager.ItemsInInventory[j].itemValue += 1;
                else
                    questManager.ItemsInInventory[j].itemIcon = Resources.Load("Sprites/HUD/Check-sprite-ltr-1.svg", typeof(Sprite)) as Sprite;
            }

        }
    }
		
}

[Serializable]
class SaveManager {
	public int nbrSave;
	public string scene;
	public DateTime modified;
    public float currentHealth;
    public GameObject test;
}