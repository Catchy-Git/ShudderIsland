using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject mainCamera;
    public Transform camera1Pos;
    public Transform camera2Pos;
    public Transform camera3Pos;
    public Transform camera4Pos;
    public Transform camera5Pos;
    public Transform camera6Pos;
    public Transform camera7Pos;
    public Transform camera8Pos;
    public Transform camera9Pos;
    public Transform camera10Pos;
    public Transform camera11Pos;
    public Transform camera12Pos;
    public Transform camera13Pos;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Camera1")
        {
            mainCamera.transform.position = camera1Pos.position;
            mainCamera.transform.rotation = camera1Pos.rotation;
        }
        if (other.tag == "Camera2")
        {
            mainCamera.transform.position = camera2Pos.position;
            mainCamera.transform.rotation = camera2Pos.rotation;
        }
        if (other.tag == "Camera3")
        {
            mainCamera.transform.position = camera3Pos.position;
            mainCamera.transform.rotation = camera3Pos.rotation;
        }
        if (other.tag == "Camera4")
        {
            mainCamera.transform.position = camera4Pos.position;
            mainCamera.transform.rotation = camera4Pos.rotation;
        }
        if (other.tag == "Camera5")
        {
            mainCamera.transform.position = camera5Pos.position;
            mainCamera.transform.rotation = camera5Pos.rotation;
        }
        if (other.tag == "Camera6")
        {
            mainCamera.transform.position = camera6Pos.position;
            mainCamera.transform.rotation = camera6Pos.rotation;
        }
        if (other.tag == "Camera7")
        {
            mainCamera.transform.position = camera7Pos.position;
            mainCamera.transform.rotation = camera7Pos.rotation;
        }
        if (other.tag == "Camera8")
        {
            mainCamera.transform.position = camera8Pos.position;
            mainCamera.transform.rotation = camera8Pos.rotation;
        }
        if (other.tag == "Camera9")
        {
            mainCamera.transform.position = camera9Pos.position;
            mainCamera.transform.rotation = camera9Pos.rotation;
        }
        if (other.tag == "Camera10")
        {
            mainCamera.transform.position = camera10Pos.position;
            mainCamera.transform.rotation = camera10Pos.rotation;
        }
        if (other.tag == "Camera11")
        {
            mainCamera.transform.position = camera11Pos.position;
            mainCamera.transform.rotation = camera11Pos.rotation;
        }
        if (other.tag == "Camera12")
        {
            mainCamera.transform.position = camera12Pos.position;
            mainCamera.transform.rotation = camera12Pos.rotation;
        }
        if (other.tag == "Camera13")
        {
            mainCamera.transform.position = camera13Pos.position;
            mainCamera.transform.rotation = camera13Pos.rotation;
        }
    }

   
}
