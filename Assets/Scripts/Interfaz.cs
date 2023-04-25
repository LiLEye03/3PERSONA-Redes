using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
public class Interfaz : MonoBehaviour
{
    public Button server, host, client;
    void Start()
    {
        server.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
    void Update()
    {
        //holaaaa
        //el chava es del otro bando 
    }
}
