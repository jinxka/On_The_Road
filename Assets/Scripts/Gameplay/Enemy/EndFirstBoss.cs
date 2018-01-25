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
        enemyHealth = GetComponent<EnemyHealth>();
        SMScreenGroup.SetActive(true);
        message.text = textMsg;
        message.text = message.text + "\n\n\n\n\n <i><size=20>Press ENTER to continue</size></i>";
        SMScreenGroup.SetActive(false);
    }

    void Update () {
        if (enemyHealth.currentHealth <= 0)
        {
            Time.timeScale = 0;
            SMScreenGroup.SetActive(true);
            progressGroup.alpha = 1;
            if (Input.GetKeyDown("return"))
            {
                Time.timeScale = 1;
                progressGroup.alpha = 0;
                SMScreenGroup.SetActive(false);
                SceneLoading.Instance.loadScene("Zone_Colonie_Safe");
                Destroy(this);
            }
        }
    }
}
