using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent nav;
    public AudioSource wallBreak;
    private float timer;
   

    bool detectPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        wallBreak = GetComponent<AudioSource>();
        detectPlayer = false;
    }

    void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player")
       {
            detectPlayer = true;
       }
    }

    void Update()
    {
        if (detectPlayer == true)
        {
            nav.destination = player.transform.position;
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
        }
    }
    
}
