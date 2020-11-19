using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // İlk olarak rotasyon ayarlanacak ardından sonsuz olarak rota dahilinde ilerlenecek. Eğer bir objeye veya alan dışına çıkarsa durucak yada oyun bitmiş olucak.
    Transform enemy;
    Rigidbody2D rb;
    Vector2 mousePos;
    public Camera cam;
    public float speed;
    int tik;
    int puan;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tik = 2;
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.white) { puan++; }
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            speed = 0;
            rb.velocity = Vector3.zero;
            //this.gameObject.transform.parent = collision.gameObject.transform;
            rb.velocity = new Vector2(0, -1.5f);
            Debug.Log(puan);           
        }
    }

    public Vector2 rot() //camerayı kullanarak mousen açısını hesaplıyoruz.
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float distance = lookDir.magnitude;
        Vector2 direction = lookDir / distance;
        direction.Normalize();
        return direction;
    }
    void moveCharacter_v(Vector2 direction)
    {
        speed = 10.0f;
        rb.velocity = Vector3.zero;
        this.transform.parent = null;
        rb.velocity = direction * speed;
    }
    public void Start()
    {
        puan = 0;
        tik = 2;
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Vector2 dr = rot();
        if (Input.GetMouseButtonDown(0)) {
            if (tik>0) { moveCharacter_v(dr); tik--; }
        }

    }
}
