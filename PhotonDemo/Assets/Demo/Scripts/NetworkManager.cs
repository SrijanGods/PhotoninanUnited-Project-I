using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManager : MonoBehaviourPun
{
    [Header("UI Elements")]
    public GameObject connectBtn;
    public GameObject lobby;
    public GameObject battleList;

    [Header("Team Management")]
    public byte maxPlayers;
    public bool isMasterClient;

    private bool isConnecting;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        ConnectToMaster();
    }

    public void ConnectToMaster()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connected To Master");
        }

        isConnecting = true;
    }

    #region OnClick

    public void OnClick_JoinLobby()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Joined Lobby");

        connectBtn.SetActive(false);
        lobby.SetActive(true);
    }

    public void OnClick_CreateRoom()
    {
        if (isMasterClient)
        {

        }
    }

    #endregion OnClick_JoinLobby()


    void Update()
    {

    }

    public void CreateRoom(string roomName, string lobbyName = "MyLobby", LobbyType lobbyType = LobbyType.SqlLobby)
    {

    }

    RoomOptions RoomProperties()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.CustomRoomPropertiesForLobby = new string[] { "Team Modes" };
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "Team Mode", "DM" }, { "Team Mode", "TDM" }, { "Team Mode", "CTF" } };

        roomOptions.MaxPlayers = maxPlayers;
        roomOptions.PlayerTtl = 10;
        roomOptions.IsVisible = true;
        roomOptions.CleanupCacheOnLeave = true;
        roomOptions.IsOpen = true;
        roomOptions.PublishUserId = true;

        return roomOptions;
        
    }
    
}

