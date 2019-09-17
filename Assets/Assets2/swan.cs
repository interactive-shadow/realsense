using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swan : MonoBehaviour {

    public float delta4, h, h2;
    public Rigidbody rb4;
    bool a4 = true;
    bool c4 = true;
    float speed = 1.5f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb4 = GetComponent<Rigidbody>();
        rb4.velocity = new Vector3(0, 0, -7);
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
        this.delta4 += Time.deltaTime;
        /*switch(delta){
            case float delta when delta > 2.3f:
        }*/

        if(Pos.x>0 && a4 == true)
        {
            /*if (Pos.z < -10 && a4 == true)
            {
                rb4.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a4 == true)
            {
                rb4.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 */delta4>4 && a4 == true)
            {
                rb4.velocity = new Vector3(-15, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a4 = false;
            }
        }

        if (Pos.x < 0 && a4 == true)
        {
            transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
            c4 = false;
            /*
            if (Pos.z < -10 && a4 == true)
            {
                rb4.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a4 == true)
            {
                rb4.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78*/delta4>4 && a4 == true)
            {
                rb4.velocity = new Vector3(60, 0, 0);
                GetComponent<Animator>().SetTrigger("b");
                a4 = false;
            }
        }




        if (Pos.x < -50 && c4 == true)
        {
            GetComponent<Animator>().SetTrigger("b");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 89, 0), step);

            h2 += Time.deltaTime;

            if (h2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(91, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("a2");
                rb4.velocity = new Vector3(60, 0, 0);
                c4 = false;
                h2 = 0;
                step = 0;
            }
        }

        if (Pos.x > 60 && c4 == false)
        {
            GetComponent<Animator>().SetTrigger("a");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 269, 0), step);

            h2 += Time.deltaTime;
            rb4.velocity = new Vector3(5, 0, 0);
            if (h2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(271, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("b2");
                rb4.velocity = new Vector3(-15, 0, 0);
                c4 = true;
                h2 = 0;
                step = 0;
            }
        }


        if (rb4.velocity == new Vector3(0, 0, 0) && delta4 < 100)
        {
            h2 += Time.deltaTime;
            if (c4 == true && h2 > 3)
            {
                //GetComponent<Animator>().SetTrigger("b");
                rb4.velocity = new Vector3(-15, 0, 0);
                h2 = 0;
            }
            if (c4 == false && h2 > 3)
            {
                //GetComponent<Animator>().SetTrigger("c");
                rb4.velocity = new Vector3(60, 0, 0);
                h2 = 0;
            }
        }

        if (delta4 > 100)
        {
            this.h += Time.deltaTime;
            rb4.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("d");
        }

        if (this.h > 3.0f)
        {
            rb4.velocity = new Vector3(0, 0, 15);
        }

        if (this.h > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            delta4 = 101;
        }
        if(other.gameObject.tag == "crab")
        {
            rb4.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("c");
        }
    }
}
