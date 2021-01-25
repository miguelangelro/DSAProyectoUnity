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
    public Joystick joystick;

    public int maxHealth = 100; //vida maxima del player
    public int currentHealth = 100;
    public float restartLevelDelay = 1f;

    private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
    public LayerMask blockingLayer;//Layer on which collision will be checked.
    public Animator transition;
    public float transitionTime = 3f;
    public float tiempoEsperaAvion = 5f; //Tiempo que estara la pantalla con el avion.
    public AudioClip playerDañado;
    public AudioClip muerte;
   // public GameObject Canvas;
    public bool girado = false;

    public Animator animatorDialog;

    public GameObject ciudadano;
    public PlayerMovement jugador;
    public static GameManager instance = null;

    public Dialogue dialog;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        ciudadano = GameObject.Find("Ciudadano");
        jugador = GameObject.Find("Player(Clone)").GetComponent<PlayerMovement>();
        jugador.setJoystick(GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>());
        
        if (GameManager.instance.firstLoad)
        {
            currentHealth = maxHealth;
            GameManager.instance.firstLoad = false;
        } else
        {
            currentHealth = GameManager.instance.currentHealth;
        }
        
        //healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector2(this.posx, this.posy);//para iniciar en la posicion que queramos
        //CanvasPlane = GameObject.Find("CanvasImagePlane");
        //renderBack = BackgroundImage.GetComponentInChildren<MeshRenderer>();
        //CanvasPlane = GameObject.Find("CanvasPlane").GetComponent<Canvas>();
        //CanvasPlane = GetComponent<Canvas>();
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySingle(playerDañado);
        SoundManager.instance.PlaySingle(playerDañado);
        currentHealth -= damage;
        setCurrentHealth(currentHealth);

        //healthBar.SetHealth(currentHealth);

        StartCoroutine(DamageAnimation());

        if (currentHealth <= 0)
        {
            Debug.Log("pasa por aqui");
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
        //Canvas = GameObject.Find("Canvas");
        //Canvas.SetActive(false);
    }


    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

                movement.x = Input.GetAxisRaw("Horizontal");

                movement.y= Input.GetAxisRaw("Vertical");

        #elif UNITY_ANDROID
                movement.x = joystick.Horizontal;

                movement.y = joystick.Vertical;

        #endif 

        

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {

            Move(movement.x, movement.y);
        }

 
        

        

        if (MovimientoAleatorio.instance != null)
        {
            if (Vector2.Distance(transform.position, MovimientoAleatorio.instance.transform.position) < 0.5f)
            {
                MovimientoAleatorio.instance.StopMoving();
                DialogManager.instance.animatorDialog.SetBool("HelpOpened", true);
            }

            else if (DialogManager.instance.animatorDialog != null)
            {
                MovimientoAleatorio.instance.StartMoving();
                DialogManager.instance.animatorDialog.SetBool("HelpOpened", false);
                DialogManager.instance.animator.SetBool("isOpened", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Plane")
        {
            if(GameManager.instance.level ==2)
            {
                LoadLevel();
                Invoke("Restart", restartLevelDelay);
            }
            else
            {
                GameManager.instance.CanvasImagePlane.SetActive(true);
                GameManager.instance.currentHealth = currentHealth;
                new WaitForSeconds(tiempoEsperaAvion);
                LoadLevel();
                Invoke("Restart", restartLevelDelay);
                //enabled = false;
            }
        }
        else if (other.tag == "ciudadano")
        {
            MovimientoAleatorio.instance.StopMoving();
            DialogManager.instance.animatorDialog.SetBool("HelpOpened", true);
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

            }
            else
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

    public void setCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public void setJoystick(Joystick controller)
    {
        this.joystick = controller;
    }

    public float getCurrentHealth()
    {
        return this.currentHealth;
    }
}
