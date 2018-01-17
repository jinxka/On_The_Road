using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMessage : MonoBehaviour {

    [SerializeField]
    CanvasGroup progressGroup;

    // Use this for initialization
    public void FixedUpdate()
    {
        progressGroup.alpha = 1;
        if (Input.anyKey)
        {
            progressGroup.alpha = 0;
            Destroy(this);
        }
    }
}
