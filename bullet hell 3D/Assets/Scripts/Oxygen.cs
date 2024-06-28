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

    private void Start()
    {
        currentOxygen = secondsToReachFinish;
    }

    void Update()
    {
        currentOxygen -= Time.deltaTime;

        // Calculate the fill amount for the oxygen meter
        float fillAmount = Mathf.Clamp01(currentOxygen / secondsToReachFinish);
        oxygenMeter.fillAmount = fillAmount;

        if (currentOxygen <= 0)
        {
            playerHealth.noOxygen = true;
        }

        if(currentOxygen < secondsToReachFinish/4 && hasStartedFading == false) // 1/4 deel van de oxygen over
        {
            StartCoroutine(FadeToBlackAndTransparent());
            hasStartedFading = true;
        }
    }

    IEnumerator FadeToBlackAndTransparent()
    {
        while (true) // Loop indefinitely
        {
            float timer = 0f;
            Color startColor = imageToFade.color;
            Color endColor = new Color(0f, 0f, 0f, 1f); // Fade to black
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                imageToFade.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
                yield return null;
            }

            // After fading to black, reset the timer and fade back to fully transparent
            timer = 0f;
            startColor = endColor; // Start from the black color
            endColor = new Color(0f, 0f, 0f, 0f); // Fully transparent
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                imageToFade.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
                yield return null;
            }
        }
    }
}
