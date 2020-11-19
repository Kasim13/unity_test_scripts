using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut : MonoBehaviour
{
    Transform kus;
    public bool grab;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kus")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grab == false)
                {
                    kus = GameObject.FindGameObjectWithTag("kus").transform;
                    this.transform.parent = kus.transform;
                    this.GetComponent<Rigidbody2D>().isKinematic = true; 
                    grab = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (grab == true)
                {
                  this.GetComponent<Rigidbody2D>().isKinematic = false;
                  transform.parent = null;
                  grab = false;
                }         
            }
        }
    }
}
