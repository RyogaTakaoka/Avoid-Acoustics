using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreresult : MonoBehaviour {

    public GameObject[] ResultImage;

	// Use this for initialization
	void Start () {
        int countr = GameResult.ResultCount;

        switch (countr)
        {
            case 0:
                ResultImage[0].SetActive(true);
                break;
            case 1:
                ResultImage[1].SetActive(true);
                break;
            case 2:
                ResultImage[2].SetActive(true);
                break;
            case 3:
                ResultImage[3].SetActive(true);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
