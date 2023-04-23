//////////////////////////////////////////
//ゲームオブジェクトをタイマーにするスクリプトです。

using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    /////////////////////////////////////////

    //タイマー
    private float timer;

    //タイマーを進めるかどうかを決める変数
    public bool timerRun = false;

    //タイマーをリセットする。
    public void ResetTimer() { timer = 0; }

    //タイマーを進める
    public void AddTimer() { timer += Time.deltaTime; }

    //プロパティで値を変えられるようにする。
    //変数をpublicにしないのは、インスペクター上で変えられないようにしたいから
    public float Now { get { return timer; } }

    ///////////////////////////////////////
    //初期化
    void Start()
    {
        //タイマーの初期化
        timer = 0;
    }
    ////////////////////////////////////////
    //アップデート
    void Update()
    {
        if (SceneManager.GetSceneByName("OnPause").isLoaded == false)
        {
            //タイマーを進めるかどうか
            if (timerRun == false) return;

            //タイマーを進める
            AddTimer();
        }
    }
}