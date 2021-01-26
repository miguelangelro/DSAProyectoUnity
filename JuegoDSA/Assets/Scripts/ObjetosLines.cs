using System.Collections;
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

    public void Start()
    {
        
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
        MascCantidad.text = "1";
        PocionCantidad.text = "1";
        RegeneradorCantidad.text = "0";
        BolsaBasuraCantidad.text = "0";
        PCRCantidad.text = "0";
    }

    public void CloseInventario()
    {
        GameManager.instance.inventario.SetActive(false);
    }
}
