using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //public float tiempoEsperaAvion = 2f; //Tiempo que estara la pantalla con el avion.
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
            instance.infoMapa = "50 34                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaccccccccccccccccccccccccccccccccccccccccccccccaa\n" +
                        "aaccccccAhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhcccccccaa\n" +
                        "aasscccccSccccccsscccccccssccccccsscccccccccScccaa\n" +
                        "aacvc  x        x         x         x        cccaa\n" +
                        "aacvc    HHHHH     HHHHH     HHHHH     HHHH  cccaa\n" +
                        "aaccc                                        scsaa\n" +
                        "aacccYHHHH    HHHHH     HHHHH     HHHHH      cScaa\n" +
                        "aaccc                                        cvcaa\n" +
                        "aaccc     HHHH     HHHH     HHHH     HHHH    cvcaa\n" +
                        "aasvsX          X        X        X          cvcaa\n" +
                        "aacSc       x        x            x          cvcaa\n" +
                        "aacvc                                        cccaa\n" +
                        "aacvc        P         bb                    cccaa\n" +
                        "aacccY                 bb                   Sscsaa\n" +
                        "aaccc            X     bb                    cccaa\n" +
                        "aaccc                  bb   H  g X    H      cvcaa\n" +
                        "aascs    X             bb                    cvcaa\n" +
                        "aacSc                  bb                    cccaa\n" +
                        "aacvc                  bb                    cccaa\n" +
                        "aacvcY   H  x  H   g   bb      H  g X    H   cccaa\n" +
                        "aacvc                  bb                    cccaa\n" +
                        "aacvc   g              bb                   Sscsaa\n" +
                        "aacvc         H  x  H  bb                    cccaa\n" +
                        "aacvcY                 bb   H  g X    H      cccaa\n" +
                        "aacvc                                        cccaa\n" +
                        "aacvc    HHHHHHH               HHHHHHH       cccaa\n" +
                        "aacvcY                 Y                     cccaa\n" +
                        "aacvc        HHHHHHH       HHHHHHH           cccaa\n" +
                        "aaccc                             p          cvcaa\n" +
                        "aaccc  gg              @                 gg  cvcaa\n" +
                        "aacvccccccccccccccccccccccccccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "                                                  \n";
        }

        else if (instance.level == 2)
        {
            instance.infoMapa = "50 34                    \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaccccccccccccccccccccccccccccccccccccccccccccccaa\n" +
                        "aaccccAcchhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhcccccccaa\n" +
                        "aacvccsscccccsscccccsscccccsscccccsscccccsscccccaa\n" +
                        "aacvc   g       R       R      R      R      cccaa\n" +
                        "aacvc                 x               x      cccaa\n" +
                        "aaccc   HHHHHHHHHHHH    HHHHHHHHHHHH    HHHH cccaa\n" +
                        "aaccc                                        cccaa\n" +
                        "aascs     X    X    X    X    X    X    X    cvcaa\n" +
                        "aacSc                                        cvcaa\n" +
                        "aacvc     x   HHHH   x    HHHH   x    HHHH   cvcaa\n" +
                        "aacvc                                        cvcaa\n" +
                        "aacvc    HHHH   X   HHHH   X  HHHH   X       scsaa\n" +
                        "aaccc                                        cccaa\n" +
                        "aaccc                                        cvcaa\n" +
                        "aaccc     x    x                  X      X   cvcaa\n" +
                        "aaccc        g                       g       cvcaa\n" +
                        "aascs     X    X         W        x      x   cvcaa\n" +
                        "aacSc        g                        g      cvcaa\n" +
                        "aaccc     x    x                  X      X   svsaa\n" +
                        "aaccc                                        cScaa\n" +
                        "aaccc                                        cvcaa\n" +
                        "aacvc   X   g           p            g    X  cccaa\n" +
                        "aaccc     HHHH                     HHHHH     cccaa\n" +
                        "aaccc           HHHH           HHHH          cccaa\n" +
                        "aaccc     HHHH       HHHHHHHH       HHHH     cvcaa\n" +
                        "aaccc          HHHH            HHHH          cvcaa\n" +
                        "aaccc              HHHH   HHHH               cvcaa\n" +
                        "aaccc                   @                    cvcaa\n" +
                        "aaccccccccccccccccccccccccccccccccccccccccccccccaa\n" +
                        "aaccchhhhcccchhhhcccchhhhcccchhhhcccchhhhcccccccaa\n" +
                        "aacvccccccccccccccccccccccccccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n";
        }
        else if (instance.level == 3)
        {
            instance.infoMapa = "25 7                    \n" +

                        "                         \n" +
                        "                         \n" +
                        "                         \n" +
                        "                         \n" +
                        "                         \n" +
                        "    @          !         \n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n";
        }
        else if(instance.level > 3)
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
