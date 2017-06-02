using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Image newGameImage;
    public Image optionsImage;
    public Image exitImage;
    public Image loadImage;

    public Button newGameButton;
    public Button loadGameButton;
    public Button optionsButton;
    public Button exitButton;
	// Use this for initialization
	void Start () {
        newGameImage.enabled = false;
        optionsImage.enabled = false;
        exitImage.enabled = false;
        loadImage.enabled = false;
    }
	
    public void newGameHover()
    {
        if (newGameButton.enabled == true)
        {
            newGameImage.enabled = true;
        }
    }

    public void newGameHoverOff()
    {
        newGameImage.enabled = false;
    }

    public void loadGameHover()
    {
        if (loadGameButton.enabled == true)
        {
            loadImage.enabled = true;
        }
    }

    public void loadGameHoverOff()
    {
        loadImage.enabled = false;
    }

    public void optionsHover()
    {
        if (optionsButton.enabled == true)
        {
            optionsImage.enabled = true;
        }
    }

    public void optionsHoverOff()
    {
        optionsImage.enabled = false;
    }

    public void exitHover()
    {
        if (exitButton.enabled == true)
        {
            exitImage.enabled = true;
        }
    }

    public void exitHoverOff()
    {
        exitImage.enabled = false;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
