using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class keybindControls : MonoBehaviour {

    public GameObject movementPanel;
    public GameObject actionBarPanel;
    public GameObject otherPanel;
    public GameObject tooltipPanel;

    private string[] actionBarDefaultBinds = new string[4];

    public keybind[] movementKeybinds;
    public keybind[] actionBarKeybinds;
    public keybind[] otherKeybinds;


    private string keybindSet;

    // Use this for initialization
    void Start () {
        actionBarPanel.SetActive(false);
        otherPanel.SetActive(false);
        tooltipPanel.SetActive(false);

        actionBarDefaultBinds[0] = "1";
        actionBarDefaultBinds[1] = "2";
        actionBarDefaultBinds[2] = "3";
        actionBarDefaultBinds[3] = "4";

        

        for (int i = 0; i < actionBarKeybinds.Length; i++)
        {
            actionBarKeybinds[i].setText(PlayerPrefs.GetString("keybindAction" + i, actionBarDefaultBinds[i]));
            actionBarKeybinds[i].setString(PlayerPrefs.GetString("keybindAction" + i, actionBarDefaultBinds[i]));
        }

    }

    void hidePanels()
    {
        movementPanel.SetActive(false);
        actionBarPanel.SetActive(false);
        otherPanel.SetActive(false);
        tooltipPanel.SetActive(false);
    }

    public void showMovementPanel()
    {
        hidePanels();
        movementPanel.SetActive(true);
    }

    public void showActionBarPanel()
    {
        hidePanels();
        actionBarPanel.SetActive(true);
    }

    public void showOtherPanel()
    {
        hidePanels();
        otherPanel.SetActive(true);
    }

    public void showTooltipPanel()
    {
        tooltipPanel.SetActive(true);
    }

    public void hideTooltipPanel()
    {
        tooltipPanel.SetActive(false);
    }

    public void storeKeybindSet(string set)
    {
        keybindSet = set;
    }

    public void keybindPressed(int id)
    {
       showTooltipPanel();
       StartCoroutine(WaitForKeyDown(keybindSet, id));      
    }
    
   IEnumerator WaitForKeyDown(string set, int id)
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        switch (set)
        {
            case "movement":
                break;

            case "action":                
                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        if (checkKeybinds(kcode.ToString()))
                        {
                            actionBarKeybinds[id].setString(kcode.ToString());
                            actionBarKeybinds[id].setText(kcode.ToString());
                            PlayerPrefs.SetString("keybindAction" + id, kcode.ToString());
                            if (NewHotBar.Instance != null)
                                NewHotBar.Instance.UpdateTexts();
                            /*if (actionBar)
                                actionBar.setKey(id, kcode.ToString());*/
                        }
                    }                    
                }
                break;

            case "other":
                break;
        }
        hideTooltipPanel();
    }

    private bool checkKeybinds(string keyPressed)
    {
        for (int i = 0; i < actionBarKeybinds.Length; i++)
        {
            if (keyPressed == actionBarKeybinds[i].getString().ToUpper())
            {
                ErrorScript.Instance.DisplayErrorMessage("Key already bound to Action Bar action " + (i + 1));             
                return (false);
            }
        }
        return (true);
    }
}
