using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAleatorio : MonoBehaviour
{

    public float speed; //marca la velocidad de movimiento
    private float waitTime; //el tiempo que estara quieto una vez llegue al spot
    public float startWaitTime;

    public Transform moveSpot; //seran los sitios donde se moverá
    public float minX;
    public float maxX;
    public float minY;
    public float maxY; //marcan los limites de donde se  movera

    float posx;
    float posy;

    public static MovimientoAleatorio instance = null;


    // Start is called before the first frame update
    void Start()
    {

        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
    }

    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

        // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,moveSpot.position) < 0.2f){
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;

            } else
            {
                waitTime -= Time.deltaTime;

            }

        }
        
    }

    public void StopMoving()
    {
        speed = 0;
    }

    public void StartMoving()
    {
        instance.speed = 1.5f;
    }

    public void SetPosition(float x, float y)
    {
        this.posx = x;
        this.posy = y;

    }
}
