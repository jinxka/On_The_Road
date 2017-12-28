using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxAnimController : MonoBehaviour
{
    [SerializeField]
    GameObject shortcutCanvas;

    private void Start()
    {
        shortcutCanvas.transform.rotation = Quaternion.Euler(60, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shortcutCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            shortcutCanvas.SetActive(false);
        }
    }
}
