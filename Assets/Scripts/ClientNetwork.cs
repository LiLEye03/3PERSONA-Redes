using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Networking;
using Unity.Netcode;
using Unity.Netcode.Components;


namespace Unity.Multiplayer.Samples.Utilities.ClientAuthority
{
    [DisallowMultipleComponent]
    public class ClientNetwork : NetworkTransform
    {

        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}