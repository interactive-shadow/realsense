using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deer : MonoBehaviour {

    public float delta6, k, k2;
    public Rigidbody rb6;
    bool a6 = true;
    bool c6 = true;
    float speed = 1.5f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb6 = GetComponent<Rigidbody>();
        rb6.velocity = new Vector3(0, 0, -7);
     /*   scale = GameObject.Find("GameObject");
        script = scale.GetComponent<Generator>();
        float animalescale = script.m;
        this.transform.localScale = new Vector3(animalescale, animalescale, animalescale);
    */
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = this.transform.position;
        this.delta6 += Time.deltaTime;

        if(Pos.x>0 && a6 == true)
        {
            if (delta6>4 && a6 == true)
            {
                rb6.velocity = new Vector3(-15, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a6 = false;
            }
        }

        if (Pos.x < 0 && a6 == true)
        {
            transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
            c6 = false;
            if (delta6>4 && a6 == true)
            {
                rb6.velocity = new Vector3(50, 0, 0);
                GetComponent<Animator>().SetTrigger("b");
                a6 = false;
            }
        }




        if (Pos.x < -50 && c6 == true)
        {
            GetComponent<Animator>().SetTrigger("b");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 89, 0), step);

            k2 += Time.deltaTime;

            if (k2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(91, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("a2");
                rb6.velocity = new Vector3(50, 0, 0);
                c6 = false;
                k2 = 0;
                step = 0;
            }
        }

        if (Pos.x > 60 && c6 == false)
        {
            GetComponent<Animator>().SetTrigger("a");
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 269, 0), step);

            k2 += Time.deltaTime;
            rb6.velocity = new Vector3(5, 0, 0);
            if (k2 > 1.9f)
            {
                transform.rotation = Quaternion.AngleAxis(271, new Vector3(0, 1, 0));
                GetComponent<Animator>().SetTrigger("b2");
                rb6.velocity = new Vector3(-15, 0, 0);
                c6 = true;
                k2 = 0;
                step = 0;
            }
        }


        if (delta6 > 100)
        {
            this.k += Time.deltaTime;
            rb6.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("d");
        }

        if (this.k > 3.0f)
        {
            rb6.velocity = new Vector3(0, 0, 15);
        }

        if (this.k > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            delta6 = 101;
        }

    }
}
