using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{

    public List<PlayerData> playerDatas = new List<PlayerData>();
    public RankingLine[] panelLines;
 
    private void Start()
    {
        CalHigestScore();
        Debug.Log(CalHigestScore());
    }
    private void Update()
    {
    }

    public void SortScoreButton()
    {
        playerDatas.Sort(SortByScore);
        UpdateRank();
    }
    public void SortHealthButton()
    {
        playerDatas.Sort(SortByHealth);
        UpdateRank();
    }
    private string CalHigestScore()
    {
        int highestScore = 0;//The record in this game
        string topName= "";
        for (int i = 0; i<playerDatas.Count;i++)
        {
            if(playerDatas[i].playerScore>highestScore)//si la puntuacion de algun jugador es mayor que el de la partida
            {
                highestScore = playerDatas[i].playerScore;
                topName = playerDatas[i].playerName;
            }
        }

        return topName;
    }

    private int SortByHealth(PlayerData playerA, PlayerData playerB)
    {
        return playerB.playerHealth.CompareTo(playerA.playerHealth);
    }
    private int SortByScore(PlayerData playerA, PlayerData playerB)
    {
        return playerB.playerScore.CompareTo(playerA.playerScore);
    }

    private void UpdateRank()
    {
        for(int i=0;i<playerDatas.Count;i++)
        {
            panelLines[i].playerData = playerDatas[i];
            panelLines[i].UpdateRankingLinea();
        }
    }

}
