using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject mapPanel;
    public GameObject menuCanvas;
    public GameObject exitCanvas;
    public GameObject optionsCanvas;
    public GameObject errorCanvas;
	public GameObject worldMapCanvas;
    //public Canvas inventoryCanvas;
    public Button menuButton;
    public menuController menuController;
    public Camera cam;
    public Canvas UiCanvas;

	// Use this for initialization
	void Start () {
        menuCanvas.SetActive(false);
		worldMapCanvas.SetActive (false);
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        //inventoryCanvas.enabled = false;
        errorCanvas.SetActive(false);
		mapPanel = GameObject.Find ("Panel");
		mapPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if (menuCanvas.activeSelf == false) {
				closeAllPanels ();
				menuPress ();
			} else
				menuController.closeMenu ();
		} else if (Input.GetKey (KeyCode.Tab)) {
			if (mapPanel.activeSelf == false)
				mapPanel.SetActive (true);
			else
				mapPanel.SetActive (false);
		}

        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryCanvas.enabled == false)
                inventoryOpen();
            else
                inventoryClose();
        }*/
    }

    public void menuPress()
    {
        //Time.timeScale = 0;
        menuCanvas.SetActive(true);
        menuButton.enabled = false;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = true;
    }

   /* public void inventoryOpen()
    {
        //Time.timeScale = 0;
        inventoryCanvas.enabled = true;
        UiCanvas.enabled = false;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = true;
    }

    public void inventoryClose()
    {
        //Time.timeScale = 1;
        inventoryCanvas.enabled = false;
        UiCanvas.enabled = true;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = false;
    }*/

    public void closeAllPanels()
    {
        menuCanvas.SetActive(false);
        //inventoryClose();
        menuController.closePanels();
    }
}

