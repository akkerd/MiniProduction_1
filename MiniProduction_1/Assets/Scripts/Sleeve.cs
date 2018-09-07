using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve {

    Color colorOfSleeve;
    public bool isEmpty;

    public Sleeve()
    {
        isEmpty = true;
    }
    public Color ColorOfSleeve
    {
        get
        {
            return colorOfSleeve;
        }

        set
        {
            colorOfSleeve = value;
        }
    }
}
