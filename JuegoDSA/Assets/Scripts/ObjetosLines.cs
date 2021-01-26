﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosLines : MonoBehaviour
{
    public Text MascCantidad;
    public Text PocionCantidad;
    public Text RegeneradorCantidad;
    public Text BolsaBasuraCantidad;
    public Text PCRCantidad;
    PlayerMovement jug;
    public void Start()
    {
        jug = GameObject.Find("Player(Clone)").GetComponent<PlayerMovement>();
        //UpdateRankingLinea();
    }

    public void UpdateRankingLinea()
    {
        
        GameManager.instance.inventario.SetActive(true);
        MascCantidad = GameObject.Find("CantidadMasc").GetComponent<Text>();
        PocionCantidad = GameObject.Find("CantidadPocion").GetComponent<Text>();
        RegeneradorCantidad = GameObject.Find("CantidadReg").GetComponent<Text>();
        BolsaBasuraCantidad = GameObject.Find("CantidadBas").GetComponent<Text>();
        PCRCantidad = GameObject.Find("CantidadPCR").GetComponent<Text>();
        //EN TEORIA AQUI SE DEBE PONER EN LA CASILLA DEL INVENTARIO
        MascCantidad.text = jug.mascarilla;
        PocionCantidad.text = jug.pocion;
        RegeneradorCantidad.text = jug.regeneron;
        BolsaBasuraCantidad.text = jug.bolsa;
        PCRCantidad.text = jug.pcr;
    }

    public void CloseInventario()
    {
        GameManager.instance.inventario.SetActive(false);
    }
}
