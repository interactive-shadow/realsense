using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;

    public GameObject testObject;

    public int n = -1;

    public Transform posImage;

    //public float m = 1;
    //public EstimatedPoint est;
   
    private float delta;
    private Vector3 clickPosition;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            generateAnimal(n);
        }

        if(n != -1)
        {
            generateAnimal(n);
            n = -1;
        }

        delta += Time.deltaTime;
        if (0.5f < delta)
        {
            //int animal　= est;
            //推定した動物に対応した値を代入
           
            //generarionAnimal(animal);
            delta = 0f;
        }
    }
    /// <summary>
    /// アニマルインスタンスを生成
    /// </summary>
    /// <param name="animal">
    /// 1:犬
    /// 2:蛙
    /// 3:蛇
    /// 4:ナメクジ
    /// 5:白鳥
    /// 6:カニ
    /// 7:鹿
    /// 8:熊
    /// 0:ナニモナシ
    ///
    /// </param>
    public void generateAnimal(int animal)
    {
        Vector3 clickPosition = GameObject.Find("Image").transform.position;
        //Vector3 clickPosition = Vector3.zero;

        if (n == 1)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 2)
        {
            GameObject go2 = Instantiate(prefab2) as GameObject;
            go2.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 3)
        {
            GameObject go3 = Instantiate(prefab3) as GameObject;
            go3.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 4)
        {
            GameObject go4 = Instantiate(prefab4) as GameObject;
            go4.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 5)
        {
            GameObject go5 = Instantiate(prefab5) as GameObject;
            go5.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 6)
        {
            GameObject go6 = Instantiate(prefab6) as GameObject;
            go6.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 7)
        {
            GameObject go7 = Instantiate(prefab7) as GameObject;
            go7.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }
        else if (n == 8)
        {
            GameObject go8 = Instantiate(prefab8) as GameObject;
            go8.transform.position = new Vector3(clickPosition.x, clickPosition.y, 96);
        }



    }

    public void testes(int num)
    {
        Debug.Log("testes:" + num);

        n = num;
    }

}