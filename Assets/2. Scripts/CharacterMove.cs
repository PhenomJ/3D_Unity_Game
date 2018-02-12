﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    const float gravityPower = 9.8f;
    const float StoppingDistance = 0.6f;

    Vector3 velocity = Vector3.zero;
    CharacterController characterController;

    public bool arrived = false;
    bool forceRotate = false;

    Vector3 forceRotationDirection;

    public Vector3 destination;

    public float moveSpeed = 6.0f;

    public float rotationSpeed = 360.0f;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        destination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (characterController.isGrounded)
        {
            Vector3 destinationXZ = destination;
            destinationXZ.y = transform.position.y;

            Vector3 direction = (destinationXZ - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, destinationXZ);

            Vector3 currentVelocity = velocity;

            if (arrived || distance < StoppingDistance)
            {
                arrived = true;
            }

            if (arrived)
                velocity = Vector3.zero;

            else
                velocity = direction * moveSpeed;

            velocity = Vector3.Lerp(currentVelocity, velocity, Mathf.Min(Time.deltaTime * 5.0f, 1.0f));
            velocity.y = 0;

            if (!forceRotate)
            {
                if (velocity.magnitude > 0.1f && !arrived)
                {
                    Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
                }
            }

            else
            {
                Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        velocity += Vector3.down * gravityPower * Time.deltaTime;

        Vector3 snapGround = Vector3.zero;

        if (characterController.isGrounded)
            snapGround = Vector3.down;

        characterController.Move(velocity * Time.deltaTime + snapGround);

        if (characterController.velocity.magnitude < 0.1f)
            arrived = true;

        if (forceRotate && Vector3.Dot(transform.forward, forceRotationDirection) > 0.99f)
            forceRotate = false;
	}

    public void SetDestination(Vector3 destination)
    {
        arrived = false;
        this.destination = destination;
    }

    public void SetDirection (Vector3 direction)
    {
        forceRotationDirection = direction;
        forceRotationDirection.y = 0;
        forceRotationDirection.Normalize();
        forceRotate = true;
    }

    public void StopMove()
    {
        destination = transform.position;
    }

    public bool Arrived()
    {
        return arrived;
    }
}
