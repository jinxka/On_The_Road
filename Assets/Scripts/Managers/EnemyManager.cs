using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public int numbers = 1;
	private int count = 0;
	public bool aggro = false;
	public bool ranged = false;
	private bool open = false;

	void Update()
	{
		if (aggro && !open) {
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
			open = true;
		}
		if (count >= numbers)
			CancelInvoke();
	}


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        GameObject monster = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		if (ranged)
			monster.GetComponent<EnemyRangedMovement> ().SetAggro (true);
		else
			monster.GetComponent<EnemyMovement> ().SetAggro (true);
		count++;
    }

	public void SetAggro(bool atRange)
	{
		aggro = atRange;
	}
}
