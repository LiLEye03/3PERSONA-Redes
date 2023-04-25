using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services;
using Unity.Networking.Transport.Relay;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode.Transports.UTP;

public class RelayManager1 : MonoBehaviour
{
    public int maxplayers = 4;
    public TMPro.TextMeshPro joinCodeText;
    void Start()
    {
        Autenticar();
    }
    async void Autenticar() 
    { 
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void CreateGame() 
    {
        Allocation a = await RelayService.Instance.CreateAllocationAsync(maxplayers);
        joinCodeText.text = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);
        // RelayServerData relayserverData = new RelayServerData(a, "dtls");
        // NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData(relayserverData);
        // NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData
        (a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData );
    }
    [ServerRpc]
    void FuedisparadoServerRPC() 
    { 
    
    }
    void Update()
    {
        
    }
}
