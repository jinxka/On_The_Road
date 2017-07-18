using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAggro : MonoBehaviour {
	EnemyManager [] managers;
	// Use this for initialization
	void Start () {
		managers = GetComponentsInParent<EnemyManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			foreach (EnemyManager manager in managers)
				manager.SetAggro (true);
		}

	}
}
