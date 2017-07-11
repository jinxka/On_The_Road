using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class optionsScript : MonoBehaviour {

    public Canvas optionsCanvas;
    public Canvas menuCanvas;
    public Canvas errorCanvas;
    public Button[] panel = new Button[3];
    public GameObject audioButtons;
    public GameObject videoButtons;
    public GameObject controlsButtons;
    public SortedList modificationsList = new SortedList();

	// Use this for initialization
	void Start () {
        optionsCanvas.enabled = false;
        audioButtons.SetActive(false);
        videoButtons.SetActive(false);
        controlsButtons.SetActive(false);
        errorCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (optionsCanvas.enabled == true)
        {
            if (Input.GetKeyDown("space"))
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
    }

    public void OptionsPress ()
    {
        optionsCanvas.enabled = true;
        menuCanvas.enabled = false;
        //Time.timeScale = 0;
    }

    public void Back ()
    {
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
        //Time.timeScale = 1;
    }

    public void HideOptions()
    {
        audioButtons.SetActive(false);
        videoButtons.SetActive(false);
        controlsButtons.SetActive(false);
    }

    public void AudioPress()
    {
        HideOptions();
        audioButtons.SetActive(true);
    }

    public void VideoPress()
    {
        HideOptions();
        videoButtons.SetActive(true);
    }

    public void ControlsPress()
    {
        HideOptions();
        controlsButtons.SetActive(true);
    }

/*    public void addToList(object key, object value)
    {
        modificationsList[key] = value;
    }
*/

    public void saveChanges()
    {
  /*      for (int i = 0; i < modificationsList.Count; i++)
        {
            PlayerPrefs.SetInt(modificationsList.GetKey(i).ToString(), Convert.ToInt32(modificationsList.GetByIndex(i)));
        } */
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
        //Time.timeScale = 1;
    }

    public void restoreDefaults()
    {
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
        //Time.timeScale = 1;
    }
}
