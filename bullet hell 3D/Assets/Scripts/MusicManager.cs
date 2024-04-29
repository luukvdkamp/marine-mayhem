using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource battle;
    public AudioSource ambient;
    public MovementSwitch movementSwitch;

    void Update()
    {
        if(movementSwitch.inGang)
        {
            //ambient
            if(battle.isPlaying)
            {
                battle.Stop();
            }

            if(ambient.isPlaying == false)
            {
                ambient.Play();
            }
        }

        else
        {
            //battle
            if (ambient.isPlaying)
            {
                ambient.Stop();
            }

            if (battle.isPlaying == false)
            {
                battle.Play();
            }
        }
    }
}
