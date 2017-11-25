using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour {

    [SerializeField]
    Transform teleportLocation;

    [SerializeField]
    Image loadScreen;

    Transform playerLocation;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        playerLocation = other.transform;
        StartCoroutine(startTeleport());
    }

    private IEnumerator startTeleport()
    {
        loadScreen.gameObject.SetActive(true);
        loadScreen.canvasRenderer.SetAlpha(0f);
        loadScreen.CrossFadeAlpha(0.99f, 1f, false);
        yield return new WaitForSeconds(1f);
        playerLocation.position = new Vector3(teleportLocation.position.x, teleportLocation.position.y, teleportLocation.position.z);
        StartCoroutine(endTeleport());
    }

    private IEnumerator endTeleport()
    {
        yield return new WaitForSeconds(1f);
        loadScreen.CrossFadeAlpha(0.01f, 1f, false);
        StartCoroutine(disableLoadScreen());
    }

    private IEnumerator disableLoadScreen()
    { 
        yield return new WaitForSeconds(1f);
        loadScreen.gameObject.SetActive(false);
    }
}
