using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour {
    public float ZipperValX =20;
    public float ZipperValY = 20;
    public GameObject tail;
  

    private void Start()
    {
        
    }

    private void Update()
    {

    
        ZipperValX = transform.position.x;
        ZipperValY = transform.position.y;



        transform.LookAt(new Vector3(tail.transform.position.x, tail.transform.position.y, transform.position.z), new Vector3(0, 0, -1));
        //transform.Rotate(0, 0, -90);




    }

}
