using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Camera))]
public class Screen_Size_Relocation : MonoBehaviour {

	// Use this for initialization
     void Start () {

		 if(Screen.width >= 1500)
		 {
			transform.position = new Vector3(transform.position.x, transform.position.y, -0.55f);
		 }
		 else
		 {
			transform.position = new Vector3(transform.position.x, transform.position.y, 0.45f);
		 }
         // get the vertical FOV from the camera
         // divide by 2 since the triangle we're solving is half the actual FOV triangle
         //float vFov = Camera.main.fieldOfView;
		 
         // get the distance from the camera to the game board
         //float cameraDistance = Screen.height / (2f*Mathf.Tan(0.5f*vFov));
         // calculate the 3rd angle of our right angle triangle
         //float lastAngle = 180f - 90f - vFov;
		 

         // now we have 2 sides to our triangle, we need the 3rd side (the game board height)
         // solve via law of sines
         // multiply by 2 because this is only half the actual FOV triangle
         //float vSize = ( (Mathf.Sin(vFov * Mathf.Deg2Rad) * cameraDistance) / Mathf.Sin(lastAngle * Mathf.Deg2Rad) ) * 2f;
         
         // now calculate the hSize by a simple ratio equation
         //float hSize = (Screen.width * vSize) / Screen.height;
         
         // move the camera to be half that so our bottem left point is 0,0
         //transform.position = Camera.main.ScreenToWorldPoint( new Vector3(transform.position.x, transform.position.y, cameraDistance) );
         
         //Debug.Log ("resolution(" + Screen.width + " x " + Screen.height + ") gameBoard(" + hSize + " x " + vSize + ")");
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
