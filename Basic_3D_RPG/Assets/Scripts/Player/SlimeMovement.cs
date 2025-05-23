using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 슬라임 캐릭터의 이동과 점프를 제어하는 스크립트
/// Input System과 Rigidbody 기반으로 구성됨
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SlimeMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumpPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Input System의 이동 입력 처리
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Input System의 점프 입력 처리
    /// </summary>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpPressed = true;
    }

    private void FixedUpdate()
    {
        Move();
        HandleJump();
    }

    /// <summary>
    /// 이동 처리: 입력 방향에 따라 Rigidbody 위치 이동
    /// </summary>
    private void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 targetPosition = rb.position + move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    /// <summary>
    /// 점프 처리: 땅에 있을 경우에만 AddForce
    /// </summary>
    private void HandleJump()
    {
        if (jumpPressed && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumpPressed = false; // 캐싱 입력 초기화
    }


    /// <summary>
    /// Raycast로 지면 판별
    /// </summary>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
