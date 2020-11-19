using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WhitePlayerScripts : MonoBehaviour
{
    /*
       Transform seker;
       public bool tut;

       private void OnCollisionStay2D(Collision2D collision)
       {
           if (collision.gameObject.tag == "seker")
           {
               //if (this.gameObject.transform.parent == null) { tut = false; } else { tut = true; }
               if (Input.GetKeyDown(KeyCode.Space))
               {
                   if (tut == false)
                   {
                       seker = collision.gameObject.transform;
                       seker.transform.parent = this.transform;
                       seker.GetComponent<Rigidbody2D>().isKinematic = true;
                       tut = true;
                       //seker = GameObject.FindGameObjectWithTag("seker").transform;
                       //transform.position = Vector2.MoveTowards(transform.position, seker.position, Time.deltaTime * hiz);
                   }
                   if (Input.GetKeyUp(KeyCode.Space))
                   {
                       if (tut == true) {
                           this.transform.parent = null;
                           seker.GetComponent<Rigidbody2D>().isKinematic = false;
                           tut = false;
                       }
                   }
               }
           }
       }
   void move1()
   {
      float sag_sol_ok = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
      float yukari_asagi_ok = Input.GetAxis("Vertical") * Time.deltaTime * hiz;
      transform.Translate(sag_sol_ok, yukari_asagi_ok, 0, Space.World);
   }*/

    public Vector2 movement;
    public Rigidbody2D rb;
    ParticleSystem sn, sn2;
    Light2D pl;
    public float hiz;
    public bool freeze = false;
    public float dash = 60f;
    public float boostspeed = 15f;
    public float cooluse_bo = 2f;
    public float cooluse_freeze = 3f;
    public float cooldown_bo = 2f;
    public float cooldown_dash = 4f;
    public float cooldown_freeze = 4f;
    private float nexttime_freeze = 0f;
    private float nexttime_dash = 0f;
    private float nexttime_bo = 0f;
    private float usetime_bo = 0f;
    private float usetime_freeze = 0f;
    /*
    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        { transform.Translate(hiz * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.LeftArrow))
        { transform.Translate(-hiz * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.UpArrow))
        { transform.Translate(0, hiz * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.DownArrow))
        { transform.Translate(0, -hiz * Time.deltaTime, 0); } 
    }
    void move2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {  new Vector2(1.0f, 0.0f); }
        if (Input.GetKey(KeyCode.LeftArrow))
        {  new Vector2(-1.0f, 0.0f); }
        if (Input.GetKey(KeyCode.UpArrow))
        {  new Vector2(0.0f, 1.0f); }
        if (Input.GetKey(KeyCode.DownArrow))
        {  new Vector2(0.0f, -1.0f); }
    }
    void moveCharacter_Mp(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * hiz * Time.deltaTime));
    }
    void moveCharacter_force(Vector2 direction)
    {
        rb.AddForce(direction * dash);
    }
    */
    void moveCharacter_v(Vector2 direction)
    {
        rb.velocity = direction * hiz;
    }
    void dashCharacter_v(Vector2 direction)
    {
        //rb.AddForce(movement * dash);
        //rb.transform.Translate(movement * dash);
        rb.velocity = direction * dash;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sn = GameObject.Find("SnowParticle").gameObject.GetComponent<ParticleSystem>();
        sn2 = GameObject.Find("WhiteDashParticle").gameObject.GetComponent<ParticleSystem>();
        pl = GameObject.Find("WhitePlayerLight").gameObject.GetComponent<Light2D>();
    }
    void Update()
    {
        if (Time.time > nexttime_bo)
        {
            if (Input.GetKey(KeyCode.Keypad0))
            {
                pl.enabled = true;
                sn2.Play();
                hiz = boostspeed;
                nexttime_bo = Time.time + cooldown_bo;
                usetime_bo = Time.time + cooluse_bo;
            }
        }
        if (Time.time > nexttime_freeze)
        {
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                sn.Play();
                freeze = true;
                usetime_freeze = Time.time + cooluse_freeze;
                nexttime_freeze = Time.time + cooldown_freeze;
            }
        }
        if (Time.time > usetime_bo) { hiz = 5f;  sn2.Stop(); pl.enabled = false; }
        if (Time.time > usetime_freeze) { freeze = false; sn.Stop(); }
    }
    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveCharacter_v(movement);
        if (Time.time > nexttime_dash)
        {
            if (Input.GetKey(KeyCode.Keypad1))
            {
                dashCharacter_v(movement);
                nexttime_dash = Time.time + cooldown_dash;
            }
        }
    }
}
