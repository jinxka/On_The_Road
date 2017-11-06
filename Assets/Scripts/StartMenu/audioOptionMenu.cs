using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System;

public class audioOptionMenu : MonoBehaviour {

    public GameObject audioController;
    public Slider generalVolumeSlider;
    public Slider musicSlider;
    public Slider voiceSlider;
    public Slider ambientSoundsSlider;
    public Text generalVolumeValue;
    public Text voiceValue;
    public Text musicValue;
    public Text ambientSoundsValue;
    public AudioMixer voiceMixer;
    public AudioMixer ambientSoundsMixer;
    public AudioMixer musicMixer;

    // Use this for initialization
    void Start () {
        generalVolumeSlider.normalizedValue = PlayerPrefs.GetFloat("generalVolumeValue", 1.0f);
        voiceSlider.normalizedValue = PlayerPrefs.GetFloat("voiceValue", 1.0f);
        musicSlider.normalizedValue = PlayerPrefs.GetFloat("musicValue", 1.0f);
        ambientSoundsSlider.normalizedValue = PlayerPrefs.GetFloat("ambientSoundsValue", 1.0f);

    }
	
	// Update is called once per frame
	void Update () {
        generalVolumeValue.text = (generalVolumeSlider.normalizedValue * 100).ToString();
        voiceValue.text = ((int)(voiceSlider.normalizedValue * 100)).ToString();
        musicValue.text = ((int)(musicSlider.normalizedValue * 100)).ToString();
        ambientSoundsValue.text = ((int)(ambientSoundsSlider.normalizedValue * 100)).ToString();
    }

    public void generalVolumeChange()
    {
        AudioListener.volume = (generalVolumeSlider.normalizedValue * 10);
        PlayerPrefs.SetFloat("generalVolumeValue", generalVolumeSlider.normalizedValue);
    }

    public void musicVolumeChange()
    {
        musicMixer.SetFloat("musicVolume", (float)musicSlider.value);
        PlayerPrefs.SetFloat("musicValue", musicSlider.normalizedValue);
    }

    public void voiceVolumeChange()
    {
        voiceMixer.SetFloat("voiceVolume", (float)voiceSlider.value);
        PlayerPrefs.SetFloat("voiceValue", voiceSlider.normalizedValue);
    }

    public void ambientSoundsChange()
    {
        ambientSoundsMixer.SetFloat("ambientSoundsVolume", (float)ambientSoundsSlider.value);
        PlayerPrefs.SetFloat("ambientSoundsValue", ambientSoundsSlider.normalizedValue);
    }
}
