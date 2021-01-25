using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingLine : MonoBehaviour
{
    public PlayerData playerData;
    public Image playerImage;
    public Text playerNameText;
    public Text playerScoreText;
    public Text playerHealthText;

    private void Start()
    {
        UpdateRankingLinea();
    }

    public void UpdateRankingLinea()
    {
        playerImage.sprite = playerData.playerSprite;
        playerNameText.text = playerData.playerName;
        playerScoreText.text = playerData.playerScore.ToString();
        playerHealthText.text = playerData.playerHealth.ToString();
    }
}
