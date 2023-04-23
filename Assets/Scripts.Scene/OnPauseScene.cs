using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPauseScene : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    private int stageNum;

    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Player");
            if (nearObj.gameObject.name == "continue")
            {
                SceneManager.UnloadSceneAsync("OnPause");
                Time.timeScale = 1;
                GameObject.Find("AudioSource").GetComponent<BgmManager>().audioSources[gameManager.stageNum].UnPause();

            }
            if (nearObj.gameObject.name == "restart")
            {
                if (SceneManager.GetSceneByName("OnSea").isLoaded == true)
                {
                    SceneManager.LoadScene("OnSea");
                }
                else if (SceneManager.GetSceneByName("OnGrassland").isLoaded == true)
                {
                    SceneManager.LoadScene("OnGrassland");
                }
                else if (SceneManager.GetSceneByName("OnSky").isLoaded == true)
                {
                    SceneManager.LoadScene("OnSky");
                }
                else if (SceneManager.GetSceneByName("OnSpace").isLoaded == true)
                {
                    SceneManager.LoadScene("OnSpace");
                }
                Time.timeScale = 1;
                GameObject.Find("AudioSource").GetComponent<BgmManager>().audioSources[gameManager.stageNum].UnPause();
            }
            if (nearObj.gameObject.name == "quit")
            {
                Time.timeScale = 1;
                GameObject.Find("AudioSource").GetComponent<BgmManager>().audioSources[gameManager.stageNum].UnPause();
                SceneManager.LoadScene("OnStageSelect");
            }



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
        Debug.Log(nearObj);
        return targetObj;

    }

}