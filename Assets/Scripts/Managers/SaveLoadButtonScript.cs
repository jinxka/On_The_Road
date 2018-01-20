using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveLoadButtonScript : MonoBehaviour {
	private string baseName = "saveFile_";
	private string FileName;
    public int[] nbrSave;
    public Text[] buttonText;
    // Use this for initialization

    void Start () {
	}

    public void ButtonText()
    {
        foreach (int save in nbrSave)
        {
            FileName = baseName + save + ".otr";
            if (File.Exists(Application.persistentDataPath + FileName))
            {
                Debug.Log(Application.persistentDataPath);
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fStream = File.Open(Application.persistentDataPath + FileName, FileMode.Open);
                SaveManager saver = (SaveManager)binary.Deserialize(fStream);
                Debug.Log("modified = " + saver.modified);
                buttonText[save].text = saver.modified.ToString("dd/MM/yyyy\nHH:mm:ss");
                fStream.Close();
            }
            else
                buttonText[save].text = "Empty";
        }
    }
}
