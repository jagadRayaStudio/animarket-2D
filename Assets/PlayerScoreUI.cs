using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    public static PlayerScoreUI instance;
    public TMP_Text RankText;
    public TMP_Text playerName;
    public TMP_Text ScoreText;
    public void Awake()
    {
        instance = this;
    }

    public void SetScore(int rank, string name, int score)
    {
        RankText.text = rank.ToString();
        playerName.text = name;
        ScoreText.text = score.ToString();
    }
}
