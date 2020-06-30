using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    [Range(25,500)]
    public float accel;
    [Range(50, 200)]
    public float rotAccel;
    [Range(0, 15)]
    public float maxVel;
    [Range(0, 15)]
    public float baseSpeed;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //acquire left/right, and updown input. No need to normalize it since it's a standard input already from 0:1
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        //accelerate forwards relative to player transform
        rb.AddRelativeForce(new Vector3(0,0, baseSpeed) * accel * Time.deltaTime * rb.mass);

        //allow turning
        rb.AddRelativeTorque(new Vector3(0, Input.GetAxisRaw("Horizontal"), 0) * rotAccel * Time.deltaTime * rb.mass);
        

        //limit speed in all directions
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);

        //old stuff:
        //rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position * moveSpeed * Time.deltaTime);
        // rb.velocity += Vector3.forward * baseSpeed;

    }
}
