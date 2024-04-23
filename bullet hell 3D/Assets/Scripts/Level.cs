using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
    public float distance;
    public Transform boat;
    void Update()
    {
        if(Vector3.Distance(transform.position, boat.position) < distance)
        {
            GetComponent<Image>().enabled = true;
        }

        else
        {
            GetComponent<Image>().enabled = false;
        }
    }
}
