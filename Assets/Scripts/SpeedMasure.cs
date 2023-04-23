using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMasure : MonoBehaviour {

    Vector3 latestPos;
    Vector3 speed;
    GameObject speedMasurE;

    // Use this for initialization
    void Start () {

        speedMasurE = GameObject.Find("SpeedMasurE");

    }
	
	// Update is called once per frame
	void Update () {

       float speed
    = ((speedMasurE.transform.position - latestPos) / Time.deltaTime).magnitude;
        latestPos = speedMasurE.transform.position;
        Debug.Log(speed);
    }
}
