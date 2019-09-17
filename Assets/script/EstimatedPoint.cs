using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstimatedPoint : MonoBehaviour
{

    public RawImage image;
    public float whitePoint;
    public int numCut;
    private int __width;
    private int __height;
    // Start is called before the first frame update
    void Start()
    {
        if (numCut < 2)
            Debug.LogError("numCut is too small");
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        {
            List<ArrayPixel> list = new List<ArrayPixel>();
            Texture2D tex2D = image.texture as Texture2D;
            __width = tex2D.width;
            __height = tex2D.height;
            Debug.Log(__width + "\t" + __height);
            for (int i = 1; i < numCut; i++)
            {
                for (int j = 1; j < numCut; j++)
                {
                    ArrayPixel ap = new ArrayPixel();
                    int _width = tex2D.width * i / numCut;
                    int _height = tex2D.height * j / numCut;
                    ap.binary = GetBinary(tex2D.GetPixel(_width, _height));
                    ap.width = _width;
                    ap.height = _height;
                    list.Add(ap);
                    Debug.Log("\ti:" + _width + "\tj:" + _height + "\tbinary:" + (ap.binary == 0 ? "白" : "黒"));
                }
            }
            CalculateCenterOfGravity(list);
        }
    }
    /// <summary>
    /// 対象のpixelのcolorを渡して2値化した画素を取得
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private int GetBinary(Color color)
    {
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);
        return s < whitePoint ? 0 : 1;
    }
    /// <summary>
    /// 重心の計算を行う
    /// </summary>
    /// <param name="list"></param>
    private void CalculateCenterOfGravity(List<ArrayPixel> list)
    {
        float x = 0, y = 0;
        float sumX = 0, sumY = 0;
        float sum = 0;
        for(int i=0;i<list.Count;i++)
        {
            //x += list[i].width * list[i].binary;
            //y += list[i].height * list[i].binary;
            //sum += list[i].binary;

            x += WeightFunction(list[i].binary, list[i].width, __width) * list[i].width;
            y += WeightFunction(list[i].binary, list[i].height, __height) * list[i].height;
            sumX += WeightFunction(list[i].binary, list[i].width, __width);
            sumY += WeightFunction(list[i].binary, list[i].height, __height);
        }
        this.transform.localPosition = new Vector3(-((x / sumX) - (__width / 2)),-( (y / sumY) - (__height / 2)), 0f);
        //this.transform.localPosition = new Vector3(-((x / sum) - (__width / 2)), -((y / sum) - (__height / 2)), 0f);
    }
    private int WeightFunction(int binary)
    {

        return 2*binary;
    }
    private float WeightFunction(float binary,float judgePointPos,float size)
    {
        return binary * System.Math.Abs(size - 2 * judgePointPos) ;
    }
}
class ArrayPixel
{
    private int _binary;
    private int _width;
    private int _height;

    public int binary
    {
        get
        {
            return this._binary;
        }
        set
        {
            _binary = value;
        }
    }
    public int width
    {
        get
        {
            return this._width;
        }
        set
        {
            _width = value;
        }
    }
    public int height
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
        }
    }
}