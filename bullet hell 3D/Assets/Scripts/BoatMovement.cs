using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed * verticalSpeed * Time.deltaTime);

        GetComponent<Rigidbody>().AddForce(-Vector3.right * speed * horizontalSpeed * Time.deltaTime);

        if(horizontalSpeed == 0 && verticalSpeed == 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
