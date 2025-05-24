using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 마우스 Look 입력에 따라 카메라 회전 제어
/// X축(Pitch)은 카메라, Y축(Yaw)은 플레이어
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [Header("Look 설정")]
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float sensitivity = 3f;
    [SerializeField] private float minx = -60f;
    [SerializeField] private float maxX = 60f;

    private float camXRotation = 0f;

    /// <summary>
    /// Look 입력 벡터에 따라 회전 처리
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
