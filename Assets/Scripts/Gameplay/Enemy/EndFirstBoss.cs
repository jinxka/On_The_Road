using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFirstBoss : MonoBehaviour {
    [SerializeField]
    CanvasGroup progressGroup;

    [SerializeField]
    GameObject SMScreenGroup;

    private EnemyHealth enemyHealth;
    public string textMsg = "Victory";
    private bool update = false;
    private bool updateTimer = true;
    public Text message;
    private float timer;
    // Use this for initialization
    void Start () {
        message.text = textMsg;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void FixedUpdate () {
        if (enemyHealth.currentHealth <= 0)
        {
            SMScreenGroup.SetActive(true);
            progressGroup.alpha = 1;
            if (updateTimer)
            {
                timer = Time.time;
                updateTimer = false;
            }
            if (Time.time - timer > 1)
            {
                if (!update)
                {
                    update = true;
                    message.text = message.text + "\n\n\n\n\n <i>Press ENTER to continue</i>";
                }
                if (Input.GetKeyDown("return"))
                {
                    progressGroup.alpha = 0;
                    SMScreenGroup.SetActive(false);
                    SceneLoading.Instance.loadScene("Zone_Colonie_Safe");
                    Destroy(this);
                }
            }
        }
    }
}
