using UnityEngine;
using UnityEngine.UI; //new

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100f;     //changed
    public float currentHealth;             //changed
    public float sinkSpeed = 2.5f;
    public int scoreValue = 1;
    public AudioClip deathClip;
    public GameObject coins;
    public float lifetime;

    public Slider healthSlider;                        //new
    public Image FillImage;                           //new
    public Color FullHealthColor = Color.green;      //new
    public Color ZeroHealthColor = Color.red;       //new
    public Canvas healthCanvas;                     //new

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    private questManager QuestManager;


    void Awake ()
    {
        lifetime = 5;
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
        healthCanvas.enabled = false;        //new
        QuestManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<questManager>();
    }


    void Update ()
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

        enemyAudio.Play ();

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
        Vector3 posCoins = transform.position;
        posCoins.y = 0.75f;
        Instantiate(coins, posCoins, transform.rotation);
        Destroy(gameObject, lifetime);

        //QuestManager.ItemsInInventory[0].
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }

    private void SetHealthUI() //new
    {
        if (healthCanvas.enabled == false)
            healthCanvas.enabled = true;
        healthSlider.value = currentHealth;
        FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, currentHealth / startingHealth);
    }
}
