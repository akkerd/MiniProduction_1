using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour {

    public int stackNumber;

    GameObject chosenStack = null;
    GameObject receivingSleeve = null;
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
                    chosenStack = hit.transform.gameObject;
                    Debug.Log(chosenStack.name);

                    startPosition = chosenStack.transform.position;

                    objPlane = new Plane(Camera.main.transform.forward * -1, chosenStack.transform.position);

                    if (chosenStack.name == "Stack")
                    {
                        // calc mouse offset
                        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);
                        m0 = chosenStack.transform.position - mRay.GetPoint(rayDistance);
                    }
                }
                else
                {
                    Debug.Log("not hitting");
                }
            }
            else if (Input.GetMouseButton(0) && chosenStack != null && chosenStack.name == "Stack")
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;

                if (objPlane.Raycast(mRay, out rayDistance))
                {
                    chosenStack.transform.position = mRay.GetPoint(rayDistance) + m0;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Ray mouseRay = GenerateMouseRay();
                RaycastHit hit;
                Debug.DrawRay(mouseRay.origin, mouseRay.direction);
                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, raycastSelection))
                {
                    receivingSleeve = hit.transform.gameObject;
                    //Debug.Log(chosenStack.name);
                    
                    if (receivingSleeve != null && receivingSleeve.layer == 10)
                    {
                        Debug.Log(receivingSleeve.name + " received stack");
                        chosenStack.SetActive(false);
                        StackDeliveryController.Instance.CombinedStackWithSleeve(stackNumber,receivingSleeve.name.ToCharArray()[6]);
                    }
                    else
                    {
                        Debug.Log("No sleeve chosen");
                        chosenStack.transform.position = startPosition;
                    }
                }
            }
            else
            {
                chosenStack = null;
            }
            
            //transform.position += Vector3.right * 5 * Time.deltaTime;            
        }
    }
}
