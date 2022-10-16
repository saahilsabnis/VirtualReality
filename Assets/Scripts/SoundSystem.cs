using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundSystem : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource[] sounds;
    bool isPressed;
    bool isFirstSoundPlaying;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        isPressed = false;
        isFirstSoundPlaying = true;
        sounds[1].loop = true;
        sounds[2].loop = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(!isPressed){
            button.transform.localPosition = new Vector3(0, 0, -0.001f);
            presser = other.gameObject;
            onPress.Invoke();
            sounds[0].Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == presser){
            button.transform.localPosition = new Vector3(0, 0, -0.0038f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SwitchSound() {
        if(isFirstSoundPlaying){
            sounds[1].Stop();
            sounds[2].Play();
        }else {
            sounds[1].Play();
            sounds[2].Stop();
        }
        isFirstSoundPlaying = !isFirstSoundPlaying;
    }
}
