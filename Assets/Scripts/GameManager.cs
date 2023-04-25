using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
public class GameManager : NetworkBehaviour
{
    public static GameManager instancia;
    public NetworkVariable<uint> score1 = new NetworkVariable<uint>(writePerm: NetworkVariableWritePermission.Owner);
    public NetworkVariable<uint> score2 = new NetworkVariable<uint>(writePerm: NetworkVariableWritePermission.Owner);

    public TMP_Text Puntos1;
    public TMP_Text Puntos2;

    // Start is called before the first frame update
    void Start()
    {
        instancia = this;

    }
     public void Gol1() 
    {
        GolEquipo1ServerRpc();
    }
     public void Gol2()
    {     
        GolEquipo2ServerRpc();
    }
    [ServerRpc]
    public void GolEquipo1ServerRpc()
    {
        Debug.Log(OwnerClientId + "equipo 1 anoto gol");
        score1.Value++;
        NotificaciondeGolClientRpc();
    }
    [ServerRpc]
    public void GolEquipo2ServerRpc()
    {
        Debug.Log(OwnerClientId + "equipo 2 anoto gol");
        score2.Value++;
        NotificaciondeGolClientRpc();
    }
    [ClientRpc]
   public void NotificaciondeGolClientRpc() 
    {
        uiText();
        Debug.Log("anotacion");
    }

   public void uiText() 
    { 
    Puntos1.text=score1.Value.ToString();
    Puntos2.text = score2.Value.ToString();
    }
}
