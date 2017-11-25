using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public CanvasGroup menuCanvas;
    public Button menuButton;
    public Camera cam;
    public Canvas UiCanvas;
    [SerializeField]
    Slider ammoSlider;
    [SerializeField]
    Text ammoIndicator;
    [SerializeField]
    Tir_normal playerShooting;

	// Use this for initialization
	void Start () {
        playerShooting = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Tir_normal>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
            if (menuCanvas.alpha == 0)
                openMenu();
            else
                closeMenu();
		}
        ammoSlider.value = playerShooting.clip;
        ammoIndicator.text = playerShooting.clip.ToString();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    public void openMenu()
    {
        menuCanvas.alpha = 1;
        menuCanvas.interactable = true;
        menuCanvas.blocksRaycasts = true;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = true;
    }

    public void closeMenu()
    {
        menuCanvas.alpha = 0;
        menuCanvas.interactable = false;
        menuCanvas.blocksRaycasts = false;
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = false;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        InventoryPersistence.Instance.showInventory();
    }
}

