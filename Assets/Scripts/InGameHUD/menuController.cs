using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
    
    public Light sun;
    
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
