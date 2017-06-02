using UnityEngine;
using System.Collections;

public class BuffDegats : MonoBehaviour {
    private bool buffDegats = false;
    private int damageX = 2;
    public string shortcut;
    public GameObject Aura;

    public float cooldown = 30.0F;
    private float timer = 0.0F;
    public float Duration = 2.0F;
    private float BuffDuration = 0.0f;
    // Use this for initialization
    void Start () {
	
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

    void activeBuff ()
    {
        buffDegats = true;
        Aura.SetActive(true);
        timer = Time.time + Duration + cooldown;
        BuffDuration = Time.time + Duration;
    }

    void deactiveBuff ()
    {
        buffDegats = false;
        Aura.SetActive(false);
    }

    public bool isBuffActive()
    {
        return buffDegats;
    }

    public int getDmgX()
    {
        return damageX;
    }
}
