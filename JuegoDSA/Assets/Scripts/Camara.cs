﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
    
{
    public Transform target;
    public GameObject Player;

    public float smoothing;

    
    public Vector2 maxPosition;
    public Vector2 minPosition;


    void Start()

    {

        Player = GameObject.Find("Player(Clone)");

        target = Player.transform;

    }

    void FixedUpdate()

    {

        if (transform.position != target.position)

        {

            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

        }

        if (GameManager.instance.level == 3)
        {
            minPosition.x = 4.6f;
            maxPosition.x = 19.7f;
            minPosition.y = 2.5f;
            maxPosition.y = 2.6f;

        }

        if (GameManager.instance.level == 2)
        {
            minPosition.x = 5.1f;
            maxPosition.x = 43.74f;
            minPosition.y = 3f;
            maxPosition.y = 31f;

        }

        if (GameManager.instance.level == 1)
        {
            minPosition.x = 5.1f;
            maxPosition.x = 43.74f;
            minPosition.y = 3f;
            maxPosition.y = 31f;

        }

    }
}
