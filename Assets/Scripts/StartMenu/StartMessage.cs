using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour {

    [SerializeField]
    CanvasGroup progressGroup;

    private float time;
    private Text message;
    private bool update = false;
    // Use this for initialization
    void Start()
    {
        time = Time.time;
        message = GetComponentInChildren<Text>();
    }

    public void FixedUpdate()
    {
        progressGroup.alpha = 1;
        if (Time.time - time > 1)
        {
            if (!update)
            {
                update = true;
                message.text = message.text + "\n\n\n <b><i>PRESS ENTER TO CONTINUE</i></b>";
            }
            if (Input.GetKeyDown("return"))
            {
                progressGroup.alpha = 0;
                Destroy(this);
            }
        }
    }
}
