using UnityEngine;
using System.Collections;

public class EnemyRangedMovement : MonoBehaviour
{
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    bool playerInRange = false;
    bool retreat = false;
    public bool isMelee = false;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && (!playerInRange || retreat ))
        {
            nav.enabled = true;

            if (retreat && !isMelee)
            {
                nav.SetDestination((player.transform.position - transform.position) * -2);
            }
            else
            {
                nav.SetDestination(player.transform.position);
            }
        }
        else
        {
            nav.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (!retreat)
            Turning();
    }

        void Turning()
    {
            Vector3 playerToMouse = player.transform.position - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
    }

    public bool getPlayerInRange()
    {
        return playerInRange;
    }

    public void setPlayerInRange(bool inRange)
    {
        playerInRange = inRange;
    }

    public void setRetreat(bool danger)
    {
        retreat = danger;
    }

    public bool getRetreat()
    {
        return retreat;
    }

    public bool getIsMelee()
    {
        return isMelee;
    }
}
