//画面上部に表示するタイムゲージを表示します。
//曲の長さと、現在の経過時間より、パーセンテージを取得し、表示。
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarTimer : MonoBehaviour
{
    //タイマーと、再生する曲を入れる。

    [SerializeField]
    private Timer timer;
    [SerializeField]
    private AudioClip music;

    private float musicLength;
    private Image image;

    void Start()
    {
        //曲の長さを取得
        musicLength = music.length;
        //画像を格納
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //画像のFillAmountを更新し続ける。
        if(SceneManager.GetSceneByName("OnPause").isLoaded == false)
        {
            image.fillAmount = 1 - (timer.Now / musicLength);
        }
        
    }
}