using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �Է� �׼ǵ��� ó���ϱ� ���� �������̽�
/// �ʿ� ��ɸ� ���� �����Ͽ� ���
/// </summary>
public interface IPlayerActions
{
    void OnMove(Vector2 moveInput);
    void OnJump();
    void OnLook(Vector2 lookInput);
}
