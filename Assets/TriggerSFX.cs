using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
    
{
    public AudioSource playSound;
    public AudioClip wind;
    void OnTriggerEnter(Collider other)
    {
        playSound.Play();
    }

    void OnTriggerExit(Collider other)
    {
        playSound.Stop();
    }
}
