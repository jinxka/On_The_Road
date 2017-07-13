using UnityEngine;
using System.Collections;

public class EnemyRange : MonoBehaviour {
    GameObject player;
    EnemyRangedMovement movement;
	public EnemyMovement [] friends;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = GetComponentInParent<EnemyRangedMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
			if (!movement.GetAggro ()) {
				movement.SetAggro (true);
				foreach (EnemyMovement friend in friends) {
					if (!friend.GetAggro())
						friend.SetAggro (true);
				}
			}
            movement.setPlayerInRange(true);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            movement.setPlayerInRange(false);
        }
    }
}
