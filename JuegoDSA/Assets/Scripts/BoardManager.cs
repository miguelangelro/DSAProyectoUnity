using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    public GameObject carretera;
    public GameObject carreteraVertical;
    public GameObject carreteraHorizontal;
    public GameObject player;
    public GameObject contorno;
    public GameObject[] cespedTiles;
    float xmapa;
    float ymapa;
    private Transform boardHolder;
    private Transform boardHolder2;
    //public int numMapa;


    public void SetupScene(string conjuntoMapa) //paso el string con el diseño del mapa y info num filasxcolumnas y numero de nivel (se guarda en mapa), ejemplo: 25 25 1
    {
        string[] filas = conjuntoMapa.Split('\n');
        int xtotal = Convert.ToInt32(filas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(filas[0].Split(' ')[1]);
       // numMapa = Convert.ToInt32(filas[0].Split(' ')[2]); // mas adelante lo usare para saber en que mapa estamos

        int x;
        int y;

        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Contorno").transform;

        //Ponemos una pared o el objeto que escojamos en el contorno del mapa (Lo mismo que los outerwalls)

        for (x = -1; x < xtotal + 1; x++)
        {
            GameObject outerwall = Instantiate(contorno, new Vector2(x, -1), Quaternion.identity);
            outerwall.transform.SetParent(boardHolder2);
        }

        for (x = -1; x < xtotal + 1; x++)
        {
            GameObject outerwall = Instantiate(contorno, new Vector2(x, ytotal), Quaternion.identity);
            outerwall.transform.SetParent(boardHolder2);
        }

        for (y = -1; y < ytotal + 1; y++)
        {
            GameObject outerwall = Instantiate(contorno, new Vector2(-1, y), Quaternion.identity);
            outerwall.transform.SetParent(boardHolder2);
        }

        for (y = -1; y < ytotal + 1; y++)
        {
            GameObject outerwall = Instantiate(contorno, new Vector2(xtotal, y), Quaternion.identity);
            outerwall.transform.SetParent(boardHolder2);
        }


        for (y = 0; y < ytotal; y++)
        {
            ymapa = -y + ytotal - 1; // invierto el sentido para poner bien en orden en el grid las cosas del mapa.
            string linea = filas[y + 1];

            for (x = 0; x < xtotal; x++)
            {
                xmapa = x; // las x no se invierten pues ya muestran el orden correcto.
                char[] charArr = linea.ToCharArray();
                char c = charArr[x];// miro que caracter hay en esa posicion.

                GameObject instance = null; //creo instancia para el suelo/cesped/carretera/acera ==> BoardHolder

                switch (c)
                {
                    case 'c':
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        break;

                    case 'v':
                        instance = Instantiate(carreteraVertical, new Vector2(xmapa, ymapa), Quaternion.identity);
                        break;

                    case 'h':
                        instance = Instantiate(carreteraHorizontal, new Vector2(xmapa, ymapa), Quaternion.identity);
                        break;

                    case 'a':
                        instance = Instantiate(acera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        break;

                    default: //si hay espacio en blanco coloco cesped del tipo 0 o 1, aleatoriamente.
                        GameObject toInstantiate = cespedTiles[Random.Range(0, cespedTiles.Length)];
                        instance = Instantiate(toInstantiate, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;
                }

                if (instance != null)
                    instance.transform.SetParent(boardHolder); // asigno el tipo de suelo al BoardHolder
            }
        }

    }

      
   

}
