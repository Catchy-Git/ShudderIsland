using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public bool IsWall;

    float horizontalMove;
     float verticalMove;
    public bool isWalking = true;
    public bool Attacked = false;
    private Manager manager;
    private Rigidbody rb;

    void Start()
    {
        IsWall = false;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Zombie")
        {
            Attacked = true;
            Debug.Log(Attacked);

            manager.ZombieAlive = true;
        }
        if(col.gameObject.tag =="Ghoul")
        {
            Attacked = true;
            Debug.Log(Attacked);

            manager.GhoulAlive = true;
        }
        if(col.gameObject.tag == "Monster")
        {
            Attacked = true;
            Debug.Log(Attacked);

            manager.MonsterAlive = true;
        }
        if(col.gameObject.tag == "Wall")
        {
            IsWall = true;
        }

    }
    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            IsWall = false;
        }
    }






        void FixedUpdate()
    {
        Debug.Log(verticalMove);
        if(IsWall == true)
        {
            player.GetComponent<Animator>().SetBool("isMoving", true);
            verticalMove = Input.GetAxis("Vertical") * 5;

            rb.MovePosition(transform.position + (transform.forward * verticalMove * Time.deltaTime));
        }
        
        if (isWalking == true)
        {
            //if Player Presses Forward to walk//
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetKey("w"))
                {
                    player.GetComponent<Animator>().SetBool("isMoving", true);
                    verticalMove = Input.GetAxis("Vertical")* 5;
                    
                    rb.MovePosition(transform.position + (transform.forward * verticalMove * Time.deltaTime));

                    if (IsWall == false)
                        
                    {
                        Debug.Log(IsWall);

                        //if player presses shift to run//
                        if (Input.GetButton("Run"))
                        {
                            player.GetComponent<Animator>().SetBool("isRunning", true);
                            Debug.Log("Running");
                            verticalMove = Input.GetAxis("Vertical") * 10;
                            rb.MovePosition(transform.position + (transform.forward * verticalMove * Time.deltaTime));

                        }
                        //if player releases shift to walk//
                        if (!Input.GetButton("Run"))
                        {
                            player.GetComponent<Animator>().SetBool("isRunning", false);
                        }
                    }
                    //else { Debug.Log(IsWall); }
                        
                }
                if (Input.GetKey("s"))
                {
                    player.GetComponent<Animator>().SetBool("isMovingBack", true);
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 5;
                    player.transform.Translate(0, 0, verticalMove);
                }

            }
            //if player presses a or d to rotate//
            if (Input.GetButton("Horizontal"))
            {
                //if player presses a to rotate left//
                if (Input.GetKey("a"))
                {
                    player.GetComponent<Animator>().SetBool("LeftTurn", true);
                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 300;
                    player.transform.Rotate(0, horizontalMove, 0);

                }
                //if player presses d to rotate//
                if (Input.GetKey("d"))
                {
                    player.GetComponent<Animator>().SetBool("RightTurn", true);
                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 300;
                    player.transform.Rotate(0, horizontalMove, 0);

                }
            }
            //if player is not pressing to rotate or move   
            if (!Input.GetButton("Horizontal"))
            {
                player.GetComponent<Animator>().SetBool("RightTurn", false);
                player.GetComponent<Animator>().SetBool("LeftTurn", false);

            }

            if (!Input.GetButton("Vertical"))
            {
                player.GetComponent<Animator>().SetBool("isMoving", false);
                player.GetComponent<Animator>().SetBool("isMovingBack", false);
                player.GetComponent<Animator>().SetBool("isRunning", false);
            }
        }
    }
}
