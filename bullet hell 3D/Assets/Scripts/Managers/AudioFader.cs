using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public AnimationCurve fadeCurve = AnimationCurve.Linear(0, 0, 1, 1);

    List<FadeData> s_FadeQueue = new List<FadeData>();
    float s_FadeDuration;

    private void Update()
    {
        if(s_FadeQueue.Count > 0)
        {
            for (int i = 0; i < s_FadeQueue.Count; i++)
            {
                s_FadeQueue[i].clip.volume = s_FadeQueue[i].currentValue;
                AudioManager.instance.UpdateAudio(s_FadeQueue[i].clip);
            }
        }
    }

    public void Fade(SoundClip clipToFadeIn, SoundClip clipToFadeOut, float fadeDuration = 2, float fadeOutLevelOverride = 0)
    {
        s_FadeDuration = fadeDuration;

        s_FadeQueue.Clear();

        s_FadeQueue.Add(new FadeData(clipToFadeIn, clipToFadeIn.originalVolume, 0, true));
        s_FadeQueue.Add(new FadeData(clipToFadeOut, clipToFadeOut.originalVolume, fadeOutLevelOverride, false));

        for (int i = 0; i < s_FadeQueue.Count; i++)
        {
            StartCoroutine(FadeValue(s_FadeQueue[i]));
        }

        //StartCoroutine(FadeValue());
    }

    IEnumerator FadeValue(FadeData data)
    {
        float s_Time = 0.0f;

        while(s_Time < s_FadeDuration)
        {
            if(data.shouldFadeIn)
            {
                float progress = s_Time / s_FadeDuration;
                data.currentValue = Mathf.Lerp(data.fadeOut, data.fadeIn, fadeCurve.Evaluate(progress));

                s_Time += Time.deltaTime;
            }else
            {
                float progress = s_Time / s_FadeDuration;
                data.currentValue = Mathf.Lerp(data.fadeIn, data.fadeOut, fadeCurve.Evaluate(progress));

                s_Time += Time.deltaTime;
            }

            yield return null;
        }

        if(data.shouldFadeIn)
        {
            data.currentValue = data.fadeIn;
            AudioManager.instance.UpdateAudio(data.clip);
        }
        else
        {
            data.currentValue = data.fadeOut;
            AudioManager.instance.UpdateAudio(data.clip);
        }

        Destroy(this);
    }
}

public class FadeData
{
    public SoundClip clip;

    [Tooltip("The volume level the manager should move towards when fading in. This should be equal to the original volume level of the SoundClip")]public float fadeIn;
    [Tooltip("The volume level the manager should move towards when fading out. This value should be 0 unless you want to keep hearing the audio")] public float fadeOut;
    [Tooltip("The value the fade in is currently on")]public float currentValue;

    [Tooltip("If toggeled the manager will fade the audio in instead of out")]public bool shouldFadeIn;

    public FadeData(SoundClip s_Clip, float s_FadeIn, float s_FadeOut, bool s_ShouldFadeIn)
    {
        clip = s_Clip;
        fadeIn = s_FadeIn;
        fadeOut = s_FadeOut;
        shouldFadeIn = s_ShouldFadeIn;
    }
}
