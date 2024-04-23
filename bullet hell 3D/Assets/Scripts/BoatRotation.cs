using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody r;

    void Update()
    {
        // Calculate movement direction
        Vector3 movementDirection = r.velocity;

        // Rotate the empty object to face the movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * movementSpeed);
        }
    }
}
