using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playScript : MonoBehaviour {

    public Button playButton;
    public Color myFadeColor;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void launchGame()
    {
        Initiate.Fade("Zone_Introduction", myFadeColor, 0.7f);
    }
}
