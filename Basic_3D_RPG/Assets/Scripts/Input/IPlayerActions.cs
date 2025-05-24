using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 입력 액션들을 처리하기 위한 인터페이스
/// 필요 기능만 직접 정의하여 사용
/// </summary>
public interface IPlayerActions
{
    void OnMove(Vector2 moveInput);
    void OnJump();
    void OnLook(Vector2 lookInput);
}
