using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    public float lifeTime;
    public float upOffsetRadius;
    public float speed;
    public GameObject soundEffectPop;

    [Header("Don't change these values")] //changed by OxygenGiver
    public int amountOfOxygen;
    public Oxygen oxygen;

    void Update()
    {
        Destroy(gameObject, lifeTime);

        GetComponent<Rigidbody>().AddForce(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            oxygen.currentOxygen += amountOfOxygen;
            Instantiate(soundEffectPop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
