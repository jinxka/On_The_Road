using UnityEngine;
using System.Collections;

public class deActive : MonoBehaviour {

	public float life = 0.5f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnEnable()
	{
		StartCoroutine (wait ());
	}

	IEnumerator  wait ()
	{
		yield return new WaitForSeconds (life);
		this.gameObject.SetActive (false);
	}
}
