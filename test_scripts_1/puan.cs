using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puan : MonoBehaviour
{
    TMPro.TextMeshProUGUI skor_WhitePlayer;
    public int skorWhitePlayer = 0;
    spuan sp;

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "seker")
        {
         skorsinek += 1;
         skor_sinek.text = skorsinek.ToString();
         //Destroy(collision.gameObject);
         //seker = collision.gameObject.transform;
         //seker.transform.parent = null;
         collision.gameObject.transform.parent = null;
         collision.gameObject.SetActive(false);
        }
    }
    */
    //Mavi alan puan almak için kontrol yapıyor. 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WhitePlayer")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                skorWhitePlayer += 1;
                skor_WhitePlayer.text = skorWhitePlayer.ToString();
                sp.tut = false;
            }
        }

    }

    void Start()
    {
        skor_WhitePlayer = GameObject.Find("Canvas/Panel/skor_WhitePlayer").GetComponent<TextMeshProUGUI>();
        sp = GameObject.Find("WhitePlayer").gameObject.GetComponent<spuan>();
    }
}
