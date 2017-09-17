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


    private Vector3 direction;
    private Vector3 localDirection;
    private float localDirectionZ;
    private float localDirectionX;
    private Vector3 lastPosition;
	private bool Aggro = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
		if (Aggro && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && (!playerInRange || retreat ))
        {
            nav.updatePosition = true;

            if (retreat && !isMelee)
            {
                FindVelocity();
                nav.SetDestination(transform.position + direction);
                Debug.LogError(direction);
            }
            else
            {
                nav.SetDestination(player.transform.position);
            }
        }
        else
        {
            nav.updatePosition = false;
		}

		if (!retreat)
			Turning();

    }

    private void FindVelocity()
    {
        lastPosition = player.transform.position;
        direction = transform.position - lastPosition;
        localDirection = transform.InverseTransformDirection(direction);
        localDirectionZ = Mathf.Clamp(transform.InverseTransformDirection(direction).z, -1, 1);
        localDirectionX = Mathf.Clamp(transform.InverseTransformDirection(direction).x, -1, 1);

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

	public void SetAggro(bool aggro)
	{
		Aggro = aggro;
	}

	public bool GetAggro()
	{
		return Aggro;
	}
}
