using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {

    EnemyMovement enemyMovement;

    //public EnemyMovement[] friends;

    public List<EnemyMovement> friends;

	private bool activated = false;

	private bool CallHelp = true; 

    // Use this for initialization
    void Start () {
        enemyMovement = GetComponentInParent<EnemyMovement>();
        Collider[] hitColliders = Physics.OverlapSphere(GetComponent<SphereCollider>().center, GetComponent<SphereCollider>().radius);
        foreach (Collider hit in hitColliders)
            friends.Add(hit.gameObject.GetComponent<EnemyMovement>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated)
        {
           enemyMovement.SetAggro(true);
           foreach (EnemyMovement friend in friends)
           {
                if (friend == null)
                    return;
                if (!friend.GetAggro())
                        friend.SetAggro(true);
           }
                activated = true;
        }
    }
}
