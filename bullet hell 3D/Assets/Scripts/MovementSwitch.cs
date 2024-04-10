using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSwitch : MonoBehaviour
{
    [Header("CamPosition")]
    public Transform camPosition;

    public Transform twoDPosition;
    public Transform threeDPosition;

    [Header("2DMovement")]
    public float forwardSpeed;
    public float sideSpeed;

    [Header("3DMovement")]
    public Transform lookPosition;
    public float moveSpeed;

    public float maxYRotation;
    public float maxZRotation;

    public bool inGang;
    void Update()
    {
        if(inGang)
        {
            //move sideways
            float sideMovement = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * sideMovement * sideSpeed * Time.deltaTime);

            //forward
            if(Input.GetKey(KeyCode.LeftShift))
            {
                float forwardMovement = Input.GetAxis("Vertical");
                transform.Translate(transform.forward * forwardMovement * forwardSpeed * Time.deltaTime);
            }

            //down and up
            else
            {
                float upMovement = Input.GetAxis("Vertical");
                transform.Translate(Vector3.up * upMovement * sideSpeed * Time.deltaTime);
            }

        }

        else
        {
            //get the mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 4;
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPosition.position = targetPos;

            //look at mouse position
            transform.LookAt(targetPos);

            //move forward and backwards
            float forward = Input.GetAxis("Vertical");
            transform.Translate(transform.forward * forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "gang")
        {
            inGang = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "gang")
        {
            inGang = false;
        }
    }
}
