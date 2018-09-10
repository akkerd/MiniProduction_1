using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public bool Moving;
    public Transform EndPosition;
    public Transform StartPosition;
    float PTravelled =0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Moving == true)
        {
            PTravelled += 0.05f;
            transform.position = Vector3.Lerp(StartPosition.position, EndPosition.position, PTravelled);

        }
	}
}
