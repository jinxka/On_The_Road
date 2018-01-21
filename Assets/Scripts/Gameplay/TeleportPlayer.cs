using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour {
    public float delay = 0;
    [SerializeField]
    Transform teleportLocation;
    

    private Transform playerLocation;
    private Image blackScreen;

    void Start()
    {
        blackScreen = SceneLoading.Instance.getBlackScreen();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        playerLocation = other.transform;
        StartCoroutine(startTeleport());
    }

    private IEnumerator startTeleport()
    {
        SceneLoading.Instance.loadingScreenGroup(true);
        blackScreen.gameObject.SetActive(true);
        blackScreen.canvasRenderer.SetAlpha(0f);
        blackScreen.CrossFadeAlpha(0.99f, 1f, false);
        yield return new WaitForSeconds(delay);
        playerLocation.position = new Vector3(teleportLocation.position.x, teleportLocation.position.y, teleportLocation.position.z);
        StartCoroutine(endTeleport());
    }

    private IEnumerator endTeleport()
    {
        yield return new WaitForSeconds(1f);
        blackScreen.CrossFadeAlpha(0.01f, 1f, false);
        StartCoroutine(disableLoadScreen());
    }

    private IEnumerator disableLoadScreen()
    { 
        yield return new WaitForSeconds(1f);
        blackScreen.gameObject.SetActive(false);
        SceneLoading.Instance.loadingScreenGroup(false);
    }
}
