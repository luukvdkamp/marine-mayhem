using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float jumpSpeed = 5f;

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
        Vector3 targetPosition = startPosition + Vector3.up * jumpHeight;
        StartCoroutine(JumpRoutine(targetPosition));
    }

    IEnumerator JumpRoutine(Vector3 targetPosition)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;

        while (Time.time < startTime + jumpSpeed)
        {
            float t = (Time.time - startTime) / jumpSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition;
        yield return new WaitForSeconds(0.1f);

        //jump back to the ground
        startTime = Time.time;
        while (Time.time < startTime + jumpSpeed)
        {
            float t = (Time.time - startTime) / jumpSpeed;
            transform.position = Vector3.Lerp(targetPosition, startPosition, t);
            yield return null;
        }

        transform.position = startPosition;
        isJumping = false;
    }
}
