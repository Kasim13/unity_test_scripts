using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isiktut : MonoBehaviour
{
    Rigidbody2D rb2D;
    Transform seker;
    public bool tut;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,5f);

        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "seker")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (tut == false)
                    {
                        seker = hit.collider.gameObject.transform;
                        seker.transform.parent = this.transform;
                        seker.GetComponent<Rigidbody2D>().isKinematic = true;
                        tut = true;
                    }else if (tut == true) {
                        this.transform.parent = null;
                        seker.GetComponent<Rigidbody2D>().isKinematic = false;
                        tut = false;
                    }
                }
            }
            Debug.Log(hit.collider.name);
        }
    }
}
