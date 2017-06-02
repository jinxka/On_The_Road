using UnityEngine;
using System.Collections;

public class canonSoundDelay : MonoBehaviour {

    public AudioSource source;

    // Use this for initialization
    void Start() {
        Invoke("playSound", 12.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void playSound()
    {
        float timer = Random.Range(20, 35);
        source.spatialBlend = Random.Range(0.4f, 1.0f);
        source.Play();
        Invoke("playSound", timer);
    }
}
