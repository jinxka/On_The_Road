using UnityEngine;
using System.Collections;

public class Sprint : MonoBehaviour {
    private PlayerMovement playerMovement;

    public float speedMul = 2.0F;
    public string shortcut = "shift";
    public float Duration = 2.0F;
    public float reloadSpeed = 10.0F;

    public float oldSpeed;
    private float nextSpeed = 0.0f;
    private float speedDuration = 0.0f;
    // Use this for initialization
    void Start () {
        playerMovement = GetComponentInParent<PlayerMovement>();
        oldSpeed = playerMovement.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(shortcut) && Time.time > nextSpeed)
        {
            playerMovement.speed = playerMovement.speed * speedMul;
            nextSpeed = Time.time + reloadSpeed;
            speedDuration = Time.time + Duration;
        }
        else if (Time.time > speedDuration)
        {
            playerMovement.speed = oldSpeed;
        }
    }
}
