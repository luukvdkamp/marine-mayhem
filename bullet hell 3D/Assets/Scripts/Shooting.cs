using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fastBullet;

    public float fastBulletTime;
    private float fastBulletCounter;
    private bool isFiring;
    public Slider chargeFastBulletSlider;
    public GameObject chargeSliderVisibilityObject;

    private float cooldownCounter;
    public float cooldown;
    private Transform shootPosition;
    public Transform shootPositionTwoD;
    public Transform shootPositionThreeD;

    private void Start()
    {
        chargeFastBulletSlider.maxValue = fastBulletTime;
        chargeSliderVisibilityObject.SetActive(false);
    }

    void Update()
    {
        cooldownCounter += Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownCounter > cooldown)
        {
            fastBulletCounter += Time.deltaTime;
            chargeSliderVisibilityObject.SetActive(true);
            chargeFastBulletSlider.value += Time.deltaTime;
            isFiring = true;


        }

        if(Input.GetButtonUp("Fire1") && isFiring)
        {
            if (fastBulletCounter < fastBulletTime)
            {
                GameObject prefabBullet = Instantiate(bullet, shootPosition.position, transform.localRotation);
            }

            else
            {
                GameObject prefabFastBullet = Instantiate(fastBullet, shootPosition.position, transform.localRotation);
            }
            isFiring = false;
            cooldownCounter = 0;
            fastBulletCounter = 0;
            chargeFastBulletSlider.value = 0;
            chargeSliderVisibilityObject.SetActive(false);
        }

        //change shoot position
        if(GetComponent<MovementSwitch>().inGang)
        {
            shootPosition = shootPositionTwoD;
        }

        else
        {
            shootPosition = shootPositionThreeD;
        }
    }
}
