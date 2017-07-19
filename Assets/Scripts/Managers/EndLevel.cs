﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
	public Color myFadeColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
        //SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
        Initiate.Fade("Zone_Colonie", myFadeColor, 0.7f);
    }

}
