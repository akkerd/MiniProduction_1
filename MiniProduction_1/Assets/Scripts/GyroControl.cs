using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rotation;

    public Quaternion startRotation;
    private Quaternion nextRotation;

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

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);

            nextRotation = startRotation;

            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (gyroEnabled)
        {
            nextRotation.x = gyro.attitude.x;
            nextRotation.y = gyro.attitude.y;
            nextRotation.z = gyro.attitude.z;
            nextRotation.w = gyro.attitude.w;

            if ((startRotation.x - maxRotationDown) > gyro.attitude.x )
            {
                nextRotation.x = startRotation.x - maxRotationDown;
            }

            if ((startRotation.x + maxRotationUp) < gyro.attitude.x)
            {
                nextRotation.x = startRotation.x + maxRotationUp;
            }
            
            if ((startRotation.y - maxRotationDown) > gyro.attitude.y )
            {
                nextRotation.y = startRotation.y - maxRotationDown;
            }

            if ((startRotation.y + maxRotationUp) < gyro.attitude.y)
            {
                nextRotation.y = startRotation.y + maxRotationUp;
            }
            
            if ((startRotation.z - maxRotationLeft) > gyro.attitude.z)
            {
                nextRotation.z = startRotation.z - maxRotationLeft;
            }
            
            if ((startRotation.z + maxRotationRight) < gyro.attitude.z)
            {
                nextRotation.z = startRotation.z + maxRotationRight;
            }
            
            if ((startRotation.w - maxRotationLeft) > gyro.attitude.w)
            {
                nextRotation.w = startRotation.w - maxRotationLeft;
            }

            if ((startRotation.w + maxRotationRight) < gyro.attitude.w)
            {
                nextRotation.w = startRotation.w + maxRotationRight;
            }

            transform.localRotation = nextRotation * rotation;
        }
	}

    public void OnClickCenter()
    {
        Debug.Log("Clicked");
        if (gyroEnabled)
        {
            Debug.Log("Inside");
            startRotation = gyro.attitude;
        }
    }
}
