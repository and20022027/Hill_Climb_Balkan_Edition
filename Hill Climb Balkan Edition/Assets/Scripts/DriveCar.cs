using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public Rigidbody2D frontTireRB;
    public Rigidbody2D backTireRB;
    public Rigidbody2D carRB;
    public float speed = 150f; 
    private float rotationspeed = 2000f;

    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
        void FixedUpdate()
    {
        frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carRB.AddTorque(moveInput * rotationspeed * Time.fixedDeltaTime);


    }
}