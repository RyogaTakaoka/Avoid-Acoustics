using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClearScene : MonoBehaviour {

	void Update ()
    {
        //バックスペースでステージセレクトへ
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("OnStageSelect");
        }
        //エンターでゲームプレイングに遷移
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("OnGamePlaying");
        }
	}
}
