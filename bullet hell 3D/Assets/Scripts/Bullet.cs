using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        Destroy(gameObject, 7);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "boss")
        {
            collision.gameObject.GetComponent<Boss>().isHit = true;
            Destroy(gameObject);
        }
    }
}
