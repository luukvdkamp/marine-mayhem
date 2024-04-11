using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isLit;
    public Light lightSource;
    void Update()
    {
        if(isLit && Input.GetKeyDown(KeyCode.F))
        {
            lightSource.enabled = false;
            isLit = false;
            GetComponent<AudioSource>().Play();
        }

        else if(isLit == false && Input.GetKeyDown(KeyCode.F))
        {
            lightSource.enabled = true;
            isLit = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
