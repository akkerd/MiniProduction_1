using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSleeve : MonoBehaviour {
    //Sleeve LevelSleeves. ConveyorSleeves

    public int positionInArray;

    public int PositionInArray
    {
        get
        {
            return positionInArray;
        }

        set
        {
            positionInArray = value;
        }
    }

    public void AddSleeve(Sleeve sleeve,int position)
    {
        PositionInArray = position;
        //Debug.Log(sleeve.ColorOfSleeve);
        transform.Find("Sleeve").GetComponent<Renderer>().material.color = sleeve.ColorOfSleeve;
    }
}
