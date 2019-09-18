using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meguro_Bytizer : MonoBehaviour
{
    public Texture2D testTex;

    public SocketManager sm;

    public int len = 100;

    private byte[] image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = new byte[testTex.width * testTex.height];

        for (int y = 0; y < testTex.height; y++)
        {
            //Debug.Log("current:" + y);
            for (int x = 0; x < testTex.width; x++)
            {
                int index = x + y * testTex.width;
                image[index] = testTex.GetPixel(x, y).r > 0.5 ? (byte)0 : (byte)1;
                //image[index] = (byte)1;
            }
        }

        /*for(int i = 0; i < testTex.width * testTex.height; i++)
        {
            int num = i / 2000;
            image[i] = (byte)num.ToString()[num.ToString().Length - 1];
        }*/
        
        //image = new[] {(byte) 1, (byte) 5, (byte) 6};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SendMessage:" + image);
            //MakeBytes();
            sm.SendImage(image);
        }
    }

    void MakeBytes()
    {
        image = new byte[len];
        for (int i = 0; i < image.Length; i++)
        {
            image[i] = (byte)1;
        }
    }
}
