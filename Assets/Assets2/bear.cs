using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour {

    public float delta7, b, b2;
    public Rigidbody rb7;
    bool a7 = true;
    bool c7 = true;
    float speed = 1.5f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb7 = GetComponent<Rigidbody>();
        rb7.velocity = new Vector3(0, 0, -7);
        /*scale = GameObject.Find("GameObject");
        script = scale.GetComponent<Generator>();
        float animalescale = script.m;
        this.transform.localScale = new Vector3(animalescale, animalescale, animalescale);
   */
   }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = this.transform.position;
        this.delta7 += Time.deltaTime;

        if (Pos.x > 0 && a7 == true)
        {
            if (delta7 > 4 && a7 == true)
            {
                rb7.velocity = new Vector3(-15, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a7 = false;
            }
        }

        if (Pos.x < 0 && a7 == true)
        {
            transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
            c7 = false;
            if (delta7 > 4 && a7 == true)
            {
                rb7.velocity = new Vector3(50, 0, 0);
                GetComponent<Animator>().SetTrigger("b");
                a7 = false;
            }
        }




        if (Pos.x < -50 && c7 == true)
        {
            GetComponent<Animator>().SetTrigger("b");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 89, 0), step);

            b2 += Time.deltaTime;

            if (b2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(91, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("a2");
                rb7.velocity = new Vector3(50, 0, 0);
                c7 = false;
                b2 = 0;
                step = 0;
            }
        }

        if (Pos.x > 60 && c7 == false)
        {
            GetComponent<Animator>().SetTrigger("a");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 269, 0), step);

            b2 += Time.deltaTime;
            rb7.velocity = new Vector3(5, 0, 0);
            if (b2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(271, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("b2");
                rb7.velocity = new Vector3(-15, 0, 0);
                c7 = true;
                b2 = 0;
                step = 0;
            }
        }


        if (delta7 > 100)
        {
            this.b += Time.deltaTime;
            rb7.velocity = new Vector3(0, 0, 0);
            if(c7 == true)
            {
                transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
            }
            GetComponent<Animator>().SetTrigger("d");
        }

        if (this.b > 3.0f)
        {
            rb7.velocity = new Vector3(0, 0, 30);
        }

        if (this.b > 7.0f)
        {
            Destroy(this.gameObject);
        }

        if (rb7.velocity == new Vector3(0, 0, 0) && delta7 < 80)
        {
            b2 += Time.deltaTime;
            if (c7 == true && b2 > 3)
            {
                //GetComponent<Animator>().SetTrigger("b");
                rb7.velocity = new Vector3(-20, 0, 0);
                b2 = 0;
            }
            if (c7 == false && b2 > 3)
            {
                //GetComponent<Animator>().SetTrigger("c");
                rb7.velocity = new Vector3(50, 0, 0);
                b2 = 0;
            }
        }
    }



    public void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("c");
        rb7.velocity = new Vector3(0, 0, 0);
    }

}
