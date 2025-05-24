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
    [SerializeField] private float sensitivity = 3f;
    [SerializeField] private float minx = -60f;
    [SerializeField] private float maxX = 60f;

    private float camXRotation = 0f;

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
