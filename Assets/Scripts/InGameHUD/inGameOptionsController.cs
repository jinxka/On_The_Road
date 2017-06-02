using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class inGameOptionsController : MonoBehaviour
{

    public Button[] panel = new Button[3];
    public GameObject audioButtons;
    public GameObject videoButtons;
    public GameObject controlsButtons;
    
    // Use this for initialization
    void Start()
    {
        audioButtons.SetActive(true);
        videoButtons.SetActive(false);
        controlsButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideOptions()
    {
        audioButtons.SetActive(false);
        videoButtons.SetActive(false);
        controlsButtons.SetActive(false);
    }

    public void AudioPress()
    {
        HideOptions();
        audioButtons.SetActive(true);
    }

    public void VideoPress()
    {
        HideOptions();
        videoButtons.SetActive(true);
    }

    public void ControlsPress()
    {
        HideOptions();
        controlsButtons.SetActive(true);
    }

}
