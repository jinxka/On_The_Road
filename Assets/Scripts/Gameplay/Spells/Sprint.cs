using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sprint : MonoBehaviour {

    public float speedBonus = 2.0F;
    public float Duration = 2.0F;
    public float cooldown = 10.0F;

    private float oldSpeed;
    private PlayerMovement playerMovement;


    bool onCooldown = false;

    float currentTime;

    [SerializeField]
    Image cooldownImage;

    // Use this for initialization
    void Start () {
        setVariables();
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
        playerMovement.speed = playerMovement.speed + speedBonus;
        yield return new WaitForSeconds(Duration);
        playerMovement.speed = oldSpeed;
    }

    public void UseSpell()
    {
        if (onCooldown)
            return;
        if (playerMovement == null)
            setVariables();
        float startTime = Time.time;
        currentTime = cooldown;
        cooldownImage.enabled = true;
        cooldownImage.fillAmount = 1f;
        StartCoroutine(triggerCooldown(startTime));
        StartCoroutine(triggerBuff());
    }

    void setVariables()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        oldSpeed = playerMovement.speed;
    }
}
