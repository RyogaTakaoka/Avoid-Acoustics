using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToResult : MonoBehaviour {


	void Start ()
    {
        StartCoroutine("Wai");
	}

    IEnumerator Wai()
    {
        yield return new WaitForSeconds(3);
       SceneManager.LoadScene("OnResult");
    }
}