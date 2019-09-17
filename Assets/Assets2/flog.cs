using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flog : MonoBehaviour
{
    public float delta1, f, f2;
    public Rigidbody rb1;
    bool a1 = true;
    bool b1 = true;
    bool c1 = true;
    float speed = 1f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb1 = GetComponent<Rigidbody>();
        rb1.velocity = new Vector3(0, 0, -7);
      /*  scale = GameObject.Find("GameObject");
        script = scale.GetComponent<Generator>();
        float animalescale = script.m;
        this.transform.localScale = new Vector3(animalescale, animalescale, animalescale);
    */
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 Pos = this.transform.position;
        this.delta1 += Time.deltaTime;
        /*switch(delta){
            case float delta when delta > 2.3f:
        }*/
        if (Pos.x > 0 && a1 == true)
        {
            if (delta1 > 1)
            {
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 90), step);
            }
            /*
            if (Pos.z < -10 && a1 == true)
            {
                rb1.velocity = new Vector3(0, -40, -20);
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), step);

            }

            if (Pos.z <= -30 && a1 == true)
            {
                rb1.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a1 == true*/delta1>4)
            {
                rb1.velocity = new Vector3(-20, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a1 = false;
            }
        }

        if (Pos.x < 0 && a1 == true)
        {
            if (delta1 > 1)
            {
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, -90), step);
            }
            b1 = false;
            c1 = false;
            /*
            if (Pos.z < -10 && a1 == true)
            {
                rb1.velocity = new Vector3(0, -40, -20);
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), step);

            }

            if (Pos.z <= -30 && a1 == true)
            {
                rb1.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a1 == true*/delta1>4)
            {
                rb1.velocity = new Vector3(20, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a1 = false;
            }
        }

        if (Pos.x<-40 && b1 == true)
        {
            GetComponent<Animator>().SetTrigger("b");
            b1 = false;
        }


        if (Pos.x < -100 && c1 == true)
        {

            /*f2 += Time.deltaTime;
            if (f2 > 1.0)
            {
                if (b1 == true)
                {
                    transform.Rotate(0, -180, 0);
                    b1 = false;
                }
            }

            if (b1 == false)
            {*/
            transform.Rotate(0, -180, 0);
            rb1.velocity = new Vector3(20, 0, 0);
                c1 = false;
                //f2 = 0;
            //}
        }


        if (Pos.x > 50 && b1 == false)
        {
            GetComponent<Animator>().SetTrigger("b");
            b1 = true;
        }

        if (Pos.x > 100 && c1 == false)
        {

            /*f2 += Time.deltaTime;
            if (f2 > 1.0)
            {
                if (b1 == false)
                {
                    transform.Rotate(0, 180, 0);
                    b1 = true;
                }
            }

            if (b1 == true)
            {*/
            transform.Rotate(0, 180, 0);
            rb1.velocity = new Vector3(-20, 0, 0);
                c1 = true;
              //  f2 = 0;
            //}
        }


        if (delta1 > 75)
        {
            this.f += Time.deltaTime;
            rb1.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("c");
        }

        if (this.f > 3.0f)
        {
            rb1.velocity = new Vector3(0, 0, 15);
        }

        if (this.f > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "snake" || other.gameObject.tag == "bear")
        {
            delta1 = 76;
        }

    }
}


