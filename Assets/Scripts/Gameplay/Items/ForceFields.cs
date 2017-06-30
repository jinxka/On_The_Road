using UnityEngine;
using System.Collections;

public class ForceFields : MonoBehaviour {

    public float cooldown = 30.0F;
    public float Duration = 5.0F;
    public GameObject forcefield;

    private PlayerHealth playerhealth;

    // Use this for initialization
    void Start () {
       playerhealth = this.GetComponent<PlayerHealth>();
	}

    IEnumerator DefBoost()
    {
        forcefield.SetActive(true);
        playerhealth.ForceField(true);
        yield return new WaitForSeconds(Duration);
        playerhealth.ForceField(false);
        forcefield.SetActive(false);
    }

    public void UseSpell()
    {
        DefBoost();
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
