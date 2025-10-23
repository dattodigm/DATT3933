using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public PlayerInput xboxSystem;
    public Transform orientation;
    private InputAction rightStickAxis;

    float xRotate;
    float yRotate;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rightStickAxis = xboxSystem.actions["Camera"];
    }

    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        float inputX = rightStickAxis.ReadValue<Vector2>().x;
        float inputY = rightStickAxis.ReadValue<Vector2>().y;

        yRotate += inputX;
        xRotate -= inputY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        orientation.rotation = Quaternion.Euler(0, yRotate, 0);

    }
}
