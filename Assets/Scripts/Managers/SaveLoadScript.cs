using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {
	private int nbrSave = 0;
	private string baseName = "saveFile_";
	private string FileName = "saveFile_";

	// Use this for initialization
	void Start () {
	}

	public void save () {
		Debug.Log("Save start");
		FileName = baseName + nbrSave + ".otr";
		Debug.Log("FileName = " + FileName);
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream = File.Create (Application.persistentDataPath + FileName);

		SaveManager saver = new SaveManager ();
		saver.nbrSave = nbrSave;

		binary.Serialize (fStream, saver);
		fStream.Close ();
		Debug.Log("Game saved");
		Debug.Log("Game saved");
	}

	public void load () {
		Debug.Log("load start");
		Debug.Log("FileName = " + FileName);
		if (File.Exists (Application.persistentDataPath + FileName)) {
			Debug.Log(FileName + "+ exist");
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (Application.persistentDataPath + FileName, FileMode.Open);
			SaveManager saver = (SaveManager)binary.Deserialize (fStream);
			fStream.Close ();
			SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
			Debug.Log("Game loaded");
		}
		Debug.Log("Load over");
	}
		
}

[Serializable]
class SaveManager {
	public int nbrSave;
}