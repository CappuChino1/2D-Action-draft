using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Assign player in Inspector
    public float smoothSpeed = 5f;
    public Vector3 offset;     // Optional offset

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position = player's position + offset
        Vector3 targetPos = player.position + offset;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}