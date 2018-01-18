using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public CanvasGroup menuPanel;
    Camera cam;
	public CanvasGroup worldMapPanel;
    [SerializeField]
    Slider ammoSlider;
    [SerializeField]
    Text ammoIndicator;
    Tir_normal playerShooting;

	// Use this for initialization
	void Start () {
        playerShooting = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Tir_normal>();
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(NewInputManager.Instance.Menu)) {
            ToggleMenu();
		}
		else if (Input.GetKeyDown(NewInputManager.Instance.GlobalMap)) {
            GUIManager.Instance.TogglePanel(worldMapPanel);
		}
        ammoSlider.value = playerShooting.clip;
        ammoIndicator.text = playerShooting.clip.ToString();
    }

    void ToggleMenu()
    {
        GUIManager.Instance.TogglePanel(menuPanel);
        (cam.GetComponent("BlurOptimized") as MonoBehaviour).enabled = menuPanel.interactable;
    }
}

