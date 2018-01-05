using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BuffDegats : MonoBehaviour {
    public bool buffDegats = false;
    public int damageX = 2;
	private GameObject Aura;

    public float cooldown = 30.0F;
    public int Duration = 2;
    bool onCooldown = false;

    float currentTime;

    [SerializeField]
    Image cooldownImage;

    public void UseSpell()
    {
		AudioManager.instance.Play("DamageBuff");
	
        if (onCooldown)
            return;
        if (Aura == null)
            Aura = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().aura;
        float startTime = Time.time;
        cooldownImage.enabled = true;
        currentTime = cooldown;
        cooldownImage.fillAmount = 1f;
        StartCoroutine(triggerCooldown(startTime));
        StartCoroutine(triggerBuff());
    }

    private IEnumerator triggerCooldown(float startTime)
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

    private IEnumerator triggerBuff()
    {
        Aura.SetActive(true);
        buffDegats = true;
        yield return new WaitForSeconds(Duration);
        Aura.SetActive(false);
        buffDegats = false;
    }

    void Start()
    {
        Aura = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().aura;
    }
}
