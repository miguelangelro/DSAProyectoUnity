using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    private Vector2 startPos;

    float posx;
    float posy;

    void Start()
    {
        transform.position = new Vector2(this.posx, this.posy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
            Destroy(gameObject);
        }
    }

    public void SetPosition(float x, float y)
    {
        this.posx = x;
        this.posy = y;

    }

}
