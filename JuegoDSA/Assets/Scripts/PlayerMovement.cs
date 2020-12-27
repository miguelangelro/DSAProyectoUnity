using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector3 startPos;
    Vector2 movement;
    public Animator animator;
    float posx;
    float posy;

    public int maxHealth = 100; //vida maxima del player
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector2(this.posx, this.posy);//para iniciar en la posicion que queramos
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Has muerto, falta poner una animacion de morision kisde");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;


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
