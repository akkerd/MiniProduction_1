using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public bool Moving;
    public Transform EndPosition;
    public Transform StartPosition;
    public float PTravelled =0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position,EndPosition.position);
        if (distance == 0 || distance == Mathf.Infinity)
        {
            return;
        }

        if (Moving == true)
        {
            PTravelled += 0.5f* Time.deltaTime;
            transform.position = Vector3.Lerp(StartPosition.position, EndPosition.position, PTravelled);

        }
        if (PTravelled >= 1)
        {
            
            transform.SetParent(UnsleeveManager.Instance.transform);
            UnsleeveManager.Instance.DestroyPrefab();
        }
                
                
	}
}
