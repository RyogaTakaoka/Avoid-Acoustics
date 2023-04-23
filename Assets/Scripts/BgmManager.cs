using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{

    public AudioSource[] audioSources;
    private int bgmNum;

    public void BgmStart(float waitTime, int stageNum)
    {
        bgmNum = stageNum;
        Invoke("Play", waitTime);
    }

    public void Play()
    {
        audioSources[bgmNum].Play();
    }
}
