using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

    public GameObject worldMapCanvas;
    public Light sun;
 
    [SerializeField]
    SceneLoading sceneLoader;
    
    public void nightPress()
    {
        if (sun.enabled)
            sun.enabled = false;
        else
            sun.enabled = true;
    }

    public void reloadGame()
    {
        SceneLoading.Instance.loadScene("Main_Menu");
    }
}
