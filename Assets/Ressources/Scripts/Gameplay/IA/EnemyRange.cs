using UnityEngine;
using System.Collections;

public class EnemyRange : MonoBehaviour {
    GameObject player;
    EnemyRangedMovement movement;

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
