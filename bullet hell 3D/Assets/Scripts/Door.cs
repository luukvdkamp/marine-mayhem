using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opening;
    public float openingSpeed;
    public float lifeTime;

    void Update()
    {
        if(opening)
        {
            transform.Translate(transform.up * openingSpeed * Time.deltaTime);
            Destroy(gameObject, lifeTime);
        }
    }
}
