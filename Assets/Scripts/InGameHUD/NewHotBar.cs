using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHotBar : MonoBehaviour {

    [SerializeField]
    Text[] actions;

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
}
