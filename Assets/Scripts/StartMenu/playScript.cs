using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class playScript : MonoBehaviour {
    [SerializeField]
    SceneLoading sceneLoading;

    public void newGame()
    {
        sceneLoading.loadScene("Zone_Introduction");
    }
}
