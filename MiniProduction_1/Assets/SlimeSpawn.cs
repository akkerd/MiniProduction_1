using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour {

    public static float SliderVal =20;
    Cloth ClothComp;

    private void Start()
    {
        ClothComp = gameObject.GetComponent<Cloth>();
        ClothComp.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        
        
        if (SliderVal < transform.position.y)
        {
            ClothComp.enabled = true;
            if (ClothComp.externalAcceleration.x > 0)
            {
                ClothComp.externalAcceleration += new Vector3(-0.2f, 0, 0);
            }
        }
		
	}
}
