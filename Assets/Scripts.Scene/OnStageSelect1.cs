using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStageSelect1 : MonoBehaviour {
    


	void Update ()
    {
        if(SceneData.Instance.referer == string.Empty && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("OnStageSelect");
        }

        if(SceneData.Instance.referer == "OnSpace" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("OnEnding");
        }
	}
}
