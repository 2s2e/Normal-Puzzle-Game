using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(0f, 500f)]
    public float MouseSenstivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSenstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSenstivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX); //Move up
        
        xRotation -= mouseY; // minues because otherwise will be flipped
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //Move side;
    }
}
