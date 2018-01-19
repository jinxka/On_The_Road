using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMessage : MonoBehaviour {

    [SerializeField]
    CanvasGroup progressGroup;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
    public void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            progressGroup.alpha = 1;
            if (Input.anyKey)
            {
                SceneLoading.Instance.loadScene(SceneManager.GetActiveScene().name);
                Destroy(this);
            }
        }
    }
}
