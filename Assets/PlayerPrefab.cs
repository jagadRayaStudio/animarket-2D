using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerPrefab : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;
    public Image playerIcon;
    public Sprite[] icons;

    Player player;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;

        if (!playerProperties.ContainsKey("playerIcon"))
        {
            playerProperties.Add("playerIcon", 0); // Default icon index
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);

        UpdatePlayerPrefab(player);
    }

    public void OnClickLeftButton()
    {
        if (player != null && player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            if ((int)playerProperties["playerIcon"] == 0)
            {
                playerProperties["playerIcon"] = icons.Length - 1;
            }
            else
            {
                playerProperties["playerIcon"] = (int)playerProperties["playerIcon"] - 1;
            }
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }
    }

    public void OnClickRightButton()
    {
        if (player != null && player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            if ((int)playerProperties["playerIcon"] == icons.Length - 1)
            {
                playerProperties["playerIcon"] = 0;
            }
            else
            {
                playerProperties["playerIcon"] = (int)playerProperties["playerIcon"] + 1;
            }
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable playerProperties)
    {
        if (targetPlayer.ActorNumber == player.ActorNumber)
        {
            UpdatePlayerPrefab(targetPlayer);
        }
    }

    void UpdatePlayerPrefab(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerIcon"))
        {
            playerIcon.sprite = icons[(int)player.CustomProperties["playerIcon"]];
            playerProperties["playerIcon"] = (int)player.CustomProperties["playerIcon"];
        }
        else
        {
            playerProperties["playerIcon"] = 0;
        }
    }
}
