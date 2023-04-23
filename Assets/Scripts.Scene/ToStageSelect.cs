using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStageSelect : MonoBehaviour
{


    //70秒たったらクリア
    void ChangeNext()
    {
        if (Time.timeSinceLevelLoad > 5.0f)
        {
            SceneManager.LoadScene("OnStageSelect");
        }
    }
    void Update()
    {
        ChangeNext();
    }
}