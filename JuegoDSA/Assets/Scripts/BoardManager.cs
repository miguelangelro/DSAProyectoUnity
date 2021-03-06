﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Security.Cryptography;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    public GameObject[] ciudadano;
    public GameObject carretera;
    public GameObject moneda;
    public GameObject carreteraVertical;
    public GameObject carreteraHorizontal;
    public GameObject player;
    public GameObject contorno;
    public GameObject plane;
    public GameObject USAFlag;
    public GameObject whiteHouse;
    public GameObject[] cespedTiles;
    public GameObject[] bigben;
    public GameObject[] virus;
    public GameObject backgroundImage;
    public GameObject obras;
    public GameObject señalObras;
    public GameObject btnInventario;
    float xmapa;
    float ymapa;
    private Transform boardHolder;
    private Transform boardHolder2;
    private Transform boardHolder3;
    private Transform boardHolder4;
    private Transform boardHolder5;
    private Transform boardHolder6;
    private Transform boardHolder7;
    private Transform boardHolder8;
    private Transform boardHolder9;
    private Transform boardHolder10;
    private Transform boardHolder11;
    //public int numMapa;

    // MeshRenderer renderBack;

    public void SetupScene(string conjuntoMapa) //paso el string con el diseño del mapa y info num filasxcolumnas y numero de nivel (se guarda en mapa), ejemplo: 25 25 1
    {
        //backgroundImage = GameObject.Find("CanvasPlane");
        //backgroundImage.SetActive(false);
        //renderBack = backgroundImage.GetComponentInChildren<MeshRenderer>();
        //levelText = GameObject.Find("Text");
        //ShowImage();

        string[] filas = conjuntoMapa.Split('\n');
        int xtotal = Convert.ToInt32(filas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(filas[0].Split(' ')[1]);
        // numMapa = Convert.ToInt32(filas[0].Split(' ')[2]); // mas adelante lo usare para saber en que mapa estamos

        int x;
        int y;
        int i = 0;

        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Contorno").transform;
        boardHolder3 = new GameObject("BigBen").transform;
        boardHolder4 = new GameObject("Jugadores").transform;
        boardHolder5 = new GameObject("Virus").transform;
        boardHolder6 = new GameObject("Items").transform;
        boardHolder7 = new GameObject("Avion").transform;
        boardHolder8 = new GameObject("USAFlag").transform;
        boardHolder9 = new GameObject("obras").transform;
        boardHolder10 = new GameObject("señalObras").transform;
        boardHolder11 = new GameObject("inventarioBtn").transform;


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

        //Empieza a pintar el mapa según el tipo de carácter.

        for (y = 0; y < ytotal; y++)
        {
            ymapa = -y + ytotal - 1; // invierto el sentido para poner bien en orden las cosas del mapa.
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

                    case 'A':
                        GameObject avion = Instantiate(plane, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        avion.transform.SetParent(boardHolder7);
                        break;

                    case 'H':
                        GameObject arbol = Instantiate(contorno, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity);
                        arbol.transform.SetParent(boardHolder2);
                        break;
                    case 'F':
                        GameObject USAflag = Instantiate(USAFlag, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        USAflag.transform.SetParent(boardHolder8);
                        break;

                    case 'W':
                        GameObject casaBlanca  = Instantiate(whiteHouse, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        casaBlanca.transform.SetParent(boardHolder6);
                        break;
                    case 's':
                        GameObject obrasLine = Instantiate(obras, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        obrasLine.transform.SetParent(boardHolder9);
                        break;
                    case 'S':
                        GameObject obrasSenal = Instantiate(señalObras, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(carretera, new Vector2(xmapa, ymapa), Quaternion.identity);
                        obrasSenal.transform.SetParent(boardHolder6);
                        break;
                    case 'R':
                        GameObject obrasSenalC = Instantiate(señalObras, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity);
                        obrasSenalC.transform.SetParent(boardHolder6);
                        break;

                    case 'x': //Virus
                        GameObject covid = Instantiate(virus[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity); //Lo pongo sobre cesped (ejemplo)
                        VirusController v = covid.GetComponent<VirusController>();
                        v.SetPosition(xmapa, ymapa);
                        covid.transform.SetParent(boardHolder5);
                        break;

                    case 'X': //Virus2
                        GameObject cepa = Instantiate(virus[1], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity); //Lo pongo sobre la carretera (ejemplo)
                        VirusController vi = cepa.GetComponent<VirusController>();
                        vi.SetPosition(xmapa,ymapa);
                        cepa.transform.SetParent(boardHolder5);
                        break;

                    case 'Y': //Virus2Y
                        GameObject cepaY = Instantiate(virus[2], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity); //Lo pongo sobre la carretera (ejemplo)
                        VirusControllerY viY = cepaY.GetComponent<VirusControllerY>();
                        viY.SetPosition(xmapa, ymapa);
                        cepaY.transform.SetParent(boardHolder5);
                        break;

                    case '!': //Virus3
                        GameObject boss = Instantiate(virus[3], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[1], new Vector2(xmapa, ymapa), Quaternion.identity);
                        BossVirus final = boss.GetComponent<BossVirus>();
                        final.SetPosition(xmapa, ymapa);
                        boss.transform.SetParent(boardHolder5);
                        break;

                    case 'b':
                        GameObject ben = Instantiate(bigben[i], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        i++;
                        ben.transform.SetParent(boardHolder3);
                        if (i == 25)
                            i = 0;
                        break;

                    case 'g':
                        GameObject oro = Instantiate(moneda, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        Coin or = oro.GetComponent<Coin>();
                        or.SetPosition(xmapa, ymapa);
                        oro.transform.SetParent(boardHolder6);
                        break;

                    case 'p':
                        GameObject person = Instantiate(ciudadano[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        MovimientoAleatorio mov = person.GetComponent<MovimientoAleatorio>();
                        mov.SetPosition(xmapa, ymapa);
                        person.transform.SetParent(boardHolder4);
                        break;

                    case '@': //Aqui supongo que el jugador esta de pie en cesped.
                        GameObject jugador = Instantiate(player, new Vector2(xmapa, ymapa), Quaternion.identity);
                        instance = Instantiate(cespedTiles[0], new Vector2(xmapa, ymapa), Quaternion.identity);
                        PlayerMovement jug = jugador.GetComponent<PlayerMovement>();
                        jug.SetPosition(xmapa,ymapa);
                        jugador.transform.SetParent(boardHolder4);
                        break;

                    default: //si hay espacio en blanco coloco cesped del tipo 0 o 1, aleatoriamente.
                        GameObject toInstantiate = cespedTiles[Random.Range(0, cespedTiles.Length)];
                        instance = Instantiate(toInstantiate, new Vector2(xmapa, ymapa), Quaternion.identity);
                        break;
                }

                if (instance != null)
                    instance.transform.SetParent(boardHolder); // asigno el tipo de suelo al BoardHolder
            }
        }

        //HideLevelImage();

    }

}