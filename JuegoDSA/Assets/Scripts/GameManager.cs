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
       /* if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
       */
        boardScript = GetComponent<BoardManager>();

        this.infoMapa = "25 25                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aacvccccchhhhhhhcccccccaa\n" +
                        "aacvcccccccccccccccccccaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aacvc               cvcaa\n" +
                        "aacvc               cvcaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaccchhhhcccchhhhcccccaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n";

        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(infoMapa);

    }

}
