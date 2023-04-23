using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTitleKeySound : MonoBehaviour {
    public bool DontDestroyEnabled = true;
	// Use this for initialization
	void Start ()
    {           
        //シーンを遷移してもオブジェクトが消えないようにする
        if (DontDestroyEnabled)
        {
        
            DontDestroyOnLoad(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown==true){
            SceneManager.LoadScene("OnStageSelect");
        }
	}
}
