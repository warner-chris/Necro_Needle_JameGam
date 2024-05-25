using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    internal static UnityEngine.Camera main;

    // The target the camera will follow
    public Transform target;

    // How smoothly the camera follows the target
    public float smoothSpeed = 0.125f;

    // Offset of the camera from the target
    public Vector3 offset;

    private void LateUpdate()
    {
        // Desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera position
        transform.position = smoothedPosition;
    }
}
