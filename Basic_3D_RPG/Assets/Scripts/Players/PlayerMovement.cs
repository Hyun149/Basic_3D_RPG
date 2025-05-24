using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이동만 담당하는 컴포넌트
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IPlayerActions
{
    [Header("Look")]
    [SerializeField] private PlayerLook lookHandler;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.3f;

    private Rigidbody rb;
    private PlayerInputHandler inputHandler;
    private Vector2 currentInput;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.Initialize(this);
    }

    private void FixedUpdate()
    {
        CheckGround();
        Vector3 move = new Vector3(currentInput.x, 0f, currentInput.y);
        Vector3 worldMove = transform.TransformDirection(move);
        rb.MovePosition(rb.position + worldMove * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnMove(Vector2 moveInput)
    {
        currentInput = moveInput;
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnLook(Vector2 lookInput)
    {
        lookHandler?.ApplyLook(lookInput);
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
