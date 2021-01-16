using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(1,5)]//Num minimo,maximo de lineas
    public string[] sentences;
    
}
