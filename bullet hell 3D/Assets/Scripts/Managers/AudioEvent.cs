using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    public SoundClip fadeInClip;
    public SoundClip fadeOutClip;

    public float fadeTimeOverride = 2;
    public float fadeOutOverride = 0;

    private void Start()
    {
        AudioFader fader = gameObject.AddComponent<AudioFader>();
        fader.Fade(fadeInClip, fadeOutClip, fadeTimeOverride);
    }
}
