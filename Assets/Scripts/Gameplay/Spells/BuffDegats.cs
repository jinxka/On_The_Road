using UnityEngine;
using System.Collections;

public class BuffDegats : MonoBehaviour {
    private bool buffDegats = false;
    private int damageX = 2;
    public GameObject Aura;

    public float cooldown = 30.0F;
    public int Duration = 2;
    // Use this for initialization

    IEnumerator DmgBoost()
    {
        Aura.SetActive(true);
        buffDegats = true;
        yield return new WaitForSeconds(Duration);
        buffDegats = false;
        Aura.SetActive(false);
    }

    public void UseSpell()
    {
        DmgBoost();
    }

    public float GetCooldown()
    {
        return cooldown;
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
