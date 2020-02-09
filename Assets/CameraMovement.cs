using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject hand;
    public Transform player;
    public float mouseSensitivity;
    public float holsterTimeThreshold = 0.5f;

    float holdTime = 0.0f;

    void Update()
    {
        checkHolster();
        look();
    }

    void look()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        Vector3 yRotation = -1 * Vector3.right * mouseY;
        transform.Rotate(yRotation * mouseSensitivity * Time.deltaTime);
        Debug.Log(transform.localEulerAngles);
        
        Vector3 xRotation = Vector3.up * mouseX;
        player.Rotate(xRotation * mouseSensitivity * Time.deltaTime);
    }

    void checkHolster()
    {
        KeyCode key = KeyCode.R;
        
        if (Input.GetKeyDown(key) && hand.activeSelf == false)
            hand.SetActive(!(hand.activeSelf));
        
        if (holdTime >= holsterTimeThreshold && hand.activeSelf == true)
            hand.SetActive(!(hand.activeSelf));

        else if (Input.GetKey(key))
            holdTime += Time.deltaTime;
        
        else if (Input.GetKeyUp(key))
            holdTime = 0.0f; 
    }
}
