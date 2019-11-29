using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; //makes cursor invisible and locks into the game scene

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //mouse X axis for moving the camera 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //mouse Y axis for moving the camera

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
