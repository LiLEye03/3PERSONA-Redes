using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class PlayerControls : NetworkBehaviour
{
    private NetworkVariable<Vector3> playerpos = new(writePerm: NetworkVariableWritePermission.Owner);

    private NetworkVariable<Quaternion> playerrot = new(writePerm: NetworkVariableWritePermission.Owner);

    public NetworkVariable<Playerdata> playdata = new(writePerm: NetworkVariableWritePermission.Owner);
    public struct Playerdata: INetworkSerializable  
    { 
        public Vector3 Posi
        {
            get => new Vector3(_x, _y, _z);
            set
            {
                _x = value.x;
                _y = value.y;
                _z = value.z;
            }
        }
             public Vector3 Rot
        {
            get => new Vector3(0, _yrot, 0);
            set
            {
                _x = 0;
                _yrot = value.y;
                _z = 0;
            }
        }
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _x);
            serializer.SerializeValue(ref _y);
            serializer.SerializeValue(ref _z);
            serializer.SerializeValue(ref _yrot);
        }
        float _x, _y, _z;
        float _yrot;
    }

    void Update()
    {
        if (IsOwner) 
       { 
            playerpos.Value = transform.position;
        
            playerrot.Value = transform.rotation;
       }
        else 
        { 
            
        }
    }
}
