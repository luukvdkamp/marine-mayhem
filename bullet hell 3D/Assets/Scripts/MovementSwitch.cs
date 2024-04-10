using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovementSwitch : MonoBehaviour
{
    [Header("CamPosition")]
    public Transform camPosition;

    public GameObject cdtwo;
    public GameObject cdthree;

    [Header("3DMovement")]
    public float sensitivity = 100f;
    public GameObject threeD;
    public float downSpeedThree;
    public float speedThree;

    [Header("2DMovement")]
    public Transform lookPosition;
    public float moveSpeed;
    public float downSpeed;
    public float rotationSpeed;
    public float minDistanceFromCenter;
    public Quaternion targetRotation;
    public bool inGang;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inGang)
            {
                inGang = false;
            }

            else
            {
                inGang = true;
            }
        }

        //3D
        if(inGang)
        {
            cdtwo.SetActive(false);
            cdthree.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            // Rotate the camera around the y-axis based on mouse X movement
            transform.Rotate(Vector3.up * mouseX);

            // Rotate the camera around the x-axis based on mouse Y movement
            transform.Rotate(Vector3.left * mouseY);

            float upMovement = Input.GetAxis("Vertical") * speedThree * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-Vector3.down * upMovement * downSpeedThree * Time.deltaTime);
            }

            else
            {
                transform.Translate(transform.forward * upMovement, Space.World);
            }

            float sideMovement = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * sideMovement * speedThree * Time.deltaTime, Space.World);
        }

        //2D
        else
        {
            cdtwo.SetActive(true);
            cdthree.SetActive(false);
            GetComponent<MeshRenderer>().enabled = true;
            Cursor.lockState = CursorLockMode.None;

            // Get the mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 4;
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPosition.position = targetPos;

            // Calculate distance from the center of the screen
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            float distanceFromCenter = Vector3.Distance(mousePos, screenCenter);

            // Check if the mouse is within the maximum distance from the center
            if (distanceFromCenter > minDistanceFromCenter)
            {
                // Calculate rotation towards the target position
                targetRotation = Quaternion.LookRotation(targetPos - transform.position);

                // Smoothly rotate towards the target rotation
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            else
            {
                // Calculate rotation towards the target position
                targetRotation = Quaternion.Euler(0, -270, transform.rotation.z);

                // Smoothly rotate towards the target rotation
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            float upMovement = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-Vector3.down * upMovement * downSpeed * Time.deltaTime);
            }

            else
            {
                transform.Translate(transform.forward * upMovement * moveSpeed * Time.deltaTime, Space.World);
            }

            float sideMovement = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * sideMovement * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gang")
        {
            inGang = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "gang")
        {
            inGang = false;
        }
    }

 
}
