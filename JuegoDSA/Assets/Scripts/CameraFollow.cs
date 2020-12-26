using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player(Clone)");
    }

    void FixedUpdate() {

        transform.position = new Vector2(player.transform.position.x,player.transform.position.y);
    }
}
