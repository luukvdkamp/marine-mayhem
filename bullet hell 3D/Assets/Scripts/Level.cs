using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public float distance;
    public Transform boat;
    public GameObject text;
    public int scene;
    void Update()
    {
        if(Vector3.Distance(transform.position, boat.position) < distance)
        {
            GetComponent<Image>().enabled = true;
            text.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(scene);
            }
        }

        else
        {
            GetComponent<Image>().enabled = false;
            text.SetActive(false);
        }
    }
}
