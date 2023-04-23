using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClearScene : MonoBehaviour
{
    public string OnClear;
    NoteManager noteScript;
    SpaceNoteManager spaceScript;

    bool loadFlag = false;

    void ChangeNext()
    {
        noteScript = GameObject.Find("NoteManager").GetComponent<NoteManager>();
        spaceScript = GameObject.Find("NoteManager").GetComponent<SpaceNoteManager>();

        if (SceneManager.GetSceneByName("OnSpace").isLoaded == false)
        {
            for (int i = 0; i < noteScript.notes.Length; i++)
                if (noteScript.notes[i].Count <= 0 && SceneManager.GetSceneByName("OnGameClear").isLoaded == false && !loadFlag)
                {
                    Invoke("ChangeClear", 5f);
                    loadFlag = true;
                }
        }

        if (SceneManager.GetSceneByName("OnSpace").isLoaded == true)
        {
            if (spaceScript.notes[0].Count <= 0 && spaceScript.notes[1].Count <= 1 && spaceScript.orderScore > 11 && SceneManager.GetSceneByName("OnGameClear").isLoaded == false && !loadFlag)
            {
                Invoke("ChangeClear", 5f);
                loadFlag = true;
            }
        }

    }
    void Update()
    {
        ChangeNext();
        //if (Input.GetKey(KeyCode.Return))
        //{
        //    SceneManager.LoadScene("OnResult");
        //}
    }

    void ChangeClear()
    {
        SceneManager.LoadScene("OnGameClear", LoadSceneMode.Additive);
    }
}