using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour {

    Animation anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        //anim["clip"].time = 2;
        anim.Play("walkCircleLeft_001_dt");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
