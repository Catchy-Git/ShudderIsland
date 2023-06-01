using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip Deathclip;
    public AudioClip Attackclip;
    public AudioClip Abilityclip;
    private AudioSource audioSource;
    private Manager manager;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private void DeathSound()
    {
        audioSource.PlayOneShot(Deathclip);
    }
    private void AttackSound()
    {
        audioSource.PlayOneShot(Attackclip);
    }

    private void AbilitySound()
    {
        audioSource.PlayOneShot(Abilityclip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    private void EnemyHit()
    {
        manager.newEnemy.GetComponent<Animator>().SetBool("isHit", true);
    }

    private void PlayerHit()
    {
       manager.player.GetComponent<Animator>().SetBool("isHit", true);
    }

    private void EnemyNotHit()
    {
        manager.newEnemy.GetComponent<Animator>().SetBool("isHit", false);
    }

    private void PlayerNotHit()
    {
        manager.player.GetComponent<Animator>().SetBool("isHit", false);
    }

    private void PlayerNotAttacking()
    {
        manager.player.GetComponent<Animator>().SetBool("isAttacking", false);
    }

    private void EnemyNotAttacking()
    {
        manager.newEnemy.GetComponent<Animator>().SetBool("isAttacking", false);
    }

    private void PlayerNotAbility()
    {
        manager.player.GetComponent<Animator>().SetBool("isAbility", false);
    }
}
