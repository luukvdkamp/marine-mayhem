using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public SoundClip calmMusic;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //AudioManager.instance.FadeClip(null, calmMusic);

            SceneManager.LoadScene(0);
        }
    }
}
