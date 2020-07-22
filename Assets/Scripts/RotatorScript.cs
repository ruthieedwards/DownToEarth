using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a brief script to rotate the backgrounds on the menu/game over screens
public class RotatorScript : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    void Update()
    {
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
