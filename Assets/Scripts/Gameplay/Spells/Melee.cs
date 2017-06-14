using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
    public float cooldown = 10.0F;
    public GameObject meleeAttack;

    IEnumerator MeleeAttack()
    {
        Instantiate(meleeAttack, transform.position, transform.rotation);
        yield return null;
    }

    public void UseSpell()
    {
        MeleeAttack();
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
