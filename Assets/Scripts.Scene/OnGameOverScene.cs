using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameOverScene : MonoBehaviour {
	void Update ()
    {
        //バックスペースでステージセレクトへ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("OnStageSelect");
        }
    }
}
