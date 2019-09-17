using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{

    public float delta2, s, s2;
    public Rigidbody rb2;
    bool a2 = true;
    bool b2 = true;
    bool bb = true;
    bool c2 = true;
    float speed = 2f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        rb2.velocity = new Vector3(0, 0, -7);
       /* scale = GameObject.Find("GameObject");
        script = scale.GetComponent<Generator>();
        float animalescale = script.m;
        this.transform.localScale = new Vector3(animalescale, animalescale, animalescale);
    */
    }
        // Update is called once per frame
    void Update()
    {
        Vector3 Pos = this.transform.position;
        this.delta2 += Time.deltaTime;
        /*switch(delta){
            case float delta when delta > 2.3f:
        }*/
        if (Pos.x > 0 && a2 == true)
        {
            if (delta2 > 1)
            {
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 90), step);
            }
            /*
            if (Pos.z < -10 && a2 == true)
            {
                rb2.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a2 == true)
            {
                rb2.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a2 == true*/delta2>4)
            {
                rb2.velocity = new Vector3(-20, 0, 0);
                GetComponent<Animator>().SetTrigger("b");
                a2 = false;
            }
        }

        if (Pos.x < 0 && a2 == true)
        {
            if (b2 == true)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z* -1);
                b2 = false;
            }
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 20);
            c2 = false;
            if (delta2 > 2.5f)
            {
                step = speed * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 90), step);
            }
            /*
            if (Pos.z < -10 && a2 == true)
            {
                rb2.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -40 && a2 == true)
            {
                rb2.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (/*Pos.y <= 78 && a2 == true*/delta2>5)
            {
                rb2.velocity = new Vector3(50, 0, 0);
                GetComponent<Animator>().SetTrigger("c");
                a2 = false;
            }
        }



        if (Pos.x < -100 && c2 == true)
        {
            GetComponent<Animator>().SetTrigger("b2");
            transform.rotation = Quaternion.AngleAxis(180, new Vector3(1, 0, 1))* Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
            if(b2 == false)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(1, 0, 1)) * Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
            }
            bb = false;
            if (bb == false && b2==false)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            }
            GetComponent<Animator>().SetTrigger("c");
            rb2.velocity = new Vector3(50, 0, 0);
            c2 = false;

        }

        if (Pos.x > 100 && c2 == false)
        {
            GetComponent<Animator>().SetTrigger("c2");
            transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)) * Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            if(b2 == false)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)) * Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            }
            if (bb == false && b2 ==false)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            }
            GetComponent<Animator>().SetTrigger("b");
            rb2.velocity = new Vector3(-20, 0, 0);
            c2 = true;
        }

        if(rb2.velocity == new Vector3(0,0,0) && delta2< 80)
        {
            s2 += Time.deltaTime;
            if (c2 == true && s2 > 1)
            {
                GetComponent<Animator>().SetTrigger("b");
                rb2.velocity = new Vector3(-20, 0, 0);
                s2 = 0;
            }
            if (c2 == false && s2 > 1)
            {
                GetComponent<Animator>().SetTrigger("c");
                rb2.velocity = new Vector3(50, 0, 0);
                s2 = 0;
            }
        }





        if (delta2 > 80)
        {
            this.s += Time.deltaTime;
            rb2.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("f");
        }

        if (this.s > 3.0f)
        {
            rb2.velocity = new Vector3(0, 0, 15);
        }

        if (this.s > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "flog")
        {
            GetComponent<Animator>().SetTrigger("a");
            rb2.velocity = new Vector3 (0,0,0);
        }
        if (other.gameObject.tag == "bear" || other.gameObject.tag == "snale")
        {
            delta2 = 81;
        }

    }

}
