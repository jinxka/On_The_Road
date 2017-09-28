using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerBuff : MonoBehaviour {
	Image fillImg;
	public float timeAmt;
	float time;

	// Use this for initialization
	void Start () {
		fillImg = this.GetComponent<Image> ();
		time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
		}
	}
}
