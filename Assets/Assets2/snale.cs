using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snale : MonoBehaviour {

    public float delta3, n, n2;
    public Rigidbody rb3;
    bool a3 = true;
    bool c3 = true;
    float speed = 0.5f;
    float step;
    /*GameObject scale;
    Generator script;
    */// Use this for initialization
    void Start()
    {
        rb3 = GetComponent<Rigidbody>();
        rb3.velocity = new Vector3(0, 0, -7);
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
        this.delta3 += Time.deltaTime;
        /*switch(delta){
            case float delta when delta > 2.3f:
        }*/

        if(Pos.x>0 && a3 == true)
        {
            /*if (Pos.z < -10 && a3 == true)
            {
                rb3.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -30 && a3 == true)
            {
                rb3.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (delta3>5 && a3 == true)
            {
                rb3.velocity = new Vector3(-5, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a3 = false;
            }
        }


        if (Pos.x < 0 && a3 == true)
        {
            transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
            c3 = false;
            /*if (Pos.z < -10 && a3 == true)
            {
                rb3.velocity = new Vector3(0, -40, -20);
            }

            if (Pos.z <= -30 && a3 == true)
            {
                rb3.velocity = new Vector3(-20, -40, 0);
            }
            */
            if (delta3>5 && a3 == true)
            {
                rb3.velocity = new Vector3(5, 0, 0);
                GetComponent<Animator>().SetTrigger("a");
                a3 = false;
            }
        }



        if (Pos.x < -50 && c3 == true)
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 89, 0), step);

            n2 += Time.deltaTime;

            if (n2>6.5f)
            {
                transform.rotation = Quaternion.AngleAxis(91, new Vector3(0, 1, 0));
                rb3.velocity = new Vector3(5, 0, 0);
                c3 = false;
                n2 = 0;
                step = 0;
            }
        }

        if (Pos.x > 60 && c3 == false)
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 269, 0), step);

            n2 += Time.deltaTime;


            if (n2 > 6.5f)
            {
                transform.rotation = Quaternion.AngleAxis(271, new Vector3(0, 1, 0));
                rb3.velocity = new Vector3(-5, 0, 0);
                c3 = true;
                n2 = 0;
                step = 0;
            }
        }


        if (delta3 > 150)
        {
            this.n += Time.deltaTime;
            rb3.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetTrigger("b");
        }

        if (this.n > 3.0f)
        {
            rb3.velocity = new Vector3(0, 0, 15);
        }

        if (this.n > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bear")
        {
            delta3 = 151;
        }

    }
}
