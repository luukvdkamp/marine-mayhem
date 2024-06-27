using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int bulletDamage;
    public GameObject explosionParticle;
    public GameObject soundEffectWhenShoot;

    private void Start()
    {
        Instantiate(soundEffectWhenShoot, transform.position, Quaternion.identity);
    }

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
            collision.gameObject.GetComponent<Boss>().bulletDamage = bulletDamage;

            //explosion particle
            GameObject explosionPrefab = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);

            //explosion particle
            GameObject explosionPrefab = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ignoring collision with player.");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }

        else if (collision.gameObject.tag == "bossBullet")
        {
            collision.transform.LookAt(collision.gameObject.GetComponent<EnemyBullet>().bulletSender.transform.position);
        }

        else
        {
            //explosion particle
            GameObject explosionPrefab = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
