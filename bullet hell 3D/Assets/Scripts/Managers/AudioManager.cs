using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public SoundClip[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (SoundClip s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.originalVolume = s.volume;
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.group;

            if (s.startSilent)
            {
                s.volume = 0;
            }

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

            if (s.source.playOnAwake)
            {
                s.source.Play();
            }
        }

    }

    public void UpdateAudio(SoundClip clip)
    {
        clip.source.volume = clip.volume;
    }

    public void PlayClip(string name)
    {
        SoundClip s = Array.Find(sounds, sound => sound.clipName == name);

        if (s == null)
        {
            Debug.LogError("Error, Couldn't find clip.");
            return;
        }

        s.source.Play();
    }

    public void StopClip(string name)
    {
        SoundClip s = Array.Find(sounds, sound => sound.clipName == name);

        if (s == null)
        {
            Debug.LogError("Error, Couldn't find clip.");
            return;
        }

        s.source.Stop();
    }

    public void FadeClip(SoundClip fadeInClip = null, SoundClip fadeOutClip = null)
    {
        AudioFader fader = gameObject.AddComponent<AudioFader>();
        fader.Fade(fadeInClip, fadeOutClip);
    }

    public SoundClip SeekClip(string name)
    {
        return Array.Find(sounds, sound => sound.clipName == name);
    }
}