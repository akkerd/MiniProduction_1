using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUsleeve : MonoBehaviour {


    private Material mat;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
		
	}
	void OnTouchDown()
    {
        mat.color = Color.red;
    }
    void OnTouchUp()
    {
        mat.color = Color.green;
    }
    void OnTouchStay()
    {
        mat.color = Color.yellow;
        
    }

}
