using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightClickAttack : MonoBehaviour {

    bool onCooldown = false;
    float currentTime;
    public Image cooldownImage;
    public float cooldown = 3.0F;

    public void UseSpell()
    {
        StartCoroutine(triggerCooldown());
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
}
