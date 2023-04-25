using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

public class ManagerLobbyParcial : MonoBehaviour
{
   
    void Start()
    {
        Autenticar();
    }
    async void Autenticar(){

       await UnityServices.InitializeAsync();
       await AuthenticationService.Instance.SignInAnonymouslyAsync();
       Debug.Log("Signed in " +  AuthenticationService.Instance.PlayerId);
    }

    public async void  CreateLobby(){

            //TODO hacer try catch almacenar lobby, almancenar nombres de jugador
        Unity.Services.Lobbies.Models.Lobby lobby = await LobbyService.Instance.CreateLobbyAsync("Lobby1",4);

        Debug.Log("LObby creado" + lobby +"id #"+ lobby.Id+ "lobbycode" +  lobby.LobbyCode);
    
    }


    public async void JoinLobby(string LobbyCode){

        await Lobbies.Instance.JoinLobbyByCodeAsync(LobbyCode);
        Debug.Log("nos unimos a looby");


    }
public async void QuickJoin(){


            await Lobbies.Instance.QuickJoinLobbyAsync();
             Debug.Log("nos unimos a looby RAPIDO");
}


public async void ListarLobbies(){


    QueryLobbiesOptions queryLobbiesOptions= new QueryLobbiesOptions{
        Count=25,
        Filters = new List<QueryFilter>{
            new QueryFilter(QueryFilter.FieldOptions.AvailableSlots,"1",QueryFilter.OpOptions.GE)
        }//,
        //Order = new List<QueryOrder>....
    };
            await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);

}
    


}
