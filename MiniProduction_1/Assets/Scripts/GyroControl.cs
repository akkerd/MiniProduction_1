using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;

    Vector3 startPosition;

    private Vector3 startRotation;
    private Vector3 nextRotation;

    private bool initiated = false;

    public float maxRotationLeft;
    public float maxRotationRight;
    public float maxRotationUp;
    public float maxRotationDown;

    // Use this for initialization
    void Start () {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
	}

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (gyroEnabled)
        {
            if (!(initiated))
            {
                cameraContainer.transform.Rotate(0, -gyro.rotationRateUnbiased.y, 0);
                startRotation = new Vector3(cameraContainer.transform.rotation.x, cameraContainer.transform.rotation.y, cameraContainer.transform.rotation.z);
                nextRotation = new Vector3(cameraContainer.transform.rotation.x, cameraContainer.transform.rotation.y, cameraContainer.transform.rotation.z);
                initiated = true;
            }

            nextRotation.x = -gyro.rotationRateUnbiased.x;
            nextRotation.y = -gyro.rotationRateUnbiased.y;

            bool rotateY = true;
            bool rotateX = true;

            float maxRot = 0.2f;

            Debug.Log("StartTrans: " + startRotation.y);
            Debug.Log("CameraTrans: " + cameraContainer.transform.rotation.y);

            // max move to the right
            if (-gyro.rotationRateUnbiased.y > 0 && cameraContainer.transform.rotation.y > startRotation.y + maxRotationRight)
            {
                rotateY = false;
                nextRotation.y = startRotation.y + maxRot;
            }
            // max move to the left
            else if (-gyro.rotationRateUnbiased.y < 0 && cameraContainer.transform.rotation.y < startRotation.y - maxRotationLeft)
            {
                rotateY = false;
                nextRotation.y = startRotation.y - maxRot;
            }

            if (rotateY)
            {
                cameraContainer.transform.Rotate(0, nextRotation.y, 0);
            }


            // max move down
            if (-gyro.rotationRateUnbiased.x > 0 && transform.rotation.x > startRotation.x + maxRotationDown)
            {
                rotateX = false;
                nextRotation.x = startRotation.x + maxRot;
            }
            // max move up
            else if (-gyro.rotationRateUnbiased.x < 0 && transform.rotation.x < startRotation.x - maxRotationUp)
            {
                rotateX = false;
                nextRotation.x = startRotation.x - maxRot;
            }

            if (rotateX)
            {
                transform.Rotate(nextRotation.x, 0, 0);
            }
        }
	}
}
