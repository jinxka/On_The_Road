using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

    public GameObject worldMapCanvas;
    public Light sun;
 
    [SerializeField]
    SceneLoading sceneLoader;

    // Use this for initialization
    void Start () {
		//worldMapCanvas = GameObject.Find ("panelWorldMap");
		//worldMapCanvas.SetActive (false);
	}

	/*public void worldMapPress()
	{
		menuCanvas.SetActive (false);
		//worldMapCanvas.SetActive (true);
	}*/

    public void nightPress()
    {
        if (sun.enabled)
            sun.enabled = false;
        else
            sun.enabled = true;
    }
}
