using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    string sceneToLoad;

    void OnTriggerEnter(Collider other)
	{
        SceneLoading.Instance.loadScene(sceneToLoad);
    }

}
