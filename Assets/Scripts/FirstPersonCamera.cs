using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {
    public Transform Target;
    public float MouseSensitivity = 10f;
    public float DistanceFromTarget = 5f; // Distance from the target
    public float HeightFromTarget = 2f;   // Height above the target
    public float MinVerticalAngle = -70f; // Minimum vertical angle
    public float MaxVerticalAngle = 70f;  // Maximum vertical angle
    public float MinHorizontalAngle = -70f; // Minimum horizontal angle
    public float MaxHorizontalAngle = 70f;  // Maximum horizontal angle
    private float verticalRotation;
    private float horizontalRotation;

    void LateUpdate() {
        if (Target == null) {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        verticalRotation -= mouseY * MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, MinVerticalAngle, MaxVerticalAngle);

        horizontalRotation += mouseX * MouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, MinHorizontalAngle, MaxHorizontalAngle);

        Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        Vector3 offset = new Vector3(0, HeightFromTarget, -DistanceFromTarget);
        transform.position = Target.position + rotation * offset;
        transform.LookAt(Target.position + Vector3.up * HeightFromTarget);
    }
    }
