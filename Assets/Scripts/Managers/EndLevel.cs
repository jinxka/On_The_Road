using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    SceneLoading sceneLoading;

	void OnTriggerEnter(Collider other)
	{
        sceneLoading.loadScene("Zone_Tunnel");
    }

}
