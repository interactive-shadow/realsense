using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstimatedPoint : MonoBehaviour
{

    public RawImage image;
    public float whitePoint;
    public int numCut;
    public int windowMagnification;
    public float weightRate;
    public GameObject haveSendImageMethodObject;
    private int __width;
    private int __height;
    private float avePixel = 9881f;
    private float[] weightArray;
    private int window = 224;
    private int windowSize;
    private SocketManager script;
    // Start is called before the first frame update
    void Start()
    {
        if (numCut < 2)
            Debug.LogError("numCut is too small");
        windowSize = window * windowMagnification;
        weightArray = new float[numCut * numCut + 1];
        int center = numCut / 2;
        for (int i = 0; i < numCut; i++)
        {
            for (int j = 0; j < numCut; j++)
            {
                //weightArray[i*numCut + j] = i <= center ? 2.0f - weightRate * (float)i : 2.0f - weightRate * ((float)numCut - (float)i);
                if ((Mathf.Min(i, j) == 0) || Mathf.Max(i, j) == 7)
                {
                    weightArray[i * numCut + j] = 1 + 3.0f * weightRate;
                }
                else if((Mathf.Min(i, j) == 1) || Mathf.Max(i, j) == 6)
                {
                    weightArray[i * numCut + j] = 1 + 2.0f * weightRate;
                }
                else if ((Mathf.Min(i, j) == 2) || Mathf.Max(i, j) == 5)
                {
                    weightArray[i * numCut + j] = 1 + 1.0f * weightRate;
                }
                else
                {
                    weightArray[i * numCut + j] = 1.0f;
                }
                //Debug.Log("i:" + i + "\tj:" + j + "\tweight:" + weightArray[i*numCut + j]);
            }
        }
        script = haveSendImageMethodObject.GetComponent<SocketManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Estimate());
        }
    }

    IEnumerator Estimate()
    {
        List<imageData> imageList = new List<imageData>();
        Texture2D tex2D = image.texture as Texture2D;
        trustPoint maxtPoint = new trustPoint();
        maxtPoint.trustPointStore = 2147483647;
        int n_thNum = 0;
        __width = tex2D.width;
        __height = tex2D.height;
        for (int i = 0; i < numCut; i++)        //serch start position
        {
            for (int j = 0; j < numCut; j++)    //serch start position
            {
                //start
                imageData iData = new imageData();
                int centerX = __width * i / numCut;
                int centerY = __height * j / numCut;

                IEnumerator coroutine = GetImageCoroutine(centerX, centerY, tex2D,iData);
                yield return coroutine;
                iData = (imageData)coroutine.Current;
                iData.position = new Vector3(centerX - (__width / 2), -(centerY - (__height / 2)), 0);
                imageList.Add(iData);
                //Debug.Log(Reliability(i, j, iData.sumBlackPixel));
                if (maxtPoint.trustPointStore > Reliability(i, j, iData.sumBlackPixel))
                {
                    //Debug.Log("\ti:" + i + "\tj:" + j);
                    maxtPoint.trustPointStore = Reliability(i, j, iData.sumBlackPixel);
                    Debug.Log(maxtPoint.trustPointStore);
                    maxtPoint.width = centerX;
                    maxtPoint.height = centerY;
                    this.transform.localPosition = iData.position;
                    n_thNum = i * numCut + j;
                }
            }
            //script.SendImage(SetImage(imageList[n_thNum]));
            //Debug.Log("Image Create");
        }
        script.SendImage(SetImage(imageList[n_thNum]));
        Debug.Log("Image Create");
    }

    IEnumerator GetImageCoroutine(int centerX, int centerY, Texture2D tex2D, imageData ap)
    {
        ap.imagePixel= new byte[window * window];
        ap.sumBlackPixel = 0;
        int num = 0;
        for (int k = centerX - windowSize / 2; k < centerX + windowSize / 2; k += windowMagnification)
        {
            for (int l = centerY - windowSize / 2; l < centerY + windowSize / 2; l += windowMagnification)
            {
                if (k < 0 | l < 0 | __width < k | __height < l)
                {
                    ap.imagePixel[num] = 1;
                }
                else
                {
                    ap.imagePixel[num] = (byte)GetBinary(tex2D.GetPixel(k, l));
                    //Debug.Log(ap.imagePixel[num]);
                }
                ap.sumBlackPixel += 1 - ap.imagePixel[num++];
            }
        }
        //Debug.Log(ap.sumBlackPixel+"\tx;"+centerX+"\ty:"+centerY);
        yield return ap;
    }
    private Texture2D SetImage(imageData iData)
    {
        iData.image = new Texture2D(window, window);
        for(int x = 0; x < iData.image.width; x++)
        {
            for(int y = iData.image.height-1; 0 <= y; y--)
            {
                Color color = iData.imagePixel[x*window+y] == (byte)0 ? Color.black : Color.white;
                iData.image.SetPixel(x, y, color);
            }
        }
        iData.image.Apply();
        return iData.image;
    }
    private float Reliability(int i,int j,int sumBlackPixel)
    {
        return (Mathf.Abs(sumBlackPixel - avePixel)) * weightArray[i*numCut + j];
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
        return s < whitePoint ? 1 : 0;
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
    private float WeightFunction(float binary,float judgePointPos,float size)
    {
        return binary * System.Math.Abs(size - 2 * judgePointPos) ;
    }
}
class trustPoint
{
    private int _width;
    private int _height;
    private float _trustPoint;
    public int width
    {
        get
        {
            return this._width;
        }
        set
        {
            _width= value;
        }
    }
    public int height
    {
        get
        {
            return this._height;
        }
        set
        {
            _height = value;
        }
    }
    public float trustPointStore
    {
        get
        {
            return this._trustPoint;
        }
        set
        {
            _trustPoint = value;
        }
    }
}
class imageData
{
    private int _sumBlackPixel;
    private Vector3 _position;
    private byte[] _imagePixel;
    private Texture2D _image;
    public int sumBlackPixel
    {
        get
        {
            return this._sumBlackPixel;
        }
        set
        {
            _sumBlackPixel = value;
        }
    }
    public Vector3 position
    {
        get
        {
            return this._position;
        }
        set
        {
            _position = value;
        }
    }
    public byte[] imagePixel
    {
        get
        {
            return this._imagePixel;
        }
        set
        {
            _imagePixel = value;
        }
    }
    public Texture2D image
    {
        get
        {
            return this._image;
        }
        set
        {
            _image = value;
        }
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