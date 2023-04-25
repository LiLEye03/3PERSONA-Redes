using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
using ParrelSync.NonCore;

public class PlayerMovement : NetworkBehaviour
{
    public float playerspeed = 2;

    private Rigidbody rigidbody;

    public Transform ballprefab;

    public float bulletspeed=999;

    void Start()
    {
        if (IsServer)
        {
            Debug.Log("Este es el server");
        }
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    public override void OnNetworkSpawn()
    {
        Debug.Log("OnNetworkSpawn");
    }
    [ServerRpc]
    public void GolEquipo1ServerRpc()
    {
        Debug.Log(OwnerClientId + "equipo 1 anoto gol");
        //score1.Value ++;
        NotificaciondeGolClientRpc();
    }
    [ServerRpc]
    public void GolEquipo2ServerRpc()
    {
        Debug.Log(OwnerClientId + "equipo 2 anoto gol");
       // score2.Value++;
        NotificaciondeGolClientRpc();
    }
    [ClientRpc]
    public void NotificaciondeGolClientRpc()
    {
        Debug.Log(OwnerClientId + "anoto gol");

    }
    void Update()
    {
        if (IsOwner)
        {
            Vector3 mover = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                mover.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                mover.x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                mover.z = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                mover.z = -1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (IsOwner)
                {
                  var ballinstance= Instantiate(ballprefab);
                  ballinstance.transform.position = transform.position + transform.forward;
                    ballinstance.GetComponent<NetworkObject>().Spawn();

                    ballinstance.GetComponent<Rigidbody>().AddForce(transform.forward*bulletspeed);
                }             
            }
            //transform.position += mover * playerspeed * Time.deltaTime;
            rigidbody.AddForce(10 * mover * playerspeed * Time.deltaTime);
        }
    }
    public void Disparado() 
    {
     FueDisparadoServerRpc();
    }

    [ServerRpc]

    public void FueDisparadoServerRpc(ServerRpcParams serverRpcParams = default) 
    { 
    
    }

}
