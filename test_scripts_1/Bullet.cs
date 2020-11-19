using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    spuan sss;
    DarkPlayerScript _DarkPlayer;
    WhitePlayerScripts _WhitePlayer;

    private void Start()
    {
        sss = GameObject.Find("WhitePlayer").gameObject.GetComponent<spuan>();
        _DarkPlayer = GameObject.Find("DarkPlayer").gameObject.GetComponent<DarkPlayerScript>();
        _WhitePlayer = GameObject.Find("WhitePlayer").gameObject.GetComponent<WhitePlayerScripts>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        if (collision.gameObject.tag == "WhitePlayer")
        {
            sss.birak();
            _DarkPlayer.puan();
            collision.gameObject.transform.position = new Vector2(-0.3f, 4f);
        }
        Destroy(gameObject);
    }
}


