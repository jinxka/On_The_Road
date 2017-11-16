using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveLoadButtonScript : MonoBehaviour {
	private string baseName = "saveFile_";
	private string FileName;
	public int nbrSave = 0;
	public Text buttonText;

	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FileName = baseName + nbrSave + ".otr";
		if (File.Exists (Application.persistentDataPath + FileName))
			buttonText.text = "Save " + nbrSave;
		else
			buttonText.text = "Empty";
	}
}
