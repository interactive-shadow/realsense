using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using WebSocketSharp;
using UniRx;
using UnityEditor.Experimental.UIElements;

using System.IO;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private string _serverAddress = "localhost";
    [SerializeField] private int _port = 8080;

    [SerializeField] private int maxSendLen = 2000;

    [SerializeField] private Generator generator;
    
    [SerializeField] private string path;
    
    private SyncPhase _nowPhase;
    
    private WebSocket ws;
    
    public enum SyncPhase {
        Idling,
        Syncing
    }
    
    void Awake()
    {
        _nowPhase = SyncPhase.Idling;
        
        var ca = "ws://" + _serverAddress + ":" + _port.ToString();
        Debug.Log("Connect to " + ca);
        ws = new WebSocket(ca);

        //Add Events
        //On catch message event
        ws.OnMessage += (object sender, MessageEventArgs e) => {
            //print("OnMessage");
            //print(e.Data);
            //print(e.Data.GetType());
            OnGetMessage(e.Data);
        };

        //On error event
        ws.OnError += (sender, e) => {
            Debug.Log("WebSocket Error Message: " + e.Message);
            _nowPhase = SyncPhase.Idling;
        };

        //On WebSocket close event
        ws.OnClose += (sender, e) => {
            Debug.Log("Disconnected Server");
        };

        ws.Connect();
        
        _nowPhase = SyncPhase.Syncing;
    }

    void OnApplicationQuit()
    {
        Debug.Log("やめます");
        ws.Close();
    }

    public void SendImage(byte[] image)
    {
        for(int i = 0; i < image.Length; i++)
        {
            image[i] = image[i] == (byte)0 ? (byte)'0' : (byte)'1';
        }

        if (_nowPhase == SyncPhase.Syncing) {
            //Debug.Log("Send:" + image.Length + ":" + Time.realtimeSinceStartup);
            //ws.Send(image);

            int imageLen = image.Length;
            int index = 0;
            while((index + 1) * maxSendLen < imageLen)
            {
                byte[] sendData = new byte[maxSendLen];
                Array.Copy(image, index * maxSendLen, sendData, 0, maxSendLen);
                Debug.Log("send:" + sendData.Length);
                //sendData[0] = (byte)index.ToString()[0];
                ws.Send(sendData);
                index++;
            }
            int tmpLen = imageLen - index * maxSendLen;
            byte[] sd = new byte[tmpLen];
            Array.Copy(image, index * maxSendLen, sd, 0, tmpLen);
            Debug.Log("send:" + sd.Length);
            ws.Send(sd);
        }
    }

    void OnGetMessage(string message)
    {
        //Debug.Log( "Get:" + message);
        int result;
        if (int.TryParse(message, out result))
        {
            Debug.Log("Message Get:" + result);
            //generator.generateAnimal(result);
            test(result);
        }
        else
        {
            Debug.Log(message);
            //Debug.Log("messageがintにparseできません。");
        }
    }

    void test(int num)
    {
        Debug.Log("test:" + num);
        generator.testes(num);
        //generator.generateAnimal(num);


    }

    public void SendImage(Texture2D img)
    {
        var png = img.EncodeToPNG();
        File.WriteAllBytes( path, png );
        ws.Send(path);
    }

}
