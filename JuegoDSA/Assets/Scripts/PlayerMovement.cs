using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector3 startPos;
    Vector2 movement;
    public Animator animator;
    float posx;
    float posy;

    void Start()
    {

        transform.position = new Vector2(this.posx, this.posy);//para iniciar en la posicion que queramos
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void SetPosition(float x, float y) {
        this.posx = x;
        this.posy = y;

    }

    public float getPosX() {

        return this.posx;
    }

    public float getPosY() {
        return this.posy;
    }
}
