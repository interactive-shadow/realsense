using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clab : MonoBehaviour
{

    public float delta5, c, c2;
    public Rigidbody rb5;
    bool a5 = true;
    bool c5 = true;
    /*GameObject scale;
    Generator script;
    */
    //float speed2 = 1.5f;
    //float step2;
    // Use this for initialization
    void Start()
    {
        rb5 = GetComponent<Rigidbody>();
        rb5.velocity = new Vector3(0, 0, -7);
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
        this.delta5 += Time.deltaTime;
        /*

        if (Pos.z < 0 && a5 == true)
        {
            rb5.velocity = new Vector3(0, -40, -20);
            step2 = speed2 * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(180, 0, 180), step2);

        }

        if (Pos.z <= -40 && a5 == true)
        {
            rb5.velocity = new Vector3(-20, -40, 0);
        }
        */

        if (/*Pos.y <= 78*/delta5 > 3 && a5 == true)
        {
            rb5.velocity = new Vector3(-20, 0, 0);
            GetComponent<Animator>().SetTrigger("a");
            a5 = false;
        }

        if (Pos.x < -50 && c5 == true)
        {
            GetComponent<Animator>().SetTrigger("b");
            //rb5.velocity = new Vector3(-4, 0, 4);
            //step2 = speed2 * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 179, 0), step2);

            /*
            c2 += Time.deltaTime;
            if (c2 > 3.0)
            {
                rb5.velocity = new Vector3(4, 0, 4);
            }

            if (c2 > 5.9f)
            {
                transform.rotation = Quaternion.AngleAxis(181, new Vector3(0, 1, 0));
                */
            GetComponent<Animator>().SetTrigger("a2");
            rb5.velocity = new Vector3(40, 0, 0);
            c5 = false;
            //c2 = 0;
            //}
        }

        if (Pos.x > 60 && c5 == false)
        {
            //rb5.velocity = new Vector3(4, 0, -4);
            GetComponent<Animator>().SetTrigger("a");
            //step2 = speed2 * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 359, 0), step2);

            /*
            c2 += Time.deltaTime;
            if (c2 > 3.0)
            {
                rb5.velocity = new Vector3(-4, 0, -4);
            }

            if (c2 > 5.9f)
            {
                transform.rotation = Quaternion.AngleAxis(361, new Vector3(0, 1, 0));
                */
            GetComponent<Animator>().SetTrigger("b2");
            rb5.velocity = new Vector3(-10, 0, 0);
            c5 = true;
            //c2 = 0;
            //}
        }


        if (delta5 > 40)
        {
            this.c += Time.deltaTime;
            rb5.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("c");
        }

        if (this.c > 3.0f)
        {
            rb5.velocity = new Vector3(0, 0, 10);
        }

        if (this.c > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear" || other.gameObject.tag == "swan")
        {
            delta5 = 41;
        }

    }
}
