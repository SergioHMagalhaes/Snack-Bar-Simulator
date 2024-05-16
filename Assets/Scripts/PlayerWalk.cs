using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

	public Transform player;

	public Camera playerCamera;

	public float walkSpeed = 5f;
	public float maxVelocityChange = 10f;


	private Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 targetDirection = (forward * inputVertical + right * inputHorizontal).normalized;

        Vector3 targetVelocity = targetDirection * walkSpeed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = targetVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
