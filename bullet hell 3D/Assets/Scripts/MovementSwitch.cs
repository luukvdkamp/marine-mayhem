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

    public GameObject submarine;

    public ColliderStop colliderStop;

    [Header("3DMovement")]
    public float sensitivity = 100f;
    public GameObject threeD;
    public float downSpeedThree;
    public float speedThree;

    [Header("2DMovement")]
    public Transform lookPosition;
    public float horizontalSpeed;
    public float verticalSpeed;
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
        if(inGang == false)
        {
            cdtwo.SetActive(false);
            cdthree.SetActive(true);
            submarine.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            // Rotate the camera around the y-axis based on mouse X movement
            transform.Rotate(Vector3.up * mouseX);

            // Rotate the camera around the x-axis based on mouse Y movement
            transform.Rotate(Vector3.left * mouseY);

            float upMovement = Input.GetAxis("Vertical") * speedThree * Time.deltaTime;
            transform.Translate(transform.forward * upMovement, Space.World);

            float sideMovement = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * sideMovement * speedThree * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * downSpeedThree * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * downSpeedThree * Time.deltaTime);
            }

            //reset velocity when not moving
            else if (upMovement == 0 && sideMovement == 0 && colliderStop.wasWithinDistance == false)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                print("stopping");
            }
        }

        //2D
        else
        {
            cdtwo.SetActive(true);
            cdthree.SetActive(false);
            submarine.SetActive(true);
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
            transform.Translate(transform.forward * upMovement * horizontalSpeed * Time.deltaTime, Space.World);

            float sideMovement = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * sideMovement * horizontalSpeed * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
            }

            //reset velocity when not moving
            else if (upMovement == 0 && sideMovement == 0 && colliderStop.wasWithinDistance == false)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                print("movementstopping");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gang")
        {
            inGang = true;
            print("triggerworking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "gang")
        {
            inGang = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }


}
