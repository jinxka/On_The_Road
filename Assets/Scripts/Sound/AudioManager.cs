﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public Sound[] sounds;

	public static AudioManager instance;

	// Use this for initialization
	void Awake() {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}
			
		//DontDestroyOnLoad (gameObject);
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

            AudioMixer mixer;

            if (s.name == "Theme")
                mixer = Resources.Load("Music") as AudioMixer;
            else
                mixer = Resources.Load("Ambient") as AudioMixer;
            s.source.outputAudioMixerGroup = mixer.FindMatchingGroups("Master")[0];
    }

}

	void Start()
	{
		Play ("Theme");
	}

	public void Play(string name){
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + " not found");
			return;
		}
		s.source.Play ();
	}
}
