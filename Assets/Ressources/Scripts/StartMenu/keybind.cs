using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class keybind : MonoBehaviour {


    private string bindString;
    private string bindText;

	// Use this for initialization
	void Start () {
        bindText = this.transform.GetChild(1).GetComponent<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setString(string newString)
    {
        bindString = newString;
    }

    public string getString()
    {
        return (bindString);
    }

    public void setText(string newText)
    {
        this.transform.GetChild(1).GetComponent<Text>().text = newText;
        bindText = newText;
    }

    public string getText()
    {
        return bindText;
    }


}
