using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour {

    public GameObject[] OpenNewScene;
    public GameObject[] Spanish;

    // Use this for initialization
    void Start ()
    {
        int countr = GameResult.ResultCount;
        int count = GameResult.Count;

        countr = 0;

        for(int loop = 0; loop < OpenNewScene.Length; loop++)
        {
            if (count<= loop)
                OpenNewScene[loop].SetActive(false);
            else
                OpenNewScene[loop].SetActive(true);

            if (count <= loop)
                Spanish[loop].SetActive(true);
            else
                Spanish[loop].SetActive(false);
        }
    }

}
