using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FourLightSystem : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public Light primarylight;
    public Light secondlight;
    public Light thirdlight;
    public Light fourthlight;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    bool isPrimarylightEnabled; 

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        primarylight.enabled = false;
        secondlight.enabled = false;
        thirdlight.enabled = false;
        fourthlight.enabled = false;
        isPressed = false;
        isPrimarylightEnabled = false;
 
    }

    private void OnTriggerEnter(Collider other) {
        if(!isPressed){
            button.transform.localPosition = new Vector3(0, 0, -0.001f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            primarylight.enabled = !isPrimarylightEnabled;
            isPrimarylightEnabled = !isPrimarylightEnabled;
            secondlight.enabled = false;
            thirdlight.enabled = false;
            fourthlight.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == presser){
            button.transform.localPosition = new Vector3(0, 0, -0.0038f);
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
