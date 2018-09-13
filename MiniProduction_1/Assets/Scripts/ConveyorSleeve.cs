using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSleeve : MonoBehaviour {
    //Sleeve LevelSleeves. ConveyorSleeves

    public int positionInArray;
    public Sleeve attachedSleeve;

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

    public void AddSleeve(Sleeve sleeve,int positionInLevelArray)
    {
        attachedSleeve = sleeve;
        PositionInArray = positionInLevelArray;
        if (sleeve.isEmpty)
        {
            SleeveIsEmpty();
            return;
        }
        transform.Find("Sleeve").GetComponent<Renderer>().material.color = sleeve.ColorOfSleeve;
    }
    void SleeveIsEmpty()
    {
        //Implement the removal of the body in the shell
        transform.Find("Sleeve").GetComponent<Renderer>().material.color = Color.blue;
    }
    
}
