using UnityEngine;
using System.Collections;

public class QuickShot : MonoBehaviour {
    public Rigidbody shrapnelCasing = null;
    public int ejectSpeed = 50;
    public float fireRate = 1F;
    public Tir_normal test;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            StartCoroutine("quickShot");
        }
	}

    IEnumerator quickShot()
    {
        while (test.clip >= 1)
        {
            test.shoot();
            test.clip = test.clip - 1;
            yield return new WaitForSeconds(fireRate);
        }
    }

}
