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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gameObject.SetActive(false); //de esta manera el virus desaparce pero no se destruye. Esto es intersante y se podria hacer
        // que el virus2 (más dificil) una vez choquemos, en vez de irse, pasados x segundos vuelva a aparecer
        Destroy(gameObject); //este sí lo destruye por completo.


    }

    void Start()
    {
        transform.position = new Vector2(this.posx, this.posy);//Se inicia en la posicion que ocupa el carácter
        startPos = transform.position;
    }

    void Update()
    {
        Vector2 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * velocidad);
        transform.position = v;
    }

    public void SetPosition(float x, float y)
    {
        this.posx = x;
        this.posy = y;

    }

}
