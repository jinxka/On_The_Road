using System.Collections;
using UnityEngine;

public class LandMines : MonoBehaviour {
    public GameObject landMineCasing = null;
    public float cooldown = 1F;

    public void FixedUpdate()
    {
        if (Input.GetKeyDown("k"))
            UseSpell();
    }

    public void UseSpell()
    {
        GameObject mine;
        mine = Instantiate(landMineCasing, transform.position, transform.rotation);
        mine.transform.Rotate(Vector3.right * 90);
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
