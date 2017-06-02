using UnityEngine;
using System.Collections;

public class LandMines : MonoBehaviour {
    public Rigidbody landMineCasing = null;
    public float fireRate = 1F;

    private float nextFire = 0.0F;

    public string shortcut;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(shortcut) && Time.time > nextFire)
        {
                use_landMine();
        }
    }

    public void use_landMine()
    {
        nextFire = Time.time + fireRate;

        Rigidbody mine = null;
        mine = Instantiate(landMineCasing);
        mine.transform.position = transform.position;
    }
}
