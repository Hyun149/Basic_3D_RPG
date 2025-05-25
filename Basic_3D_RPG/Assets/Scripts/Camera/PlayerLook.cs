using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���콺 Look �Է¿� ���� ī�޶� ȸ�� ����
/// X��(Pitch)�� ī�޶�, Y��(Yaw)�� �÷��̾�
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [Header("Look ����")]
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float sensitivity;
    [SerializeField] private float minx;
    [SerializeField] private float maxX;

    private float camXRotation;

    /// <summary>
    /// Look �Է� ���Ϳ� ���� ȸ�� ó��
    /// </summary>
    /// <param name="lookInput"></param>
    public void ApplyLook(Vector2 lookInput)
    {
        float mouseX = lookInput.x * sensitivity * Time.deltaTime;
        float mouseY = lookInput.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        camXRotation -= mouseY;
        camXRotation = Mathf.Clamp(camXRotation, minx, maxX);
        cameraTarget.localRotation = Quaternion.Euler(camXRotation, 0f, 0f);
    }
}
