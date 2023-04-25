using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;
using TMPro;
using Unity.Services.Relay;

public class NetWorkManager : NetworkManager
{
    public static NetWorkManager interfaz;
   [SerializeField] private Button server;
   [SerializeField] private Button host;
   [SerializeField] private Button client;
    public string ip = "";
    public NetWorkManager net;
    public TMP_InputField iptex;
    public RelayManager relays;

    void Start()
    {
        interfaz = this;
        relays = GetComponent <RelayManager> ();

        server.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });

        host.onClick.AddListener(() =>
        {
            //NetworkManager.Singleton.StartHost();
            relays.CreateGame();
        });

        client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
    void Update()
    {

    }
    public void UpdateIP()
    {
        ip = iptex.text;
        NetWorkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ip.ToString();
    }
    public void UpdateRelayCode() 
    { 
    
    }
}