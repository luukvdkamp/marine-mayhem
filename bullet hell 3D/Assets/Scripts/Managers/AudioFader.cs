using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public SoundClip clip;
    [Tooltip("This is a temporary toggle to be replaced by a trigger event")]public bool tempToggle;
    [Tooltip("If toggled audio will fade in instead of fade out")]public bool fadeIn;

    [Tooltip("The duration of the fade. Example: if the value is 1 it will take 1 second to fade out")] public float fadeDuration;

    public AnimationCurve fadeCurve = AnimationCurve.Linear(0, 0, 1, 1);

    float s_FadeOut = 0.0f;
    float s_FadeIn = 1.0f;

    float s_OriginalValue;
    float s_CurrentValue;

    private void Start()
    {
        s_OriginalValue = clip.volume;
        s_CurrentValue = s_OriginalValue;
    }

    private void Update()
    {
        if(tempToggle)
        {
            tempToggle = false;
            Fade();
        }

        clip.volume = s_CurrentValue;
        AudioManager.instance.UpdateAudio(clip);
    }

    public void Fade()
    {
        StartCoroutine(FadeValue());
    }

    IEnumerator FadeValue()
    {
        float s_Time = 0.0f;

        while(s_Time < fadeDuration)
        {
            if(fadeIn)
            {
                float progress = s_Time / fadeDuration;
                s_CurrentValue = Mathf.Lerp(s_FadeOut, s_FadeIn, fadeCurve.Evaluate(progress));

                s_Time += Time.deltaTime;
            }
            else
            {
                float progress = s_Time / fadeDuration;
                s_CurrentValue = Mathf.Lerp(s_FadeIn, s_FadeOut, fadeCurve.Evaluate(progress));

                s_Time += Time.deltaTime;
            }

            yield return null;
        }

        if(fadeIn)
        {
            s_CurrentValue = s_FadeIn;
        }else
        {
            s_CurrentValue = s_FadeOut;
        }
    }
}
