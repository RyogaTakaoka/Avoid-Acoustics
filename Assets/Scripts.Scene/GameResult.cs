using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour {

    public static int Count=0;

    public static int ResultCount=0;

    void Awake()
    {
        ResultCount = 0;
    }
	
	void Start () {
		if(SceneManager.GetSceneByName("OnGrassland").isLoaded == true&&Count<2)
        {
            Count++;
            Count++;
        }
        if (SceneManager.GetSceneByName("OnSea").isLoaded == true && Count < 4)
        {
            Count++;
            Count++;
        }
        if (SceneManager.GetSceneByName("OnSky").isLoaded == true && Count < 6)
        {
            Count++;
            Count++;
        }
        if (SceneManager.GetSceneByName("OnSea").isLoaded == true)
        {
            ResultCount++;
        }
        if (SceneManager.GetSceneByName("OnSky").isLoaded == true)
        {
            ResultCount++;
            ResultCount++;
        }
        if (SceneManager.GetSceneByName("OnSpace").isLoaded == true)
        {
            ResultCount++;
            ResultCount++;
            ResultCount++;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResultCount = 0;
            SceneManager.LoadScene("OnStageSelect");
        }

    }
}
