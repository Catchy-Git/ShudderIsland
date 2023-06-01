using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject mainCamera;
    public Transform battleCameraPos;
    public Transform LastCameraPosition;
    private NavMeshAgent nav;
    
    public AudioClip Encounter;
    private AudioSource audioSource;
    private Manager manager;
    public bool chase;
    public float speed;
    private Rigidbody rb;
    public Transform teleportTargetPlayer;
    
    
    void Start()
    {
     
        nav = GetComponent<NavMeshAgent>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        chase = false;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
        if (chase == true)
        {
            nav.destination = player.transform.position;
            
            enemy.GetComponent<Animator>().SetBool("isMoving", true);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chase = true;
            nav.destination = player.transform.position;
            enemy.GetComponent<Animator>().SetBool("isMoving", true);
            audioSource.PlayOneShot(Encounter);
            
        }
    }

    

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {

            //deathPanel.SetActive(true);
            manager.LastHeroPosition = player.transform.position;

                chase = false;
                player.transform.position = teleportTargetPlayer.transform.position;
            player.transform.rotation = teleportTargetPlayer.transform.rotation;

            LastCameraPosition.transform.position = mainCamera.transform.position;
            LastCameraPosition.transform.rotation = mainCamera.transform.rotation;

            player.GetComponent<Animator>().SetBool("isMoving", false);
            player.GetComponent<Animator>().SetBool("isRunning", false);

            mainCamera.transform.position = battleCameraPos.position;
            mainCamera.transform.rotation = battleCameraPos.rotation;

            //Dont turn back on yet
            Destroy(gameObject);
        }
    }

    
}
