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
    // Use this for initialization

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SMScreenGroup.SetActive(true);
        message = GetComponentInChildren<Text>();
        message.text = message.text + "\n\n\n\n\n <i><size=20>Press ENTER to continue</size></i>";
        SMScreenGroup.SetActive(false);
    }
    public void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            SMScreenGroup.SetActive(true);
            Time.timeScale = 0;
            progressGroup.alpha = 1;
            if (Input.GetKeyDown("return"))
            {
                progressGroup.alpha = 0;
                Time.timeScale = 1;
                SMScreenGroup.SetActive(false);
                SceneLoading.Instance.loadScene(SceneManager.GetActiveScene().name);
                Destroy(this);
            }
        }
    }
}
