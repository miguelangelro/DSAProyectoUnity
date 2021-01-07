using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    // Start is called before the first frame update

    public float delta = 1.5f;
    public float velocidad = 2.0f;
    private Vector2 startPos;
    float posx;
    float posy;
    public bool dañado=false;

    public Animator animator;

    public Transform attackPoint; //referencia el punto de ataque
    public float rangoAtaque = 0.5f; //rango del ataque
    public LayerMask playerLayers; //para saber a quien ataca (en principio solo al jugador, he creado un layer player pero tal vez habra que poner mas como por ejemplo ciudadanos)

    public int attackDamage = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gameObject.SetActive(false); //de esta manera el virus desaparce pero no se destruye. Esto es intersante y se podria hacer
        // que el virus2 (más dificil) una vez choquemos, en vez de irse, pasados x segundos vuelva a aparecer
        Ataque();
        Destroy(gameObject,0.5f); //este sí lo destruye por completo. el 0.5f es el delay. Aprovechamos este delay para que el virus haga la animacion de atacar

        //Ataque();

    }

    void Ataque()
    {
        animator.SetTrigger("Ataque");

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, rangoAtaque,playerLayers); //crea un circulo del punto que hemos dicho en attackpoint con el radio que le hemos dicho y colecta todos los objetos que colisiona en el.

        foreach (Collider2D player in hit) // para todos los jugadors dañalos
        {
            
                player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
   
        
        }
        

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) //en caso que el attack point no sea asigando
            return;
        Gizmos.DrawWireSphere(attackPoint.position, rangoAtaque); //dibuja una esfera para poder ver el radio del hit


    }

    void Start()
    {
        transform.position = new Vector2(this.posx, this.posy);//Se inicia en la posicion que ocupa el carácter
        startPos = transform.position;
    }

    void Update()
    {
        Vector2 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * velocidad); // hace un efecto de movimiento mas fluido con la funcion sin
        transform.position = v;
    }

    public void SetPosition(float x, float y)
    {
        this.posx = x;
        this.posy = y;

    }

}
