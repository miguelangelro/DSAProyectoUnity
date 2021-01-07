using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;
    public static GameManager instance = null;
    string infoMapa;

    private int level = 0;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
       
        boardScript = GetComponent<BoardManager>();

        instance.level++;
        if (instance.level == 1)
        {
            infoMapa = "50 50                    \n" +
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
                        "aaccc           A   cvcaa                         \n" +
                        "aaccc  gg   @   g   cvcaa                         \n" +
                        "aacvcccccccccccccccccccaa                         \n" +
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


            /* infoMapa =      "5 5  \n" +
                             "aaaaa\n" +
                             "aaaaa\n" +
                             "aaccc\n" +
                             "aacvc\n" +
                             "aacvc\n";
                            */
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
                        "aacvc               cvcaa\n" +
                        "aacvc               cccaa\n" +
                        "aacvc               cccaa\n" +
                        "aaccc             x cccaa\n" +
                        "aaccc           x   cccaa\n" +
                        "aaccc          x    cvcaa\n" +
                        "aaccc               cvcaa\n" +
                        "aaccc           x   cvcaa\n" +
                        "aaccc  A    @       cvcaa\n" +
                        "aaccccccccccccccccXccccaa\n" +
                        "aaccchhhhcccchhhhccccccaa\n" +
                        "aacccccccccccccccccccccaa\n" +
                        "aaaaaaaaaaaaaaaaaaaaaaaaa\n";
        }

        InitGame();
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

        //instance.InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(infoMapa);

    }

}
