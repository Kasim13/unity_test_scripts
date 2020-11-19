using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    spuan sss;
    DarkPlayerScript _DarkPlayer;
    WhitePlayerScripts _WhitePlayer;
    private float nexttime_laser = 0f;
    private float usetime_laser = 0f;
    public float cooldown_laser = 5f;
    public float cooluse_laser = 1f;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        sss = GameObject.Find("WhitePlayer").gameObject.GetComponent<spuan>();
        _DarkPlayer = GameObject.Find("DarkPlayer").gameObject.GetComponent<DarkPlayerScript>();
        _WhitePlayer = GameObject.Find("WhitePlayer").gameObject.GetComponent<WhitePlayerScripts>();
    }

    void laserk()
    {
        _lineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider)
        {
            _lineRenderer.SetPosition(1, new Vector2(hit.point.x, hit.point.y));
            _lineRenderer.enabled = true;
            if (hit.collider.gameObject.tag == "WhitePlayer")
            {
                sss.birak();
                _DarkPlayer.puan();
                hit.collider.gameObject.transform.position = new Vector2(-0.3f, 4f);
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.up * 2000);
        }
    }


    void laserreset()
    {
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        if (_WhitePlayer.freeze == false)
        {
            if (Time.time > nexttime_laser)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    nexttime_laser = Time.time + cooldown_laser;
                    usetime_laser = Time.time + cooluse_laser;
                }   
            }
        }

        if (Time.time < usetime_laser) { laserk(); } else { laserreset(); }


    }
}
