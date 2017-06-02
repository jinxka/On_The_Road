using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterDetails : MonoBehaviour {

    public GameObject menuPanel;
    //public GameObject inventoryPanel;
    public GameObject skillsPanel;
    public GameObject questPanel;
    public GameObject AchiPanel;
    public GameObject characterPanel;

    public Button invButton;
    public Button skillsButton;
    public Button questButton;
    public Button achiButton;

    void Start () {
        closePanels();
        //inventoryPanel.SetActive(true);
        characterPanel.SetActive(true);
    }

    private void closePanels()
    {
        skillsPanel.SetActive(false);
        //inventoryPanel.SetActive(false);
        characterPanel.SetActive(false);
        questPanel.SetActive(false);
        AchiPanel.SetActive(false);
    }
    public void invOpen()
    {
        closePanels();
        //inventoryPanel.SetActive(true);
        characterPanel.SetActive(true);
    }
    
    public void skillsOpen()
    {
        closePanels();
        skillsPanel.SetActive(true);
        characterPanel.SetActive(true);
    }

    public void questOpen()
    {
        closePanels();
        questPanel.SetActive(true);
    }

    public void achiOpen()
    {
        closePanels();
        AchiPanel.SetActive(true);
    }
}
