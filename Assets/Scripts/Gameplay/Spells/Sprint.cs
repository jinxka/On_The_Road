using UnityEngine;
using System.Collections;

public class Sprint : MonoBehaviour {

    public float speedBonus = 2.0F;
    public float Duration = 2.0F;
    public float cooldown = 10.0F;

    private float oldSpeed;
    private PlayerMovement playerMovement;

    // Use this for initialization
    void Start () {
        playerMovement = GetComponentInParent<PlayerMovement>();
        oldSpeed = playerMovement.speed;
    }

    IEnumerator SpeedBoost()
    {
        //Aura.SetActive(true);
        playerMovement.speed = playerMovement.speed + speedBonus;
        yield return new WaitForSeconds(Duration);
        playerMovement.speed = oldSpeed;
        //Aura.SetActive(false);
    }

    public void UseSpell()
    {
        SpeedBoost();
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
