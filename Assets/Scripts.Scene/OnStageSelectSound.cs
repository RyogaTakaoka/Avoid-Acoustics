using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStageSelectSound : MonoBehaviour
{
    public AudioSource sound01;

    private void Start()
    {
        sound01 = GetComponent<AudioSource>();
    }
    //左右の矢印キーを押したら音が鳴る
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            sound01.PlayOneShot(sound01.clip);
        }
    }
}
