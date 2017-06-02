using UnityEngine;
using System.Collections;

public class ForceFields : MonoBehaviour {
    public GameObject forcefield;

    private PlayerHealth playerhealth;
    public string shortcut;
    public float cooldown = 30.0F;
    private float timer = 0.0F;
    public float Duration = 5.0F;
    private float BuffDuration = 0.0f;
    // Use this for initialization
    void Start () {
       playerhealth = this.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(shortcut) && Time.time >= timer && Time.timeScale != 0)
        {
            activeBuff();
        }
        else if (Time.time > BuffDuration)
        {
            deactiveBuff();
        }
    }
    void activeBuff()
    {
        playerhealth.ForceField(true);
        forcefield.SetActive(true);
        timer = Time.time + Duration + cooldown;
        BuffDuration = Time.time + Duration;
    }

    void deactiveBuff()
    {
        playerhealth.ForceField(false);
        forcefield.SetActive(false);
    }
}
