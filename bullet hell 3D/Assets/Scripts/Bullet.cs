using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public AudioSource bulletSpawn;
    private GameObject prefabToDestroy;

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
            //collision.gameObject.GetComponent<AudioSource>().Play(); sound overneemt open deur sound
            GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            prefabToDestroy = collision.gameObject;

            Invoke("DestroyGameObject", 2f);
        }

        else if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            prefabToDestroy = collision.gameObject;

            Invoke("DestroyGameObject", 2f);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
        Destroy(prefabToDestroy);
    }
}
