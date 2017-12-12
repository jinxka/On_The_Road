using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    private bool Aggro = false;
	public bool dontMove = false;
    public string animRun;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    void FixedUpdate ()
    {
		if (dontMove)
			return;
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && Aggro)
        {
            anim.SetBool(animRun, true);
            nav.updatePosition = true;
            nav.SetDestination(player.position);
        }
        else
        {
            anim.SetBool(animRun, false);
            nav.updatePosition = false;
        }
    }

    public void SetAggro(bool aggro)
    {
        Aggro = aggro;
    }

    public bool GetAggro()
    {
        return Aggro;
    }
}
