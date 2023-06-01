using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveUI : MonoBehaviour
{
    public GameObject switchButton;
    public GameObject player1;
    public GameObject player2;
    bool Player1;
    bool Player2;
   
    void Start()
    {
        switchButton.SetActive(false);
        Player1 = true;
        Player2 = false;
    }

   
 
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            switchButton.SetActive(true);
        }
    }

    public void SwitchButton()
    {
        if(player1 == true)
        {
            player1.SetActive(false);
            player2.SetActive(true);
            Player1 = false;
            Player2 = true;
            switchButton.SetActive(false);
        }
    }
}
