using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightClickAttack : MonoBehaviour
{

    bool onCooldown = false;
    float currentTime;
    public Image cooldownImage;
    public float cooldown = 3.0F;
    public Rigidbody grenadeCasing = null;
    public int ejectSpeed = 100;

    public void UseSpell()
    {
        if (!onCooldown)
        {
            StartCoroutine(triggerCooldown());
            Shoot_Grenade();
        }
    }

    private IEnumerator triggerCooldown()
    {
        onCooldown = true;
        while (cooldownImage.fillAmount > 0)
        {
            currentTime -= Time.deltaTime;
            cooldownImage.fillAmount = currentTime / cooldown;
            yield return null;
        }
        onCooldown = false;
        cooldownImage.enabled = false;
    }

    private void Shoot_Grenade()
    {
        AudioManager.instance.Play("GrenadeShoot");

        Rigidbody grenade = null;
        grenade = Instantiate(grenadeCasing, Tir_normal.Instance.gameObject.transform.position, Tir_normal.Instance.gameObject.transform.rotation);
        grenade.velocity = Tir_normal.Instance.gameObject.transform.TransformDirection(new Vector3(0, 0, 1) * ejectSpeed);
        grenade.transform.Rotate(Vector3.right * 180);
    }
}