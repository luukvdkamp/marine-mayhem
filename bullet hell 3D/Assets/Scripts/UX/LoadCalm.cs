using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCalm : MonoBehaviour
{
    public SoundClip calmMusic;
    public SoundClip bossMusic;
    
    void Start()
    {
        AudioManager.instance.FadeClip(calmMusic, null);
    }

    //when there is no boss when the player spawns, no music will play until it reaches the boss, so here is a solution
}
