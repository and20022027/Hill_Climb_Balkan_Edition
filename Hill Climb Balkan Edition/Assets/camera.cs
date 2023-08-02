using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;    // The object the camera will follow
    public float smoothSpeed = 1f;    // Smoothing factor for camera movement

    private Vector3 offset;

    void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera based on the target's position and offset
            Vector3 desiredPosition = target.position + offset;

            // Use Lerp to smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}

