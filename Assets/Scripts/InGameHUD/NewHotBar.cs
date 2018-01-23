using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHotBar : MonoBehaviour {

    [SerializeField]
    Text[] actions;
    [SerializeField]
    NewInventorySlot artifactSlot;
    [SerializeField]
    CanvasGroup artifactCanvas;
    [SerializeField]
    NewInventorySlot[] actionBarSlots;

    [SerializeField]
    Slider progressBar;
    [SerializeField]
    CanvasGroup barCanvas;

    bool isTeleporting = false;

    #region UnityCompliant Singleton
    public static NewHotBar Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    #endregion

    private void Start()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        foreach (Text keybind in actions)
        {
            keybind.text = PlayerPrefs.GetString(keybind.name, keybind.text);
        }
    }

    public void AddArtifact()
    {
        artifactCanvas.alpha = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(NewInputManager.Instance.ActionBar1))
            if (actionBarSlots[0].transform.childCount > 1)
                actionBarSlots[0].transform.GetChild(0).gameObject.GetComponent<NewItem>().TriggerItem();
        if (Input.GetKeyDown(NewInputManager.Instance.ActionBar2))
            if (actionBarSlots[1].transform.childCount > 1)
                actionBarSlots[1].transform.GetChild(0).gameObject.GetComponent<NewItem>().TriggerItem();
        if (Input.GetKeyDown(NewInputManager.Instance.ActionBar3))
            if (actionBarSlots[2].transform.childCount > 1)
                actionBarSlots[2].transform.GetChild(0).gameObject.GetComponent<NewItem>().TriggerItem();
        if (Input.GetKeyDown(NewInputManager.Instance.ActionBar4))
            if (actionBarSlots[3].transform.childCount > 1)
                actionBarSlots[3].transform.GetChild(0).gameObject.GetComponent<NewItem>().TriggerItem();
        if (Input.GetKeyDown(NewInputManager.Instance.ActionBar5) && (artifactCanvas.alpha == 1) && (isTeleporting == false))
        { }// StartCoroutine(StartTeleporting());
        if (Input.anyKeyDown && isTeleporting)
        {
            StopCoroutine(StartTeleporting());
            isTeleporting = false;
            progressBar.value = 0;
            barCanvas.alpha = 0;
        }
    }

    private IEnumerator StartTeleporting()
    {
        isTeleporting = true;
        barCanvas.alpha = 1;
        float timeLeft = Time.deltaTime;
        WaitForSeconds delay = new WaitForSeconds(3f);
        while (timeLeft > 0)
        {
            timeLeft += Time.deltaTime;
            progressBar.value = timeLeft;
        }
        yield return delay;
        isTeleporting = false;
        barCanvas.alpha = 0;
        SceneLoading.Instance.loadScene("Zone_Colonie_Safe");
    }
}
