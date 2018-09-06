using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapesScript : MonoBehaviour {

    SkinnedMeshRenderer SMRenderer;
    public int WeightValue = 50;

	// Use this for initialization
	void Start () {

        SMRenderer = GetComponent<SkinnedMeshRenderer>();

        SMRenderer.SetBlendShapeWeight(0, WeightValue);
		
	}
	

}
