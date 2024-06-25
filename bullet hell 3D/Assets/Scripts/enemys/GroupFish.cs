using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupFish : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float distance;
    private bool attack;
    public float lifeTime;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < distance)
        {
            attack = true;
        }

        if(attack)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
            Destroy(gameObject, lifeTime);
        }
    }
}
