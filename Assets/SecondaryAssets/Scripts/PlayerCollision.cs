using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject cellLight;
    public GameObject mainCamera;
    public Transform intCameraPos;
    public GameObject interactPanel;

    public AudioSource audioSource2;
    public AudioClip cellEncounter;
    public Text interactText;
    private AudioSource audioSource;
    int visitCounter;

    private Manager manager;
    bool keyTrigger = false;
    
   
    bool healthTrigger;
    bool DoorTrigger;
    bool CellTrigger;
    public bool key;

    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        cellLight.SetActive(false);
        interactPanel.SetActive(false);
       
        key = false;
        audioSource = GetComponent<AudioSource>();
        visitCounter = 0;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void Update()
    {
        if (Input.GetButton("Interact")&& CellTrigger == true)
        {
            Debug.Log("buttonPressed");
            visitCounter++;
            mainCamera.transform.position = intCameraPos.position;
            mainCamera.transform.rotation = intCameraPos.rotation;
            interactPanel.SetActive(false);
            cellLight.SetActive(true);
            if (visitCounter == 1)
            {
               audioSource.PlayOneShot(cellEncounter);
            }
        }
        if(healthTrigger == true && Input.GetButton("Interact"))
        {
            interactPanel.SetActive(false);
            manager.PlayerCurrentHp = manager.PlayerCurrentHp + 25;
            manager.playerSlider.value = manager.PlayerCurrentHp;
            healthTrigger = false;
        }
        if(DoorTrigger == true && Input.GetButton("Interact"))
        {
            //SceneChange
            Debug.Log("Next Level");
            PlayerPrefs.SetInt("Player_Health", manager.PlayerCurrentHp);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(keyTrigger == true && Input.GetButton("Interact"))
        {
            key = true;
            audioSource2.Play();
            Debug.Log("PickedUp");
            interactPanel.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "CellBlock")
        {
            interactPanel.SetActive(true);
            interactText.text = "Press Interact Button";
            CellTrigger = true;
        }

        if (col.gameObject.tag == "Health")
        {
            if (manager.playerSlider.value == 100)
            {
                Debug.Log("HealthFull");
                interactPanel.SetActive(true);
                interactText.text = "Health Full";
            }

            if (manager.playerSlider.value < 100)
            {
                Debug.Log("Press E to Pick up Health");
                healthTrigger = true;
                interactPanel.SetActive(true);
                interactText.text = "Press Interact to pick up Health";
            }
        }

        if(col.gameObject.tag == "Door")
        {
            if(key == false)
            {
                interactPanel.SetActive(true);
                interactText.text = "You need a key to open";
            }

            if(key == true)
            {
                interactPanel.SetActive(true);
                interactText.text = "Press Interact to open the Door";
                DoorTrigger = true;
            }

        }

        if(col.gameObject.tag == "Key")
        {
            interactPanel.SetActive(true);
            interactText.text = "Press Interact to pick up the Key";
            keyTrigger = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "CellBlock")
        {
            interactPanel.SetActive(false);
            CellTrigger = false;
        }
        interactPanel.SetActive(false);
    }
}
