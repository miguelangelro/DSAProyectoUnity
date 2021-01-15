using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;
    public static GameManager instance = null;
    string infoMapa;
    public GameObject CanvasImagePlane;
    public GameObject gameOver;
    public GameObject winner;
    public Text winnerText;
    public int currentHealth = 100;
    public int maxHealth = 100;
    public int score = 0;

    public int level = 0;
    public Boolean firstLoad = true;
    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        PlayerMovement.DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        CanvasImagePlane = GameObject.Find("CanvasImagePlane");
        CanvasImagePlane.SetActive(false);
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        winner = GameObject.Find("CanvasWIN");
        winnerText = GameObject.Find("txtScore").GetComponent<Text>();
        winner.SetActive(false);
        instance.level++;
        if (instance.level == 1)
        {
            instance.infoMapa = "50 50                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa                         \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa                         \n" +
                        "aacccccccccccccccccccccaa                         \n" +
                        "aaccccccchhhhhhhcccccccaa                         \n" +
                        "aacvcccccccccccccccccccaa                         \n" +
                        "aacvc               cccaa                         \n" +
                        "aacvc               cccaa                         \n" +
                        "aaccc      bb       cccaa                         \n" +
                        "aaccc      bb       cccaa                         \n" +
                        "aaccc      bb       cvcaa                         \n" +
                        "aaccc      bb       cvcaa                         \n" +
                        "aacvc      bb       cvcaa                         \n" +
                        "aacvc      bb       cvcaa                         \n" +
                        "aacvc      bb       cccaa                         \n" +
                        "aacvc      bb       cccaa                         \n" +
                        "aaccc      bb       cccaa                         \n" +
                        "aaccc  x   bb       cccaa                         \n" +
                        "aaccc  x   bb       cvcaa                         \n" +
                        "aaccc      bb       cvcaa                         \n" +
                        "aaccc           p   cvcaa                         \n" +
                        "aaccc  gg   @   g   cvcaa                         \n" +
                        "aacvccccAccccccccccccccaa                         \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa                         \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                           g                      \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n" +
                        "                                                  \n";
        }

        else if (instance.level == 2)
        {
            instance.infoMapa = "25 25                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaccccccchhhhhhhcccccccaa\n" +
                        "aacvcccccccccccccccccccaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cccaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aacvc               cvcaa\n" +
                        "aacvc       F       cvcaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc             x cccaa\n" +
                        "aaccc           x   cccaa\n" +
                        "aaccc          x    cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc           x   cvcaa\n" +
                        "aaccc       @       cvcaa\n" +
                        "aaccccccccccccccccXccccaa\n" +
                        "aaccchhhhcAcchhhhccccccaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n";
        }
        else if(instance.level >2)
        {
            instance.winnerText.text = "Score: " + instance.score;
            instance.winnerText.fontSize = 45;
            winner.SetActive(true);
        }

            /* infoMapa =      "5 5  \n" +
                             "aaaaa\n" +
                             "aaaaa\n" +
                             "aaccc\n" +
                             "aacvc\n" +
                             "aacvc\n";
                            */

            instance.InitGame();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.Awake();
    }

    void InitGame()
    {
        boardScript.SetupScene(infoMapa);

    }

}
