using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUnsleeve : MonoBehaviour {
   
    public Camera camerar;
    public GameObject Zipper;

    public LayerMask touchInputMask;

    private void Start()
    {
        camerar= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        

#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) 
        {
           

                Ray ray = camerar.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
              
                 
                    GameObject recipient = hit.transform.gameObject;

                    if (Input.GetMouseButtonDown(0))
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (Input.GetMouseButton(0))
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    if (Vector3.Distance(Zipper.transform.position, hit.point) <= 0.2f ) {
                        Zipper.transform.position = new Vector3(hit.point.x, hit.point.y, hit.transform.gameObject.transform.position.z);
                       
                    }
                    }
                   
                }




            
        }

#endif




        if (Input.touchCount > 0){
        foreach (Touch touch in Input.touches)
        {

            Ray ray = camerar.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, touchInputMask))
            {

                GameObject recipient = hit.transform.gameObject;

                if (touch.phase == TouchPhase.Began)
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);

                }
                if (touch.phase == TouchPhase.Moved)
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                        if (Vector3.Distance(Zipper.transform.position, hit.point) <= 0.2f)
                        {
                            Zipper.transform.position = new Vector3(hit.point.x, hit.point.y, hit.transform.gameObject.transform.position.z);
                        }
                    }
                if (touch.phase == TouchPhase.Canceled)
                {
                    recipient.SendMessage("OnTouchCanceled", hit.point, SendMessageOptions.DontRequireReceiver);

                }
            }

        
       

        }
        }

	}
}
