using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    //public GameObject mapPanel;
    public CanvasGroup menuCanvas;
	//public GameObject worldMapCanvas;
    //public Canvas inventoryCanvas;
    public Button menuButton;
    public Camera cam;
    public Canvas UiCanvas;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
            if (menuCanvas.alpha == 0)
                openMenu();
            else
                closeMenu();
		} /*else if (Input.GetKey (KeyCode.Tab)) {
			if (mapPanel.activeSelf == false)
				mapPanel.SetActive (true);
			else
				mapPanel.SetActive (false);
		}*/
    }

    public void openMenu()
    {
        menuCanvas.alpha = 1;
        menuCanvas.interactable = true;
        menuCanvas.blocksRaycasts = true;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = true;
    }

    public void closeMenu()
    {
        menuCanvas.alpha = 0;
        menuCanvas.interactable = false;
        menuCanvas.blocksRaycasts = false;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = false;
    }
}

