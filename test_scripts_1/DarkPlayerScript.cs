using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DarkPlayerScript : MonoBehaviour
{
    private float nexttime_shoot = 0f;
    private float usetime_shoot = 0f;
    public float cooldown_shoot = 10f;
    public float cooluse_shoot = 5f;

    TMPro.TextMeshProUGUI skor_dark;
    spuan sss;
    WhitePlayerScripts _WhitePlayer;
    int skordark = 0;
    public float hizy = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WhitePlayer")
        {
            if (Input.GetKey(KeyCode.F))
            {
                sss.birak();
                puan();
                collision.gameObject.transform.position = new Vector2(-0.3f, 4f);
            }
        }
    }
    public void puan()
    {
        skordark += 1;
        skor_dark.text = skordark.ToString();
    }

    void Start()
    {
        skor_dark = GameObject.Find("Canvas/Panel/skor_DarkPlayer").GetComponent<TextMeshProUGUI>();      
        sss = GameObject.Find("WhitePlayer").gameObject.GetComponent<spuan>();
        _WhitePlayer = GameObject.Find("WhitePlayer").gameObject.GetComponent<WhitePlayerScripts>();
    }
    void move()
    {
        if (Input.GetKey(KeyCode.D))
        { if (transform.position.x < 6.5f) { transform.Translate(hizy * Time.deltaTime, 0, 0); } }
        if (Input.GetKey(KeyCode.A))
        { if (transform.position.x > -6.5f) { transform.Translate(-hizy * Time.deltaTime, 0, 0); } }
        /*
        if (Input.GetKey(KeyCode.W))
        { if (transform.position.y < -1.4) { transform.Translate(0, hizy * Time.deltaTime, 0); } }
        if (Input.GetKey(KeyCode.S))
        { if (transform.position.y > -6.5) { transform.Translate(0, -hizy * Time.deltaTime, 0); } }
        */
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (_WhitePlayer.freeze == false)
        {
            move();
            if (Time.time > nexttime_shoot)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nexttime_shoot = Time.time + cooldown_shoot;
                    usetime_shoot = Time.time + cooluse_shoot;
                }
            }
        
        if (Time.time < usetime_shoot)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                shoot();
            }
        }
        }
    }
}
