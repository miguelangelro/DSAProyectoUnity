using System.Collections;
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

    public Animator transition;
    public float transitionTime = 1f;

    //public GameObject CanvasPlane;
    //public Canvas CanvasPlane;
    //MeshRenderer renderBack;
    public float tiempoEsperaAvion = 1f; //Tiempo que estara la pantalla con el avion.

    //public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector2(this.posx, this.posy);//para iniciar en la posicion que queramos
        //CanvasPlane = GameObject.Find("CanvasImagePlane");
        //renderBack = BackgroundImage.GetComponentInChildren<MeshRenderer>();
        //CanvasPlane = GameObject.Find("CanvasPlane").GetComponent<Canvas>();
        //CanvasPlane = GetComponent<Canvas>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Plane")
        {
            LoadLevel();
            Invoke("Restart", restartLevelDelay);

        }
    }
    //private void ShowImage()
    //{
    //    //BackgroundImage = GameObject.Find("CanvasPlane");
    //    //levelText = GameObject.Find("Text");
    //    BackgroundImage.SetActive(true);

    //    new WaitForSeconds(1f);
    //    HideLevelImage();
    //}

    //private void HideLevelImage()
    //{
    //    //backgroundImage = GameObject.Find("CanvasPlane");
    //    BackgroundImage.SetActive(false);
    //}

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
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
