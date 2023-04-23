using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    public float waitetime = 1.0f;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Player");
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Player");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            //switch (nearObj.gameObject.name)
            //{
            //    case "A":
            //        GameManager.stageNum = 0;
            //        break;
            //    case "B":
            //        GameManager.stageNum = 1;
            //        break;
            //    case "C":
            //        GameManager.stageNum = 2;
            //        break;
            //    case "D":
            //        GameManager.stageNum = 3;
            //        break;
            //    case "No":
            //        audioSource.Play();
            //        break;

            //}
            //SceneManager.LoadScene("OnGrassland");

            if (nearObj.gameObject.name == "No")
            {
                audioSource.PlayOneShot(audioClip1);
            }
            else
            {
                StartCoroutine("Select");
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("escape");
        }
    }

    IEnumerator Select()
    {
        string sign = nearObj.gameObject.name;
        audioSource.PlayOneShot(audioClip2);
        yield return new WaitForSeconds(waitetime);
        if (sign == "A")
        {
            SceneManager.LoadScene("OnGrassland");
        }
        if (sign == "B")
        {
            SceneManager.LoadScene("OnSea");
        }
        if (sign == "C")
        {
            SceneManager.LoadScene("OnSky");
        }
        if (sign == "D")
        {
            SceneManager.LoadScene("OnSpace");
        }
    }


    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;

    }

}