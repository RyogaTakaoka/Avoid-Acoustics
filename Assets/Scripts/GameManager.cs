using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    NoteManager noteScript;
    EffectManager effectScript;
    BgmManager bgmScript;
    SpaceNoteManager spaceScript;

    public int stageNum;
    public float time;

    void Start()
    {
        noteScript = GameObject.Find("NoteManager").GetComponent<NoteManager>();
        //effectScript = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        bgmScript = GameObject.Find("AudioSource").GetComponent<BgmManager>();

        noteScript.NoteStart(stageNum);
        bgmScript.BgmStart(time, stageNum);
        //Invoke("InvokeEffect", time);

    }

    void InvokeEffect()
    {
        effectScript.EffectStart(stageNum);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetSceneByName("OnPause").isLoaded == false)
        {
            SceneManager.LoadScene("OnPause", LoadSceneMode.Additive);
            Time.timeScale = 0;
            bgmScript.audioSources[stageNum].Pause();
        }

        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetSceneByName("OnPause").isLoaded == true)
        {
            SceneManager.UnloadSceneAsync("OnPause");
            Time.timeScale = 1;
            bgmScript.audioSources[stageNum].UnPause();
        }

    }
}

