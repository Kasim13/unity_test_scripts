using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LineDragPower : MonoBehaviour
{
    int puan;

    public float BallPower;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;
    public LineRenderer line;

    public new Camera camera;

    Vector2 ballForce;
    Vector3 startPoint;
    Vector3 endPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.white) { puan++; }
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            rb.velocity = Vector3.zero;
            //this.gameObject.transform.parent = collision.gameObject.transform;
            rb.velocity = new Vector2(0, -1.5f);
            Debug.Log(puan);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gravitynegative")
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
            Debug.Log("lan ters döndük laa");
        }
        else this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }


        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            Drawlint(startPoint,currentPoint);
        }


        if (Input.GetMouseButtonUp(0))
        {
            endPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            ballForce = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(ballForce * BallPower, ForceMode2D.Impulse);
            endline();
            float a= (startPoint.y);
            float b= (endPoint.y);
            //gravityvalue( a, b);
        }
    }

    public void Drawlint(Vector3 startpoint,Vector3 endpoint)
    {
        line.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startpoint;
        Allpoint[1] = endpoint;
        line.SetPositions(Allpoint);
    }
    public void endline()
    {
        line.positionCount = 0;
    }
    
    public void gravityvalue(float a, float b)
    {
        if((a + (-b))>0) this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        else this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
        Debug.Log(a + (-b));
    }
}
