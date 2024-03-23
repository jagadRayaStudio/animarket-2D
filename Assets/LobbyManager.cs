using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeUpdates = 1.5f;
    float nextUpdate;

    public List<PlayerPrefab> playerPrefabList = new List<PlayerPrefab>();
    public PlayerPrefab playerPrefab;
    public Transform playerPrefabParent;

    public void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInput.text,
                new RoomOptions()
                { MaxPlayers = 5, BroadcastPropsChangeToAll = true});
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdate)
        {
            UpdateRoomList(roomList);
            nextUpdate = Time.time + timeUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach (PlayerPrefab player in playerPrefabList)
        {
            Destroy(player.gameObject);
        }
        playerPrefabList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerPrefab newPlayerPrefab = Instantiate(playerPrefab, playerPrefabParent);
            newPlayerPrefab.SetPlayerInfo(player.Value);
            playerPrefabList.Add(newPlayerPrefab);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player " + newPlayer.ActorNumber + " Entered!");
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

}
