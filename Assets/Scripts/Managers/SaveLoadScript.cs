using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {
	private SceneLoading sceneLoading;
	private string baseName = "saveFile_";
	private string FileName = "saveFile_";
	// Use this for initialization
	void Start () {
		sceneLoading = this.GetComponent<SceneLoading> ();
	}

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
			Debug.Log ("Scene = " + saver.scene);
			Debug.Log ("nbrSave = " + saver.nbrSave);
			fStream.Close ();
			sceneLoading.loadScene(saver.scene);
		}
		Debug.Log("Load over");
	}
		
}

[Serializable]
class SaveManager {
	public int nbrSave;
	public string scene;
	public DateTime modified;
}