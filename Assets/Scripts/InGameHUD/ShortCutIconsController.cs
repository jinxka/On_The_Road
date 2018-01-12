using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutIconsController : MonoBehaviour {

    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    Text tooltipText;

    public void TogglePanel(CanvasGroup panel)
    {
        GUIManager.Instance.TogglePanel(panel);
    }

    public void showTooltip(string iconName)
    {
        tooltipText.text = iconName;
        tooltip.SetActive(true);
    }

    public void hideTooltip()
    {
        tooltip.SetActive(false);
    }
}
