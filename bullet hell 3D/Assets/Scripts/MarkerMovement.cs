using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMovement : MonoBehaviour
{
    public float hoverSpeed = 1.0f; // Speed of the hover effect
    public float maxHeight = 1.0f; // Maximum height of the hover

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * maxHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
