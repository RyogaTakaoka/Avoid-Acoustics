using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTitle : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;

    IEnumerator Title()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("OnStageSelect");
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Title());
        }
	}

}
