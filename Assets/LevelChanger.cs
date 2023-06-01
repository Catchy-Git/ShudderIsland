using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
   

    
    void Update()
    {
       if(Input.GetMouseButtonDown(0)) /// replace this to on collision or trigger
        {
            FadeToNextLevel();
        }       
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout");
    }
    public void ONFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
