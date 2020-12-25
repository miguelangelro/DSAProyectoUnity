using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void FixedUpdate() {

        transform.position = new Vector2(player.position.x,player.position.y);
    }
}
