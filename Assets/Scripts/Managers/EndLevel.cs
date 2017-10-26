using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    SceneLoading sceneLoading;

    [SerializeField]
    string sceneToLoad;

    void OnTriggerEnter(Collider other)
	{
        sceneLoading.loadScene(sceneToLoad);
    }

}
