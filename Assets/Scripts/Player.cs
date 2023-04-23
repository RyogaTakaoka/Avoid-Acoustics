using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject[] playerIcons;
    public int destroyCount=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            destroyCount += 1;
            UpdatePlayerIcons();
            
            if(destroyCount==3)
            {
                SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
            }
        }
	}

    void UpdatePlayerIcons()
    {
        for(int i=0;i<playerIcons.Length;i++)
        {
            if (destroyCount <= i)
                playerIcons[i].SetActive(true);
            else
                playerIcons[i].SetActive(false);
        }
    }
}
