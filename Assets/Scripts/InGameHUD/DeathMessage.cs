using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMessage : MonoBehaviour {

    [SerializeField]
    CanvasGroup progressGroup;

    [SerializeField]
    GameObject SMScreenGroup;

    private GameObject player;
    private bool update = false;
    private bool updateTimer = true;
    private Text message;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
    public void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            SMScreenGroup.SetActive(true);
            progressGroup.alpha = 1;
            if (updateTimer)
            {
                message = GetComponentInChildren<Text>();
                timer = Time.time;
                updateTimer = false;
            }
            if (Time.time - timer > 1)
            {
                if (!update)
                {
                    update = true;
                    message.text = message.text + "\n\n\n\n\n <b><i>Press ENTER to continue</i></b>";
                }
                if (Input.GetKeyDown("return"))
                {
                    progressGroup.alpha = 0;
                    SMScreenGroup.SetActive(false);
                    SceneLoading.Instance.loadScene(SceneManager.GetActiveScene().name);
                    Destroy(this);
                }
            }
        }
    }
}
