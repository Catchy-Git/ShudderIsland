using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public void Hunter()
    {
        PlayerPrefs.SetInt("Player", 1);
        PlayerPrefs.SetInt("Player_Health", 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hooded()
    {
        PlayerPrefs.SetInt("Player", 2);
        PlayerPrefs.SetInt("Player_Health", 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hammer()
    {
        PlayerPrefs.SetInt("Player", 3);
        PlayerPrefs.SetInt("Player_Health", 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SharpShooter()
    {
        PlayerPrefs.SetInt("Player", 4);
        PlayerPrefs.SetInt("Player_Health", 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartDemo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
