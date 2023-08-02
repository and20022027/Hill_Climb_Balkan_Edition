using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1.0f; // Adjust this to control zoom speed
    public float minZoom = 1.0f;   // Minimum orthographic size (zoomed out)
    public float maxZoom = 10.0f;  // Maximum orthographic size (zoomed in)

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        float zoomDelta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newOrthoSize = Mathf.Clamp(cam.orthographicSize - zoomDelta, minZoom, maxZoom);
        cam.orthographicSize = newOrthoSize;
    }
}