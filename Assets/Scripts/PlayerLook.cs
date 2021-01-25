using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;

    float xRotation = 0f;
    public float mouseSensitivity = 100f;

    public GameObject alternativeCamera;
    bool isUsingAlternativeCamera = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C)) { 
            alternativeCamera.SetActive(!isUsingAlternativeCamera);
            isUsingAlternativeCamera = !isUsingAlternativeCamera;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
