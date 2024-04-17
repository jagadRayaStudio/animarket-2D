using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;

    public GameObject playBtn;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeUpdates = 1.5f;
    float nextUpdate;

    public List<PlayerPrefab> playerPrefabList = new List<PlayerPrefab>();
    public PlayerPrefab playerPrefab;
    public Transform playerPrefabParent;

    public LobbyUITween lobbyUITween;



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
        else
        {
            lobbyUITween.OpenNotifBox();
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyUITween.OpenRoomPanel();
        roomName.text = "Kamu Berada di Kelas: " + PhotonNetwork.CurrentRoom.Name;
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
        lobbyUITween.CloseRoomPanel();
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

            LeanTween.scale(newPlayerPrefab.gameObject, new Vector2(1.75f, 1.75f), 0.4f).setEase(LeanTweenType.easeInOutQuart);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            playBtn.SetActive(true);
            playBtn.LeanScale(Vector2.one, 0.2f).setEaseInOutQuart();
        }
        else
        {
            playBtn.LeanScale(Vector2.zero, 0.2f).setEaseInBack();
        }
    }
    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("2 Game");
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LocalPlayer.SetCustomProperties(null);
        SceneManager.LoadScene("0 Main Menu");
    }

}
