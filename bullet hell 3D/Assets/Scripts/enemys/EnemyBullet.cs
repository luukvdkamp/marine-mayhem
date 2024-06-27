using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    
    public GameObject bulletSender; //for boss bullets

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().hit = true;
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag == "collider")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "enemy")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }

        //player reflected bullet
        else if (collision.gameObject.tag == "boss")
        {
            collision.gameObject.GetComponent<Boss>().isHit = true;
            collision.gameObject.GetComponent<Boss>().bulletDamage = 1;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().hit = true;
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "collider")
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "enemy")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
        }
    }
}
