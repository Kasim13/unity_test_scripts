using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D rb;
    public float hiz;
    Transform enemy;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.gameObject.transform.position = this.transform.position;
            enemy = collision.gameObject.transform;
            this.transform.parent = enemy.transform;
            Debug.Log("aa");
        }
    }

    void moveCharacter_v(Vector2 direction)
    {
        this.transform.parent = null;
        hiz = 10;
        rb.velocity = direction * hiz;
    }

    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveCharacter_v(movement);
    }
}
