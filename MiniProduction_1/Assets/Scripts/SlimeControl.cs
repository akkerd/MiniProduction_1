using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour {
    public float ZipperValX =20;
    public float ZipperValY = 20;
 

    private void Start()
    {
        
    }

    private void Update()
    {
        ZipperValX = transform.position.x;
        ZipperValY = transform.position.y;


    }
}
