using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour {

    public float delta,d,d2;
    public Rigidbody rb;
    bool a = true;
    bool c = true;
    float speed = 1.5f;
    float step;
    /*
    GameObject scale;
    Generator script;
    */
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -7);
        /*scale = GameObject.Find("GameObject");
        script = scale.GetComponent<Generator>();
        float animalescale = script.m;
        this.transform.localScale = new Vector3(animalescale, animalescale, animalescale);
    */
    }

    // Update is called once per frame
    void Update () {
        Vector3 Pos = this.transform.position;
        this.delta += Time.deltaTime;


        if (Pos.x>0 && a==true)
        {
            /*
            if (Pos.z < -10 && a == true)
            {
                rb.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a == true)
            {
                rb.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a == true*/delta>3)
            {
                rb.velocity = new Vector3(-20, 0, 0);
                GetComponent<Animator>().SetTrigger("d");
                a = false;
            }
        }

        if (Pos.x < 0 && a == true)
        {
            transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
            c = false;
            /*
            if (Pos.z < -10 && a == true)
            { 
            rb.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a == true)
            {
                rb.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a == true*/delta>3)
            {
                rb.velocity = new Vector3(40, 0, 0);
                GetComponent<Animator>().SetTrigger("e");
                a = false;
            }
        }



        if (Pos.x < -50 && c==true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            //rb.velocity = new Vector3(-10, 0, 10);
            GetComponent<Animator>().SetTrigger("e");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 89, 0), step);

            d2 += Time.deltaTime;
            /*if (d2 > 1.5f)
            {
                rb.velocity = new Vector3(10, 0, 10);
            }
            */
            if (d2 > 2.9f)
            {
                transform.rotation = Quaternion.AngleAxis(91, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("d2");
                rb.velocity = new Vector3(40, 0, 0);
                c = false;
                d2 = 0;
                step = 0;

            }
        }

        if (Pos.x > 50 && c==false)
        {
            rb.velocity = new Vector3(0, 0, 0);
            //rb.velocity = new Vector3(10, 0, -10);
            GetComponent<Animator>().SetTrigger("d");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 269, 0), step);

            d2 += Time.deltaTime;
            /*if (d2 > 1.5f)
            {
                rb.velocity = new Vector3(-10, 0, -10);
            }
            */
            if (d2>2.9f)
            {
                transform.rotation = Quaternion.AngleAxis(271, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("e2");
                rb.velocity = new Vector3(-20, 0, 0);
                c = true;
                d2 = 0;
                step = 0;

            }
        }

        if(System.Math.Abs(delta % 20) < 0.1f && Pos.z<0)
        {
            rb.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("c");
        }

        if (rb.velocity == new Vector3(0, 0, 0) && delta < 80)
        {
            d2 += Time.deltaTime;
            if (c == true && d2 > 3.9f)
            {
                //GetComponent<Animator>().SetTrigger("b");
                rb.velocity = new Vector3(-20, 0, 0);
                d2 = 0;
            }
            if (c == false && d2 > 3.9f)
            {
                //GetComponent<Animator>().SetTrigger("c");
                rb.velocity = new Vector3(40, 0, 0);
                d2 = 0;
            }
        }



        if (delta>80)
        {
            this.d += Time.deltaTime;
            rb.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("f");
        }

        if (this.d > 3.0f)
        {
            rb.velocity = new Vector3(0, 0, 15);
        }

        if (this.d > 7.0f){
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            delta = 81;
        }

    }
}
