using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public GameObject rotateParentObject;
    public float cameraRotatingDirection = 0;

    void Start()
    {
        rotateParentObject.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
    }
    void Update()
    {
        // uses the left/right arrows to add speed to the rotation of Earf and everything on it
            rotateParentObject.transform.Rotate(0.0f, 0.0f, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);
            cameraRotatingDirection = Input.GetAxis("Horizontal");
    }
}
