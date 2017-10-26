using UnityEngine;
using System.Collections;

public class flyObject : MonoBehaviour {


	public float speed = 6f;
	public bool canDie = false;
	private float dieTime = 0f;
	public float timeLimit = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (Vector3.forward*Time.deltaTime*-speed);


		if (canDie)
		{
			dieTime += Time.deltaTime;
			if (dieTime > timeLimit) 
			{
				Destroy (this.gameObject);
				dieTime = 0f;
			}
		
		}
	
	}
}
