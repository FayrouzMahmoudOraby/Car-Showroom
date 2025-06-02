using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotationController : MonoBehaviour
{
    private bool isRotating = false;
    public float zRotationSpeed = 50f;

    public void ToggleCarRotation()
    {
        isRotating = !isRotating;
        Debug.Log("Car Z-axis rotation toggled: " + isRotating);
    }

    private void Update()
    {
        if (isRotating)
        {
            RotateCarOnZ();
        }
    }

    private void RotateCarOnZ()
    {
        transform.Rotate(0f, 0f, zRotationSpeed * Time.deltaTime);
    }
}
