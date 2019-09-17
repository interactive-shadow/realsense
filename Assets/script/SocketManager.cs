using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;
using UniRx;
using UnityEditor.Experimental.UIElements;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private string _serverAddress = "localhost";
    [SerializeField] private int _port = 8080;

    [SerializeField] private Generator generator;
    
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
            print(e.Data);
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
        ws.Close();
    }

    public void SendImage(byte[] image)
    {
        if (_nowPhase == SyncPhase.Syncing) {
            Debug.Log("Send:" + image.Length + ":" + Time.realtimeSinceStartup);
            ws.Send(image);
        }
    }

    void OnGetMessage(string message)
    {
        //Debug.Log( "Get:" + message);
        int result;
        if (int.TryParse(message, out result))
        {
            generator.generateAnimal(result);
        }
        else
        {
            Debug.Log("messageがintにparseできません。");
        }
    }
}
