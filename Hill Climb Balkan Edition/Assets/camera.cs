using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform Sasija; // The object the camera will follow (assign this in the Inspector)
    public float smoothSpeed = 1f; // Smoothing factor for camera movement
    public float zoomSpeed = 1.0f; // Adjust this to control zoom speed
    public float minZoom = 1.0f; // Minimum orthographic size (zoomed out)
    public float maxZoom = 10.0f; // Maximum orthographic size (zoomed in)
    public float targetSpeedThreshold = 5.0f; // The target speed at which the camera starts zooming out

    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Get a reference to the camera component
        offset = transform.position - Sasija.position; // Calculate the initial offset between the camera and the target
    }

    void Update()
    {
        if (Sasija != null)
        {
            // Calculate the desired position for the camera based on the target's position and offset
            Vector3 desiredPosition = Sasija.position + offset;

            // Use Lerp to smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;

            // Calculate the zoom amount based on the target's speed
            float targetSpeed = Sasija.GetComponent<Rigidbody2D>().velocity.magnitude;
            float zoomDelta = 0f;

            // If the target's speed exceeds the threshold, zoom out
            if (targetSpeed > targetSpeedThreshold)
            {
                zoomDelta = targetSpeed * zoomSpeed;
            }

            // Apply zoom based on the target's speed
            float newOrthoSize = Mathf.Clamp(cam.orthographicSize - zoomDelta, minZoom, maxZoom);
            cam.orthographicSize = newOrthoSize;
        }
    }
}

