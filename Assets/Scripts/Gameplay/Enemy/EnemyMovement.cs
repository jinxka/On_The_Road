using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    public bool Aggro = false;
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
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && Aggro && (Vector3.Distance(this.transform.position, player.transform.position) >= nav.stoppingDistance))
        {
            Turning();
            anim.SetBool(animRun, true);
            nav.updatePosition = true;
            nav.SetDestination(player.position);
            if (Vector3.Distance(this.transform.position, player.position) >= 50)
                Aggro = false;
        }
        else
        {
            anim.SetBool(animRun, false);
            nav.updatePosition = false;
        }
    }

    void Turning()
    {
        Vector3 playerToMouse = player.transform.position - transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        GetComponent<Rigidbody>().MoveRotation(newRotation);
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
