using System.Collections;
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
            minPosition.x = 5f;
            maxPosition.x = 19.2f;
            minPosition.y = 2.3f;
            maxPosition.y = 2.6f;

        }
        if (GameManager.instance.level == 2)
        {
            minPosition.x = 4.9f;
            maxPosition.x = 19.1f;
            minPosition.y = 3.49f;
            maxPosition.y = 20.54f;

        }
        if (GameManager.instance.level == 1)
        {
            minPosition.x = 4.84f;
            maxPosition.x = 44.14f;
            minPosition.y = 3.45f;
            maxPosition.y = 45.54f;

        }

    }
}
