using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isHit;
    public GameObject door;

    void Update()
    {
        if(isHit)
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }
}
