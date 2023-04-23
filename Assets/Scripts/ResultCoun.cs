using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCoun : MonoBehaviour {

    public GameObject[] Thousand;
    public GameObject [] Hundred;
    public GameObject[] Ten;
    public GameObject[] One;

    
    // Use this for initialization
    void Start () {
        int combocoun = ComboText.maxcombo;
        int tho = combocoun / 1000;
        int h = combocoun % 1000/100;
        int t = combocoun % 1000 %100/10;
        int o = combocoun % 1000%100 % 10;

        Thousand[tho].SetActive(true);
        Hundred[h].SetActive(true);
        Ten[t].SetActive(true);
        One[o].SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
