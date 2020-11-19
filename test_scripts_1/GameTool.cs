using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTool : MonoBehaviour
{
    public int time;
    public GameObject a;
   // TMPro.TextMeshProUGUI skor_dark;
   // TMPro.TextMeshProUGUI skor_WhitePlayer;
   // TMPro.TextMeshProUGUI GameOverWin;
    private void Start()
    {
        
       // skor_dark = GameObject.Find("Canvas/Panel/skor_DarkPlayer").GetComponent<TextMeshProUGUI>();
       // skor_WhitePlayer = GameObject.Find("Canvas/Panel/skor_WhitePlayer").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(Time.time>time)
        {
            a.SetActive(true);
            Time.timeScale = 0;
            /*
            GameOverWin = GameObject.Find("GameOver-Canvas/GameOverWin").GetComponent<TextMeshProUGUI>();
            int b = Convert.ToInt32(skor_dark.text);
            int c = Convert.ToInt32(skor_WhitePlayer.text);
            if (b>c)
            {
                Debug.Log("DARK WİN!");
            }
            else
            { Debug.Log("WHİTE WİN!"); }
            */
        }
    }
}
