using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

    public GameObject menuCanvas;
    public Canvas UICanvas;
    public GameObject exitCanvas;
    public GameObject optionsCanvas;
	public GameObject worldMapCanvas;
    public Light sun;
    public Camera cam;

    // Use this for initialization
    void Start () {
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
		//worldMapCanvas = GameObject.Find ("panelWorldMap");
		//worldMapCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void closeMenu()
    {
        Time.timeScale = 1;
        menuCanvas.SetActive(false);
        UICanvas.enabled = true;
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
		//worldMapCanvas.SetActive (false);
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = false;
    }

    public void exitPress()
    {
        exitCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
		//worldMapCanvas.SetActive (false);

    }

    public void exitYes()
    {
        Time.timeScale = 1;
        Initiate.Fade("Main_Menu", Color.black, 1.5f);
    }

    public void optionsPress()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

	public void worldMapPress()
	{
		menuCanvas.SetActive (false);
		//worldMapCanvas.SetActive (true);
	}

    public void optionsBackPress()
    {
        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(true); 
    }

    public void nightPress()
    {
        if (sun.enabled)
            sun.enabled = false;
        else
            sun.enabled = true;
    }

    public void closePanels()
    {
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
		//worldMapCanvas.SetActive (false);
    }
}
