using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      Vector3 eulerAngles = transform.eulerAngles;
     eulerAngles.y = 0;
     eulerAngles.z = 0;
     transform.eulerAngles = eulerAngles;
	}
}
