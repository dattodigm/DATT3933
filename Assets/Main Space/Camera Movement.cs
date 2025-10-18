using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity;
    public float normalSpeed;
    public float sprintSpeed;
    public PlayerInput xboxSystem;

    private InputAction rightTriggerAction;
    private InputAction leftTriggerAction;
    private InputAction rightStickAxis;
    private InputAction leftStickAxis;

    float currentSpeed;

    private void Awake()
    {
        rightTriggerAction = xboxSystem.actions["Enable Movement"];
        leftTriggerAction = xboxSystem.actions["Sprint"];
        rightStickAxis = xboxSystem.actions["Camera"];
        leftStickAxis = xboxSystem.actions["Movement"];
    }

    void Update()
    {
        Vector3 currentPlayerPosition = transform.position;

        float triggerValue = rightTriggerAction.ReadValue<float>();
        if (triggerValue > 0.1f) //if we are holding right click
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Movement();
            Rotation();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(currentPlayerPosition.x >= 13f) {
            transform.position = new Vector3(12f, transform.position.y, transform.position.z);
        } else if (currentPlayerPosition.x <= -13f) {
            transform.position = new Vector3(-13f, transform.position.y, transform.position.z);
        } else if (currentPlayerPosition.z <= -13f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -12f);
        } else if (currentPlayerPosition.z >= 13f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 12f);
        } else if (currentPlayerPosition.y >= 15f) {
            transform.position = new Vector3(transform.position.x, 14f, transform.position.z);
        } else if (currentPlayerPosition.y <= 0f) {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }

    }

    public void Rotation()
    {
        
            Vector2 move = rightStickAxis.ReadValue<Vector2>();
            Vector3 controllerInput = new Vector3(-move.y, move.x, 0);
            transform.Rotate(controllerInput * sensitivity);
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        
    }

    public void Movement()
    {
            Vector2 move = leftStickAxis.ReadValue<Vector2>();
            Vector3 input = new Vector3(move.x, 0f, move.y);
            float triggerValue = leftTriggerAction.ReadValue<float>();

            if (triggerValue > 0.1f)
            {
                currentSpeed = sprintSpeed;
            } else
            {
                currentSpeed = normalSpeed;
            }

            transform.Translate(input * currentSpeed * Time.deltaTime);
    }
}
