using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float SensX = 200f;
    public float SensY = 200f;

    float xRotation;
    public float yRotation;
    public GameObject Player;
    bool inMenu = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        yRotation += MouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        xRotation -= MouseY;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
    }
}
