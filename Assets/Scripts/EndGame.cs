using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool quit = false;

    void Start()
    {

    }

    public void MousePush()
    {
        Application.Quit();
        quit = true;

    }

    void Update()
    {
        if(quit == true)
        {
            Debug.Log("OK");
        }
    }
}
