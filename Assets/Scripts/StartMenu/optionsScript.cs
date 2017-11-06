using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class optionsScript : MonoBehaviour {

    public GameObject audioPanel;
    public GameObject videoPanel;
    public GameObject controlsPanel;
    public SortedList modificationsList = new SortedList();

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
        {
            Back();
        }
        else if (Input.GetKeyDown("return"))
        {
            saveChanges();
        }
        else if (Input.GetKeyDown("delete"))
        {
           restoreDefaults();
        }
    }

    public void Back ()
    {
        this.gameObject.SetActive(false);
    }

    public void HideOptions()
    {
        audioPanel.SetActive(false);
        videoPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void saveChanges()
    {
        this.gameObject.SetActive(false);
    }

    public void restoreDefaults()
    {
        this.gameObject.SetActive(false);
    }
}
