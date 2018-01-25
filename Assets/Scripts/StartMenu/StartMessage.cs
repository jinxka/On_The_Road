using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour {

    [SerializeField]
    CanvasGroup progressGroup;

    [SerializeField]
    GameObject SMScreenGroup;

    private float time;
    private Text message;
    private bool update = false;
    // Use this for initialization
    void Start()
    {
        time = Time.time;
        message = GetComponentInChildren<Text>();
        message.text = message.text + "\n\n\n <i><size=20>PRESS ENTER TO CONTINUE</size></i>";
        progressGroup.alpha = 1;
    }

    public void Update()
    {
        Time.timeScale = 0;
        if (Input.GetKeyDown("return"))
        {
            progressGroup.alpha = 0;
            SMScreenGroup.SetActive(false);
            Time.timeScale = 1;
            Destroy(this);
        }
    }
}
