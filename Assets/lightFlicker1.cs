using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker1 : MonoBehaviour
{
    public Light _Light;
    public float minTime;
    public float MaxTime;
    public float Timer;
  //  public GameObject box;

  //  public AudioSource AS;
   // public AudioClip LightAudio;

    void Start()
    {
        Timer = Random.Range(minTime, MaxTime);
      //  box.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }
    void FlickerLight()
    {
        if (Timer > 0)
            Timer -=Time.deltaTime;
       
        if (Timer< 0)
        {
            _Light.enabled = !_Light.enabled;
            Timer = Random.Range(minTime, MaxTime);
          // box.GetComponent<Renderer>().material.color = Color.black;
            //  AS.PlayOneShot(LightAudio);
        }
    }
}
