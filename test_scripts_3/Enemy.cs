using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float hiz = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Zemin") 
        {
            collision.gameObject.transform.position = new Vector2(0f, 6f);
            this.gameObject.transform.position = new Vector2(0f, 6f);
            Debug.Log("gameover");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.transform.position = new Vector2(0f, 6f);
            //collision.gameObject.transform.GetComponent<Rigidbody>().velocity = Vector2.zero;
        }
    }





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        transform.Translate(0, -hiz * Time.deltaTime, 0);
    }

}
