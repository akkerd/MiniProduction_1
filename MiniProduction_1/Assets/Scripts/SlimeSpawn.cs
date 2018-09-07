using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour {

    public float SliderVal=20;
    Cloth ClothComp;
    SkinnedMeshRenderer SMRendereder;
    public GameObject Zipper;
  SlimeControl ZipperScript;

    void Start()
    {
        ClothComp = gameObject.GetComponent<Cloth>();
       SMRendereder = gameObject.GetComponent<SkinnedMeshRenderer>();
        ClothComp.enabled = false;
        SMRendereder.enabled = false;
        ZipperScript = Zipper.GetComponent<SlimeControl>();
        
    }

    // Update is called once per frame
    void Update () {
        
        
        if (ZipperScript.ZipperVal < transform.position.y)
        {
            
            SMRendereder.enabled = true;
            ClothComp.enabled = true;
            if (ClothComp.externalAcceleration.x > 0)
            {
                ClothComp.externalAcceleration += new Vector3(-0.2f, 0, 0);
            }
             
          
        }
		
	}
}
