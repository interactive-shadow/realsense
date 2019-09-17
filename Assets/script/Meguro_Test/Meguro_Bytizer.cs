using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meguro_Bytizer : MonoBehaviour
{
    public Texture2D testTex;

    public SocketManager sm;

    private byte[] image;
    
    // Start is called before the first frame update
    void Start()
    {
        /*image = new byte[testTex.width * testTex.height];

        for (int y = 0; y < testTex.height; y++)
        {
            //Debug.Log("current:" + y);
            for (int x = 0; x < testTex.width; x++)
            {
                int index = x + y * testTex.width;
                image[index] = testTex.GetPixel(x, y).r > 0.5 ? (byte)1 : (byte)0;
            }
        }*/
        image = new[] {(byte) 1, (byte) 5, (byte) 6};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SendMessage:" + image);
            sm.SendImage(image);
        }
    }
}
