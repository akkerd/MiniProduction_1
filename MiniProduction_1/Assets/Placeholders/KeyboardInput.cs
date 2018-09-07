using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {
    public bool isRigidbody = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isRigidbody)
        {
            RigidbodyForceMovement();
        }
        else
        {
            TransformMovement();
        }
        DragMovement();
    }
    void RigidbodyForceMovement()
    {
        Vector3 addedforce = Vector3.left * 10;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(addedforce);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(-addedforce);

        }
    }
    void TransformMovement()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 5 * Time.deltaTime;
            ConveyorController.Instance.MoveConveyorBelt(-1 * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 5 * Time.deltaTime;
            ConveyorController.Instance.MoveConveyorBelt(1 * 5 * Time.deltaTime);

        }
    }
    void DragMovement()
    {
        if (Input.touchCount != 0)
        {
            if (Input.touchCount == 2)
            {
                transform.position += Vector3.left * 5 * Time.deltaTime;
                ConveyorController.Instance.MoveConveyorBelt(-1 * 5 * Time.deltaTime);
            } else if (Input.touchCount == 1)
            {
                transform.position += Vector3.right * 5 * Time.deltaTime;
                ConveyorController.Instance.MoveConveyorBelt(1 * 5 * Time.deltaTime);
            }

        }
    }
}
