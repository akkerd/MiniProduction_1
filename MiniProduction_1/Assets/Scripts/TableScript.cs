using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public bool Moving;
    public Transform EndPosition;
    public Transform StartPosition;
    public float PTravelled =0;
    public MotionMatching MMscript;

    bool haveDeactivated = false;
    public int count;
    int previousInt;
    bool stackReceived;

	// Use this for initialization
	void Start () {
       count = UnsleeveManager.Instance.getCount();
       stackReceived= false;
	}

    public void ChangeParent()
    {

        transform.SetParent(UnsleeveManager.Instance.transform);
        //UnsleeveManager.Instance.DeactivatePrefab();
    }
	
	// Update is called once per frame
	void Update () {
        
        if( previousInt != StackDeliveryController.Instance.getTableInt() )
        {
            previousInt = StackDeliveryController.Instance.getTableInt();
             if(count == previousInt)
             {
                MMscript.Strong();
             }
        }
       


        
       
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
            //Debug.Log(PTravelled);
            if (PTravelled >= 0.5f)
            {
                Debug.Log("Sådan");
                MMscript.StandUp();
                transform.SetParent(UnsleeveManager.Instance.transform);
                UnsleeveManager.Instance.DestroyPrefab();
                
            }

        }      
	}

    public void SendDropEvent(int colliderIndex)
    {
        stackReceived = true;
    }
}
