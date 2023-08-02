using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody targetRigidbody;  // Reference to the Rigidbody of the object you want to track
    public Text speedText;  // Reference to the UI Text element

    private void Update()
    {
        if (targetRigidbody != null)
        {
            float speed = targetRigidbody.velocity.magnitude;
            speedText.text = "Speed: " + speed.ToString("F2") + " units/s"; // Format speed to two decimal places
        }
    }
}
