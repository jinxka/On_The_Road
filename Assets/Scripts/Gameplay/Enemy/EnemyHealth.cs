using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //new

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100f;     //changed
    public float currentHealth;             //changed
    public float sinkSpeed = 2.5f;
    public int scoreValue = 1;
    public AudioClip deathClip;
    public float lifetime;

    public Slider healthSlider;                        //new
    public Image FillImage;                           //new
    public Color FullHealthColor = Color.green;      //new
    public Color ZeroHealthColor = Color.red;       //new
    public Canvas healthCanvas;                     //new
	public bool ranged = false;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    public bool isDead = false;
    bool isSinking;

    private questManager QuestManager;

    //Aggro
    private EnemyMovement enemyMovement;
	private EnemyRangedMovement enemyRangedMovement;
    //End Aggro

    //LootBox
    public GameObject LootBox;
    public float DropRate = 100;
    public int minItemInLootBox = 1;
    public int maxItemInLootBox = 3;
    static ItemDataBaseList inventoryItemList;
    private int counter;
    private int creatingItemsForLootBox = 0;
    private int randomItemNumber;
    //end LootBox

    public bool isZombie = false;
    public bool isBoss = false;
    private void Start()
    {
        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
    }

    void Awake ()
    {
        lifetime = 5;
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
        //healthCanvas.enabled = false;        //new
        
		if (ranged)
			enemyRangedMovement = GetComponent<EnemyRangedMovement> ();
		else
        	enemyMovement = GetComponent<EnemyMovement>();
    }


    void FixedUpdate ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;
		if (ranged && (enemyRangedMovement.GetAggro () == false))
			enemyRangedMovement.SetAggro (true);
		else if (enemyMovement.GetAggro () == false)
			enemyMovement.SetAggro (true);
		enemyAudio.Play();

        currentHealth -= amount;

        SetHealthUI();          // new

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
        healthCanvas.enabled = false;       //new
        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        gameObject.layer = 8;
        if (Random.Range(0, 100) < DropRate)
            CreateLootBox();

        if (isZombie)
            this.GetComponent<ZombieQuest>().updateQuest();
        if (isBoss)
            this.GetComponent<BossQuest>().updateQuest();
		StartSinking ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
		GetComponent <CapsuleCollider> ().isTrigger = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
		Destroy (gameObject, lifetime);
    }

    private void SetHealthUI() //new
    {
        if (healthCanvas.enabled == false)
            healthCanvas.enabled = true;
        healthSlider.value = currentHealth;
        FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, currentHealth / startingHealth);
    }

    private void CreateLootBox()
    {
        int itemAmountForLootBox = Random.Range(minItemInLootBox, maxItemInLootBox);
        List<Item> itemsForLootBox = new List<Item>();

        while (creatingItemsForLootBox < itemAmountForLootBox)
        {
            randomItemNumber = Random.Range(1, inventoryItemList.itemList.Count - 1);
            int raffle = Random.Range(1, 100);

            if (raffle <= inventoryItemList.itemList[randomItemNumber].rarity)
            {
                itemsForLootBox.Add(inventoryItemList.itemList[randomItemNumber].getCopy());
                creatingItemsForLootBox++;
            }
        }
        if (itemsForLootBox.Count == 0)
            return;
        Vector3 posLootBox = transform.position;
        posLootBox.y = 0.5f;
        GameObject lootBox = Instantiate(LootBox, posLootBox, transform.rotation); ;
        LootBox sI = LootBox.GetComponent<LootBox>();
        sI.storageItems.Clear();
        for (int i = 0; i < itemsForLootBox.Count; i++)
        {
            sI.storageItems.Add(inventoryItemList.getItemByID(itemsForLootBox[i].itemID));

            int randomValue = Random.Range(1, sI.storageItems[sI.storageItems.Count - 1].maxStack);
            sI.storageItems[sI.storageItems.Count - 1].itemValue = randomValue;
        }
    }
}
