using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioSource sound01;


	// Use this for initialization
	void Start () {
        sound01 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return))
        {
            sound01.PlayOneShot(sound01.clip);
        }
	}
}
