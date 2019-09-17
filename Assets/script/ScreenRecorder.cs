using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenRecorder : MonoBehaviour
{
    public int framerate = 30;
    public int superSize;
    public bool autoRecord = true;
    public GameObject UIobject = null;
    public bool recording;

    public float shootDuring = 0.1f;
    float time = 0;

    int frameCount;

    void Start()
    {
        if (autoRecord) StartRecording();
        
    }

    void StartRecording()
    {
        Time.captureFramerate = framerate;
        frameCount = -1;
        //recording = true;
        System.IO.Directory.CreateDirectory("Capture");
    }

    void Update()
    {
        time += Time.deltaTime;

        if (recording)
        {
            if (time < shootDuring)
                return;

            if (frameCount > 0)
            {
                var name = "capture\\"+frameCount.ToString("0000") + ".png";
                //Application.CaptureScreenshot(name, superSize);
                ScreenCapture.CaptureScreenshot(name, superSize);
                Text text = UIobject.GetComponent<Text>();
                text.text = name;
            }

            frameCount++;

            if (frameCount > 0 && frameCount % 60 == 0)
            {
                Debug.Log((frameCount / 60).ToString() + " seconds elapsed.");
                
            }

            time = 0;
        }
    }

    //void OnGUI()
    //{
    //    if (!recording && GUI.Button(new Rect(0, 0, 200, 50), "Start Recording"))
    //    {
    //        StartRecording();
    //        Debug.Log("Click Game View to stop recording.");
    //    }
    //}
}