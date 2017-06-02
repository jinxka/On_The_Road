using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
    public float cooldown = 10.0F;
    
    private float timer = 0.0F;
    
    public string shortcut;

    public GameObject meleeAttack;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(shortcut) && Time.time >= timer && Time.timeScale != 0)
        {
            Instantiate(meleeAttack, transform.position, transform.rotation);
            timer = Time.time + cooldown;
        }
    }
}
