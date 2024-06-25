using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed;
    public float slowDownDrag;
    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed * verticalSpeed * Time.deltaTime);

        GetComponent<Rigidbody>().AddForce(-Vector3.right * speed * horizontalSpeed * Time.deltaTime);

        if(horizontalSpeed == 0 && verticalSpeed == 0)
        {
            GetComponent<Rigidbody>().drag = slowDownDrag;
        }

        else
        {
            GetComponent<Rigidbody>().drag = 0;
        }
    }
}
