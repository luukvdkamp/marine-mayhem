using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour
{
    public float movementSpeed;

    void Update()
    {
        // Calculate movement direction
        Vector3 movementDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")).normalized;

        // Rotate the empty object to face the movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * movementSpeed);
        }
    }
}
