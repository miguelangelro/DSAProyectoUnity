using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
        if (!GameManager.instance.firstLoad)
        {
            jug.mascarilla = GameManager.instance.mask;
            jug.pocion = GameManager.instance.pocion;
            jug.bolsa = GameManager.instance.bolsa;
            jug.pcr = GameManager.instance.pcr;
            jug.regeneron = GameManager.instance.regeneron;

        }

        
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

        GameManager.instance.mask = jug.mascarilla;
        GameManager.instance.pocion = jug.pocion;
        GameManager.instance.bolsa = jug.bolsa;
        GameManager.instance.pcr = jug.pcr;
        GameManager.instance.regeneron = jug.regeneron;
    }

    public void mascarillaUsada()
    {
       int mask = Convert.ToInt32(this.jug.mascarilla);
        if (mask > 0)
        {
            mask--;
            if (jug.currentHealth >= 80)
            {
                jug.setCurrentHealth(GameManager.instance.maxHealth);
            }
            else { jug.setCurrentHealth(jug.currentHealth+20); }
            MascCantidad.text = mask.ToString();
            jug.setMascarilla(mask.ToString());
        }
        
       /*MascCantidad.text = "1";*/
        
    }
    public void pocionUsada()
    {
        
        int pocion = Convert.ToInt32(this.jug.pocion);
        if (pocion > 0)
        {
            pocion--;
            if (jug.currentHealth >= 50)
            {
                jug.setCurrentHealth(GameManager.instance.maxHealth);
            }
            else {
                jug.setCurrentHealth(jug.currentHealth+50); }
            PocionCantidad.text = pocion.ToString();
            jug.setPocion(pocion.ToString());
        }
    }

    public void regeneracionUsado()
    {
        int regen = Convert.ToInt32(this.jug.regeneron);
        if (regen > 0)
        {
            regen--;
            
            jug.setCurrentHealth(GameManager.instance.maxHealth);
            
           
            RegeneradorCantidad.text = regen.ToString();
            jug.setRegeneron(regen.ToString());
        }
    }
    public void bolsaBasuraUsada()
    {
        int bolsa = Convert.ToInt32(this.jug.bolsa);
        if (bolsa > 0)
        {
            bolsa--;
            BolsaBasuraCantidad.text = bolsa.ToString();
            jug.setBolsa(bolsa.ToString());
        }
    }
    public void pcrUsado()
    {
        int pcr = Convert.ToInt32(this.jug.pcr);
        if (pcr > 0)
        {
            pcr--;
            if (jug.currentHealth >= 90)
            {
                jug.setCurrentHealth(GameManager.instance.maxHealth);
            }
            else
            {
                jug.setCurrentHealth(jug.currentHealth+10);
            }
            PCRCantidad.text = pcr.ToString();
           jug.setPcr(pcr.ToString());
        }
    }

    public void CloseInventario()
    {
        GameManager.instance.inventario.SetActive(false);
    }
}
