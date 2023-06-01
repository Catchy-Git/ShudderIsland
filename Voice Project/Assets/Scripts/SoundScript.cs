using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class SoundScript : MonoBehaviour
{
    public GameObject Cube;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 40f;

    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    private MeshRenderer cubeRend;

    private bool spinningRight;
    private bool spinningUp;

    private AudioSource soundSource;
    public AudioClip[] sounds;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        cubeRend = GetComponent<MeshRenderer>();
        soundSource = GetComponent<AudioSource>();

        keyActs.Add("red", Red);
        keyActs.Add("green", Green);
        keyActs.Add("blue", Blue);
        keyActs.Add("white", White);

        keyActs.Add("spin right", SpinRight);
        keyActs.Add("spin left", SpinLeft);
        keyActs.Add("spin up", SpinUp);

        keyActs.Add("double", Duplicate);

        keyActs.Add("self destruct", SelfDestruct);

        keyActs.Add("youtube please", YouTube);

        keyActs.Add("hey im walking here", Move);

        keyActs.Add("please say something", Talk);

        keyActs.Add("pizza is a wonderful food that makes me very happy", FactAcknowledgement);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }

    void Red()
    {
        cubeRend.material.SetColor("_Color", Color.red);
    }

    void Green()
    {
        cubeRend.material.SetColor("_Color", Color.green);
    }
    void Blue()
    {
        cubeRend.material.SetColor("_Color", Color.blue);
    }
    void White()
    {
        cubeRend.material.SetColor("_Color", Color.white);
    }

    void Move()
    {
        m_Rigidbody.AddForce(transform.up * m_Thrust);
    }

    void Duplicate()
    {
        GameObject go = GameObject.Instantiate(Cube);
        go.transform.position = transform.position;
    }
    void SpinRight()
    {
        spinningRight = true;
        StartCoroutine(RotateObject(1f));
    }

    void SpinLeft()
    {
        spinningRight = false;
        StartCoroutine(RotateObject(1f));
    }

    void SpinUp()
    {
        spinningUp = true;
        StartCoroutine(RotateObject(1f));
    }

    void YouTube()
    {
        Application.OpenURL("www.youtube.com");
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
    private IEnumerator RotateObject(float duration)
    {
        float startRot = transform.eulerAngles.x;
        float endRot;

        if (spinningRight)
            endRot = startRot - 360f;
        else
            endRot = startRot + 360f;

        float t = 0f;
        float yRot;

        while(t < duration)
        {
            t += Time.deltaTime;
            yRot = Mathf.Lerp(startRot, endRot, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot, transform.eulerAngles.z);
            yield return null;
        }


    }

    void Talk()
    {
        soundSource.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        soundSource.Play();
    }

    void FactAcknowledgement()
    {
        Debug.Log("How right you are.");
    }
}
