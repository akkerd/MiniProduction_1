using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSleeve : MonoBehaviour {
    //Sleeve LevelSleeves. ConveyorSleeves



    public void AddSleeve(Sleeve sleeve)
    {
        Debug.Log(sleeve.ColorOfSleeve);
        transform.Find("Sleeve").GetComponent<Renderer>().material.color = sleeve.ColorOfSleeve;
    }
}
