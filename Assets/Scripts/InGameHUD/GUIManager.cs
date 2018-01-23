using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class GUIManager : MonoBehaviour {

    #region UnityCompliant Singleton
    public static GUIManager Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            return;
        }
        Destroy(gameObject);
    }

    #endregion

    [Header ("GUI Panels")]
    [SerializeField]
    CanvasGroup[] GUIPanels;

    //[HideInInspector]
    public bool allPanelsAreClosed = true;

    Camera mainCamera;
    BlurOptimized cameraBlur;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera.GetComponent<BlurOptimized>())
            cameraBlur = mainCamera.GetComponent<BlurOptimized>();
    }

    private void CheckIfPanelsAreClosed()
    {
        foreach (CanvasGroup panel in GUIPanels)
        {
            if (panel.alpha == 1)
            {
                allPanelsAreClosed = false;
                return;
            }
        }
        allPanelsAreClosed = true;
    }

    public void TogglePanel(CanvasGroup panel)
    {
        if (panel.alpha == 1)
            ClosePanel(panel);
        else
            OpenPanel(panel);
    }

    public void ClosePanel(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;
        CheckIfPanelsAreClosed();
    }

    public void OpenPanel(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.blocksRaycasts = true;
        panel.interactable = true;
        CheckIfPanelsAreClosed();
    }

    public void CloseAllPanels()
    {
        foreach (CanvasGroup panel in GUIPanels)
            ClosePanel(panel);
        CameraCheck();
    }

    public void CameraCheck()
    {
        if (cameraBlur)
           cameraBlur.enabled = false;
    }
}
