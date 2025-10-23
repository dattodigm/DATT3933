using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [Header("Ground")]
    public float groundDrag;

    public Transform orientation;

    float horiInput;
    float vertiInput;

    public PlayerInput xboxSystem;
    private InputAction leftStickAxis;

    Vector3 moveDirection;
    public Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftStickAxis = xboxSystem.actions["Movement"];
        rb.freezeRotation = true;
        rb.linearDamping = groundDrag;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        InputRead();
    }

    void InputRead()
    {
        horiInput = leftStickAxis.ReadValue<Vector2>().x;
        vertiInput = leftStickAxis.ReadValue<Vector2>().y;
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * vertiInput + orientation.right * horiInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
