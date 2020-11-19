using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRealise : MonoBehaviour
{
    //Bow
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    //Bow ile noktalı çizgi nisangahı
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    Vector2 direction;
    public float spaceBetweenPoints;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;
        //Ust tarafta bulunan kodlar objenin yonun mouse takip etmesini sağlayacak.

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        for(int i=0; i< numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }






}
