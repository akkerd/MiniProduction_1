using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve_TouchInfo : Helper_TouchController {


	private RaycastHit target;
	private GameObject go;
	private GameObject mainCamera;
	private Camera cameraComponent;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		cameraComponent = (Camera)mainCamera.GetComponent("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount != 0)
		{
			Touch currentTouch = Input.GetTouch(0);
			FirstTouch(currentTouch);
		}
		
	}
	
	public override void FirstTouch(Touch currentTouch)
	{
		
		if (currentTouch.phase == TouchPhase.Began)
		{
			Ray ray = cameraComponent.ScreenPointToRay( currentTouch.position );
			RaycastHit hit;

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "myGameObjectName")
			{
				hit.GetComponent<TouchObjectScript>().ApplyForce();  
			}

			bool sleeveTouched = Physics.Raycast(cameraComponent.ScreenToWorldPoint(currentTouch.position), Vector3.zero, out target, Mathf.Infinity, LayerMask.NameToLayer("Interactable") );
			Debug.DrawRay( cameraComponent.ScreenToWorldPoint(currentTouch.position), Vector3.zero);

			Debug.Log(sleeveTouched);

			if (sleeveTouched){
				go = target.transform.Find("Info_UI").gameObject;
				if(go.activeSelf)
					go.SetActive(false);
				else
					go.SetActive(true);

				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * target.distance, Color.yellow);
				Debug.Log("Did Hit");
			}
			else
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
				Debug.Log("Did not Hit");
			}
			
			return;
		}
	}

	public override void Drag(Touch touchStart)
	{

	}

	public override void Drop(Touch touchEnd)
	{

	}

	void FindChildrenWithname(string name)
	{
		//foreach (GameObject go in GetComponentInChildren(Transform, true))
		{

		}
	}
	
}
