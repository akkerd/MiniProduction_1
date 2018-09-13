using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPosReceiver : MonoBehaviour {

     
    [SerializeField]
    Transform EndposObject;


    public void Setpos(Transform t)
    {

        EndposObject.position = t.position;

    }
}
