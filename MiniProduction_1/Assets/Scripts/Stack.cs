using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {

    GameObject rayChosenObj = null;
    GameObject receivingStackObj = null;
    Plane objPlane;
    Vector3 m0;
    Vector3 startPosition;

    public LayerMask raycastSelection;

    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        return new Ray(mousePosN, mousePosF - mousePosN);
    }
	
	// Update is called once per frame
	void Update () {
        DragMovement();
	}

    void DragMovement()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = GenerateMouseRay();
                RaycastHit hit;
                Debug.DrawRay(mouseRay.origin, mouseRay.direction);
                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {
                    rayChosenObj = hit.transform.gameObject;
                    Debug.Log(rayChosenObj.name);

                    startPosition = rayChosenObj.transform.position;

                    objPlane = new Plane(Camera.main.transform.forward * -1, rayChosenObj.transform.position);

                    if (rayChosenObj.name == "stack")
                    {
                        // calc mouse offset
                        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);
                        m0 = rayChosenObj.transform.position - mRay.GetPoint(rayDistance);
                    }
                }
                else
                {
                    Debug.Log("not hitting");
                }
            }
            else if (Input.GetMouseButton(0) && rayChosenObj != null && rayChosenObj.name == "Stack")
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;

                if (objPlane.Raycast(mRay, out rayDistance))
                {
                    rayChosenObj.transform.position = mRay.GetPoint(rayDistance) + m0;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Keyrði");
                Ray mouseRay = GenerateMouseRay();
                RaycastHit hit;
                Debug.DrawRay(mouseRay.origin, mouseRay.direction);
                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, raycastSelection))
                {
                    receivingStackObj = hit.transform.gameObject;
                    //Debug.Log(rayChosenObj.name);
                    
                    if (receivingStackObj != null && receivingStackObj.layer == 9)
                    {
                        Debug.Log(receivingStackObj.name + " received stack");
                        rayChosenObj.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("No sleeve chosen");
                        rayChosenObj.transform.position = startPosition;
                    }
                }
            }
            else
            {
                rayChosenObj = null;
            }
            
            //transform.position += Vector3.right * 5 * Time.deltaTime;            
        }
    }
}
