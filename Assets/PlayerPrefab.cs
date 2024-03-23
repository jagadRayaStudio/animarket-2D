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

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    public Image playerIcon;
    public Sprite[] icons;

    Player player;

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerPrefab(player);
    }

    public void OnClickLeftButton()
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

    public void OnClickRightButton()
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

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable playerProperties)
    {
        if (player == targetPlayer)
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
