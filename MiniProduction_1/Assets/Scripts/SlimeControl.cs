using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour {
    public float ZipperVal =20;
    public SlimeSpawn SlimeSpawnScript;

    private void Start()
    {
        
    }

    private void Update()
    {
        ZipperVal = transform.position.y;
       

    }
}
