using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;
    public ParticleSystem muzzle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muzzle = GetComponent<ParticleSystem>();
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(clip);
        muzzle.Play();
    }
}
