using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStop : MonoBehaviour
{
    public string colliderTag = "collider";
    public float distanceThreshold = 1f;
    public float pushForce = 5f;

    public bool wasWithinDistance;
    public Vector3 pushDirection;
    public MovementSwitch movementSwitch;

    private void FixedUpdate()
    {
        bool isWithinDistance = false;

        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceThreshold);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(colliderTag) && movementSwitch.inGang == false)
            {
                Vector3 closestPoint = collider.ClosestPoint(transform.position);
                Vector3 direction = transform.position - closestPoint;
                float distance = direction.magnitude;

                if (distance < distanceThreshold)
                {
                    print("pushing");
                    pushDirection = direction.normalized;
                    GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
                    isWithinDistance = true;
                }
            }
        }

        // Check if the player was previously within distance and is no longer
        if (wasWithinDistance && !isWithinDistance)
        {
            // Player moved away from the collider
            wasWithinDistance = false;
        }
        else
        {
            wasWithinDistance = isWithinDistance;
        }
    }
}
