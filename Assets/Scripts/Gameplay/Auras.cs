using UnityEngine;
using System.Collections;

public class Auras : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = GetComponentInParent<Transform>().position;
	}
}
