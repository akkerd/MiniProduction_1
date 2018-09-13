using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public bool Moving;
    public Transform EndPosition;
    public Transform StartPosition;
    public float PTravelled =0;

    bool haveDeactivated = false;

	// Use this for initialization
	void Start () {
		
	}

    public void ChangeParent()
    {

        transform.SetParent(UnsleeveManager.Instance.transform);
        //UnsleeveManager.Instance.DeactivatePrefab();
    }
	
	// Update is called once per frame
	void Update () {

        if (EndPosition != null)
        {
            float distance = Vector3.Distance(transform.position, EndPosition.position);
            if (distance == 0 || distance == Mathf.Infinity)
            {
                return;
            }

            if (Moving == true)
            {
                PTravelled += 0.5f * Time.deltaTime;
                transform.position = Vector3.Lerp(StartPosition.position, EndPosition.position, PTravelled);
                transform.SetParent(UnsleeveManager.Instance.transform);
                if (!haveDeactivated)
                {
                    haveDeactivated = true;
                    UnsleeveManager.Instance.DeactivatePrefab();
                }


            }
            if (PTravelled >= 1)
            {                
                transform.SetParent(UnsleeveManager.Instance.transform);
                UnsleeveManager.Instance.DestroyPrefab();
            }

        }      
	}
}
