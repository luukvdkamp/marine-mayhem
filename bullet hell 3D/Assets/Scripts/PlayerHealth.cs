using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Image healthImage;
    public TextMeshProUGUI textNumber;
    public int textInt;
    public float health;

    public bool hit;

    public float resetTime;
    private float resetCounter;

    public AudioSource ouch;
    void Update()
    {
        textNumber.text = textInt.ToString();
        healthImage.fillAmount = health;

        resetCounter += Time.deltaTime;

        if(hit)
        {
            health -= 0.25f;
            textInt--;

            ouch.Play();

            resetCounter = 0;
            hit = false;
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
}
