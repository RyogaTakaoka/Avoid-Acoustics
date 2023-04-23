
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlay : MonoBehaviour
{

    public int upCount = 2;
    public int downCount = 0;

    public AudioClip audioClip1;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (Input.GetKeyDown("up") && 0 <= upCount&&upCount <2)
        {
            audioSource.PlayOneShot(audioClip1);
            downCount--;
            upCount++;
            transform.position += new Vector3(-0.2f, 0.4f, 0);
        }

        if (Input.GetKeyDown("down") && 0 <= downCount&& downCount< 2)
        {
            audioSource.PlayOneShot(audioClip1);
            downCount++;
            upCount--;
            transform.position += new Vector3(0.2f, -0.4f, 0);
        }
    }
}
