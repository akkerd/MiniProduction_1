using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPosReceiver : MonoBehaviour {

     public Transform EndTransform;
    [SerializeField]
    Transform EndposObject;

    void Start()
    {
       EndposObject.position = EndTransform.position;
    }
}
