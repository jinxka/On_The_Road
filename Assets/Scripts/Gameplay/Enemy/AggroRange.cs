using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {

    EnemyMovement enemyMovement;
    public bool LinkAggro = false;

    // Use this for initialization
    void Start () {
        enemyMovement = GetComponentInParent<EnemyMovement>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            enemyMovement.SetAggro(true);

    }

    private void OnTriggerStay(Collider other)
    {
        if (LinkAggro && enemyMovement.GetAggro() && other.tag == "Enemies")
        {
            if (!other.GetComponent<EnemyMovement>().GetAggro())
                other.GetComponent<EnemyMovement>().SetAggro(true);
        }
    }
}
