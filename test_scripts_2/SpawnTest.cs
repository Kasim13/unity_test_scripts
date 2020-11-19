using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    //Spawn olan objelerin ozellikleri. Circle için çalışıyor. hız ve yok olma var. spawn olunca bu kodlar çalışıyor.
    public float speed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.y < -screenBounds.y-1)
        {
            Destroy(this.gameObject);
        }
    }
}
