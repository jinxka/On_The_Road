using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {

    EnemyMovement enemyMovement;
	public EnemyMovement [] friends ;

	private bool activated = false;

	private bool CallHelp = true; 

    // Use this for initialization
    void Start () {
        enemyMovement = GetComponentInParent<EnemyMovement>();
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player" && !activated) {
			enemyMovement.SetAggro (true);
			foreach (EnemyMovement friend in friends) {
				if (!friend.GetAggro())
					friend.SetAggro (true);
			}
			activated = true;
		}

    }

//    private void OnTriggerStay(Collider other)
//    {
//		if (LinkAggro && enemyMovement.GetAggro() && other.tag == "Enemies" && CallHelp)
//		{
//            if (!other.GetComponent<EnemyMovement>().GetAggro())
//                other.GetComponent<EnemyMovement>().SetAggro(true);
//			CallHelp = false;
//        }
//    }
}
