using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour
{

    public Text comboText;

    public Text maxcomboText;

    public static int combo;

    public static int maxcombo;

    private string maxcomboKey = "maxcombo";

    // Use this for initialization
    void Start()
    {
        combo = 0;
        comboText = gameObject.GetComponent<Text>();
        comboText.text = "Combo : " + combo.ToString();
        Initialize();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(maxcombo < combo)
        {
            maxcombo = combo;
        }

        maxcomboText.text = "Max : " + maxcombo.ToString();

        PlayerPrefs.SetInt(maxcomboKey, maxcombo);
    }

    public void AddPoint(int point)
    {
        combo = combo + point;
        comboText = gameObject.GetComponent<Text>(); // <---- 追加3
        comboText.text = "Combo : " + combo.ToString();
    }

    // ゲーム開始前の状態に戻す
    public void Initialize()
    {
        // スコアを0に戻す
        combo = 0;

        
    }

    
}