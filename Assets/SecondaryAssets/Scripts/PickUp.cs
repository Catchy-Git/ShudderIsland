using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerCollision playerCollision;
    public Manager manager;

    void Start()
    {
        
    }

    void OnTriggerStay(Collider col)
   {
        if((col.gameObject.tag == "Player") && (Input.GetButton("Interact")))
        {
            manager.PlayupSound();
            Destroy(gameObject);
        }
   }

  

}
