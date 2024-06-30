using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    public int secondsToReachFinish;
    public float currentOxygen;
    public PlayerHealth playerHealth;

    [Header("UI")]
    public Image oxygenMeter;
    public Image imageToFade;
    public float fadeDuration = 1f;
    private bool hasStartedFading;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        currentOxygen = secondsToReachFinish;
    }

    void Update()
    {
        currentOxygen -= Time.deltaTime;

        //calculate fill amount for the oxygen meter
        float fillAmount = Mathf.Clamp01(currentOxygen / secondsToReachFinish);
        oxygenMeter.fillAmount = fillAmount;

        if (currentOxygen <= 0)
        {
            playerHealth.noOxygen = true;
        }

        if (currentOxygen < secondsToReachFinish / 4)
        {
            if (!hasStartedFading)
            {
                fadeCoroutine = StartCoroutine(FadeToBlackAndTransparent());
                hasStartedFading = true;
            }
        }
        else
        {
            if (hasStartedFading)
            {
                StopCoroutine(fadeCoroutine);
                imageToFade.color = new Color(0f, 0f, 0f, 0f); //reset to fully transparent
                hasStartedFading = false;
            }
        }
    }

    IEnumerator FadeToBlackAndTransparent()
    {
        while (true)
        {
            float timer = 0f;
            Color startColor = imageToFade.color;
            Color endColor = new Color(0f, 0f, 0f, 1f);
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                imageToFade.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
                yield return null;
            }

            //reset the timer and fade to transparent
            timer = 0f;
            startColor = endColor;
            endColor = new Color(0f, 0f, 0f, 0f);
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                imageToFade.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
                yield return null;
            }
        }
    }
}