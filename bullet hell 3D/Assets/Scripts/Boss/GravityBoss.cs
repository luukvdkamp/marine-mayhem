using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBoss : MonoBehaviour
{
    public float jumpSpeed;
    public float minJumpTime;
    public float maxJumpTime;

    private float randomJumpTime;
    private float jumpCounter;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomJumpTime = Random.Range(minJumpTime, maxJumpTime);
    }

    void Update()
    {
        jumpCounter += Time.deltaTime;
        if (jumpCounter > randomJumpTime)
        {
            Vector3 randomDirection = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1, 1f),
                Random.Range(-1f, 1f)
            );

            randomDirection.Normalize();

            rb.AddForce(randomDirection * jumpSpeed, ForceMode.Impulse);

            jumpCounter = 0;
            randomJumpTime = Random.Range(minJumpTime, maxJumpTime);
        }
    }
}
