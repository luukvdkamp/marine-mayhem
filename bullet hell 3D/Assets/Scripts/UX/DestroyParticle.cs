using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public float lifeTime;
    private float lifeCounter;
    void Update()
    {
        lifeCounter += Time.deltaTime;
        if(lifeCounter > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
