using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int textInt;
    public float health;

    public bool hit;

    public float resetTime;
    private float resetCounter;

    [Header("UI")]
    public Image healthImage;
    public TextMeshProUGUI textNumber;
    public Image deathImage;

    [Header("Audio")]
    public AudioSource ouch;
    public AudioSource dead;

    [Header("GameOver")]
    public float fadeDuration; // Duration of the fade effect
    private float fadeTimer = 0f;

    void Update()
    {
        textNumber.text = textInt.ToString();
        healthImage.fillAmount = health;

        resetCounter += Time.deltaTime;

        //if hit
        if(hit)
        {
            health -= 0.25f;
            textInt--;

            if(textInt != 0)
            {
                ouch.Play();
            }

            resetCounter = 0;
            hit = false;
        }

        if (textInt <= 0)
        {
            StartCoroutine(DeathTransition());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "boss" || collision.gameObject.tag == "enemy")
        {
            if(resetCounter > resetTime)
            {
                hit = true;
            }
        }
    }

    //UX
    IEnumerator DeathTransition()
    {
        //dead.Play();
        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float alpha = fadeTimer / fadeDuration;
            deathImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        SceneManager.LoadScene(0);
    }
}
