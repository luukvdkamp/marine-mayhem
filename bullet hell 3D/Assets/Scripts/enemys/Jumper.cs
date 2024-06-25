using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float jumpDuration = 1f; // Total time to complete the jump (up and down)

    private Vector3 startPosition;
    private bool isJumping = false;
    private float jumpCounter;
    public float jumpTime;

    public ParticleSystem jumpDirt;

    void Start()
    {
        startPosition = transform.position;
        jumpCounter = jumpTime;
    }

    void Update()
    {
        jumpCounter -= Time.deltaTime;

        if (jumpCounter <= 0f && !isJumping)
        {
            Jump();
            jumpCounter = jumpTime; //reset jump timer
            jumpDirt.Play();
        }
    }

    void Jump()
    {
        isJumping = true;
        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        float gravity = 2 * jumpHeight / (jumpDuration / 2 * jumpDuration / 2);
        float initialVelocity = gravity * (jumpDuration / 2);
        float startTime = Time.time;

        while (Time.time < startTime + jumpDuration)
        {
            float elapsed = Time.time - startTime;
            float t = elapsed < jumpDuration / 2 ? elapsed : jumpDuration - elapsed;
            float y = initialVelocity * t - 0.5f * gravity * t * t;
            transform.position = startPosition + Vector3.up * y;
            yield return null;
        }

        transform.position = startPosition;
        isJumping = false;
    }
}
