using UnityEngine;
using System.Collections;

public class LandMines : MonoBehaviour {
    public Rigidbody landMineCasing = null;
    public float cooldown = 1F;

    public void UseSpell()
    {
        Instantiate(landMineCasing, transform.position, transform.rotation);
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
