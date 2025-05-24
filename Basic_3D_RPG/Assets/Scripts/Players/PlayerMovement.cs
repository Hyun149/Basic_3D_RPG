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

    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private PlayerInputHandler inputHandler;
    private Vector2 currentInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.Initialize(this);
    }

    private void FixedUpdate()
    {
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

    }

    public void OnLook(Vector2 lookInput)
    {
        lookHandler?.ApplyLook(lookInput);
    }
}
