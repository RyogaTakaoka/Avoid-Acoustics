using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserComboCount : MonoBehaviour {

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Wall")
        {
            GameObject.Find("Canvas/ComboText").GetComponent<ComboText>().AddPoint(1);
        }
        if (c.gameObject.tag == "player")
        {
            int combocount = ComboText.combo;
            combocount = 0;
            FindObjectOfType<ComboText>().Initialize();
        }
    }
}
