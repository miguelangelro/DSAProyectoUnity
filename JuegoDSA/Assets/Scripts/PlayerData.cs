using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    //ESTA ES LA CLASE QUE COGERA LOS DATOS PARA PASARLOS AL UI DEL RANKING

    public string playerName;
    public Sprite playerSprite;

    public int playerScore;
    public int playerHealth;

}
