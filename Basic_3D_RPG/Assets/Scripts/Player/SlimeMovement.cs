using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������ ĳ������ �̵��� ������ �����ϴ� ��ũ��Ʈ
/// Input System�� Rigidbody ������� ������
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SlimeMovement : MonoBehaviour
{
    [Header("�̵� ����")]
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
    /// Input System�� �̵� �Է� ó��
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Input System�� ���� �Է� ó��
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
    /// �̵� ó��: �Է� ���⿡ ���� Rigidbody ��ġ �̵�
    /// </summary>
    private void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 targetPosition = rb.position + move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    /// <summary>
    /// ���� ó��: ���� ���� ��쿡�� AddForce
    /// </summary>
    private void HandleJump()
    {
        if (jumpPressed && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumpPressed = false; // ĳ�� �Է� �ʱ�ȭ
    }


    /// <summary>
    /// Raycast�� ���� �Ǻ�
    /// </summary>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
