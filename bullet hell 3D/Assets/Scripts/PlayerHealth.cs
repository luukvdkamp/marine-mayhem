using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
    [Space]
    public SoundClip calm;
    public SoundClip battle;

    [Header("GameOver")]
    public float fadeDuration; // Duration of the fade effect
    private float fadeTimer = 0f;
    public bool noOxygen; //check oxygen code

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

        if (textInt <= 0 || noOxygen)
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

        
        if(AudioManager.instance.SeekClip("Fight1").volume > 0)
        {
            AudioManager.instance.FadeClip(null, battle);
        }

        if(AudioManager.instance.SeekClip("Calm1").volume > 0)
        {
            AudioManager.instance.FadeClip(null, calm);
        }

        SceneManager.LoadScene(0);
    }
}
