using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spuan : MonoBehaviour
{
    public bool tut;
    public GameObject Wp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            if (tut == false)
            {
                Wp = collision.gameObject;
                collision.gameObject.SetActive(false);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                tut = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity= Vector2.zero;
    }

    public void birak()
    {
        if (tut == true)
        {   
            Wp.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1.42f);
            Wp.gameObject.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            tut = false;
        }
    }

    void Start()
    {
        tut = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            birak();
        }
    }
}