using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour {

    private void Update()
    {
        SlimeSpawn.SliderVal = transform.position.y;
        Debug.Log(SlimeSpawn.SliderVal);

    }
}
