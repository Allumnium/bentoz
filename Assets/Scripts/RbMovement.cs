using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovement : MonoBehaviour
{
	public float speed = 10.0f;
	public Rigidbody rb;
	public Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     	movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
    	moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
    	// Use when we want to do something that involves drag, friction, and gravity
    	// Nice for slippery surfaces, wheels etc:
    	
    	// rb.AddForce(direction * speed);

    	// Velocity is used for constant speed
    	// rb.velocity(direction * speed);

    	// move position allows you to move an object to an exact position.
    	rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }
}
