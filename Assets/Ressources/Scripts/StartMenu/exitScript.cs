using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class exitScript : MonoBehaviour {

    public Canvas quitCanvas;
    public Button newGameButton;
    public Button loadGameButton;
    public Button optionsButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {
        quitCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void ExitPress()
    {
        quitCanvas.enabled = true;
        newGameButton.enabled = false;
        loadGameButton.enabled = false;
        optionsButton.enabled = false;
        exitButton.enabled = false;
        Time.timeScale = 0;
    }

    public void NoPress()
    {
        quitCanvas.enabled = false;
        newGameButton.enabled = true;
        loadGameButton.enabled = true;
        optionsButton.enabled = true;
        exitButton.enabled = true;
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
