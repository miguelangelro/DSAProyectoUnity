using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;
    public static GameManager instance = null;
    string infoMapa;


    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
       
        boardScript = GetComponent<BoardManager>();

        infoMapa = "25 25                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaccccccchhhhhhhcccccccaa\n" +
                        "aacvcccccccccccccccccccaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc      bb       cccaa\n" +
                        "aaccc      bb       cccaa\n" +
                        "aaccc      bb       cvcaa\n" +
                        "aaccc      bb       cvcaa\n" +
                        "aacvc      bb       cvcaa\n" +
                        "aacvc      bb       cvcaa\n" +
                        "aacvc      bb       cccaa\n" +
                        "aacvc      bb       cccaa\n" +
                        "aaccc      bb       cccaa\n" +
                        "aaccc      bb       cccaa\n" +
                        "aaccc      bb       cvcaa\n" +
                        "aaccc      bb       cvcaa\n" +
                        "aaccc           x   cvcaa\n" +
                        "aaccc       @       cvcaa\n" +
                        "aaccccccccccccccccXccccaa\n" +
                        "aaccchhhhcccchhhhccccccaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n";
        
       /* infoMapa =      "5 5  \n" +
                        "aaaaa\n" +
                        "aaaaa\n" +
                        "aaccc\n" +
                        "aacvc\n" +
                        "aacvc\n";
                       */

        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(infoMapa);

    }

}
