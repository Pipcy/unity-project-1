using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    // Variables
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;



    void Start()
    {
        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    
    void Update()
    {
        // Collect Mouse Input

        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity;//*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity;// *Time.deltaTime;

        // Rotate the Camera around its local X axis

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the Player Object and the Camera around its Y axis

        playerBody.Rotate(Vector3.up * mouseX);
       
    }
}