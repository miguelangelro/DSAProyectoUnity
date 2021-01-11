﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float restartLevelDelay = 1f;

    private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
    public LayerMask blockingLayer;//Layer on which collision will be checked.
    public Animator transition;
    public float transitionTime = 3f;
    public float tiempoEsperaAvion = 5f; //Tiempo que estara la pantalla con el avion.
    public AudioClip playerDañado;
    public AudioClip muerte;
    public GameObject Canvas;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector2(this.posx, this.posy);//para iniciar en la posicion que queramos
    }

   

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySingle(playerDañado);
        SoundManager.instance.PlaySingle(playerDañado);
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        SoundManager.instance.PlaySingle(muerte);
        SoundManager.instance.musicSource.Stop();
        Debug.Log("Has muerto, falta poner una animacion de morision kisde");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GameManager.instance.gameOver.SetActive(true);
        Canvas = GameObject.Find("Canvas");
        Canvas.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y= Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {

            Move(movement.x, movement.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Plane")
        {
            GameManager.instance.CanvasImagePlane.SetActive(true);
            new WaitForSeconds(tiempoEsperaAvion);
            LoadLevel();
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    public void SetPosition(float x, float y)
    {
        this.posx = x;
        this.posy = y;

    }

    void Move(float xDir, float yDir)
    {
        RaycastHit2D hit;
        Vector2 start = transform.position;
        Vector2 dir = new Vector2(xDir, yDir).normalized; // que tenga siempre magnitud 1
        dir = dir * 0.5f; // lo escalo
        Vector2 end = start + dir;

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;


        if (hit.transform == null)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }else
        {
            Debug.DrawLine(start, end);
            Debug.Log("COLISION");
        }


    }


    public float getPosX()
    {

        return this.posx;
    }

    public float getPosY()
    {
        return this.posy;
    }
}
