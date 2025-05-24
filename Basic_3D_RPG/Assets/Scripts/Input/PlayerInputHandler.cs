using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input System을 통해 입력을 받고, IPlayerActions로 전달하는 클래스
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private IPlayerActions callback;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    public void Initialize(IPlayerActions callbackTarget)
    {
        callback = callbackTarget;
    }

    public void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => 
        { 
            MoveInput = ctx.ReadValue<Vector2>(); 
            callback?.OnMove(MoveInput); 
        };

        inputActions.Player.Move.canceled += ctx =>
        {
            MoveInput = Vector2.zero;
            callback?.OnMove(Vector2.zero);
        };

        inputActions.Player.Look.performed += ctx =>
        {
            LookInput = ctx.ReadValue<Vector2>();
            callback?.OnLook(LookInput);
        };

        inputActions.Player.Jump.performed += ctx =>
        {
            callback?.OnJump();
        };

    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
