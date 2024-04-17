using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string playerName;
    public int points;

    public PlayerData(string name)
    {
        playerName = name;
        points = 0;
    }
}

public class LeaderboardManager : MonoBehaviour
{
    public GameObject playerList;
    public GameObject playerScorePrefab;

    private List<PlayerData> players = new List<PlayerData>();

    void Start()
    {
        AddPlayer(PhotonNetwork.LocalPlayer.NickName);
    }

    public void AddPlayer(string playerName)
    {
        if (!players.Exists(player => player.playerName == playerName))
        {
            players.Add(new PlayerData(playerName));
        }
    }

    public void UpdatePlayerPoints(string playerName, int pointsToAdd)
    {
        PlayerData player = players.Find(p => p.playerName == playerName);
        if (player != null)
        {
            player.points += pointsToAdd;
        }
    }

    public void DisplayLeaderboard()
    {
        players.Sort((x, y) => y.points.CompareTo(x.points));

        for (int i = 0; i < players.Count; i++)
        {
            GameObject scoreUI = Instantiate(playerScorePrefab, playerList.transform);
            SetUIPrefab(scoreUI, i + 1, players[i].playerName, players[i].points);
        }
    }

    public void SetUIPrefab(GameObject prefab, int rank, string playerName, int points)
    {
        prefab.GetComponent<PlayerScoreUI>().SetScore(rank, playerName, points);
    }
}
