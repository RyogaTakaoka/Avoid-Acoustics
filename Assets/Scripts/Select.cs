using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {

    public AudioClip audioClip3;
    private AudioSource audioSource;
    bool stop = false;

    // Update is called once per frame
    void Update()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip3;

        if (stop==false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.Play();
                transform.Rotate(new Vector3(0, -90, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.Play();
                transform.Rotate(new Vector3(0, 90, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                audioSource.Play();
                transform.Rotate(new Vector3(0, 90, 0));
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine("Stop");
            }
        }
    }
    IEnumerator Stop()
    {
        stop = true;
        yield return new WaitForSeconds(1);
        stop = false;
    }
}
