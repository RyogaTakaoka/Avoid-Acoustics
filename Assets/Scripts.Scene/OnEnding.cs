using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnding : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        ToTitle();
    }

    void ToTitle()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TITLE");
        }
    }
}
