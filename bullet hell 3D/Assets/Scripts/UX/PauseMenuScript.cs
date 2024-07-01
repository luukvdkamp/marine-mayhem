using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    public AudioSource buttonClick;

    public KeyCode pauseKey;

    public MovementSwitch movementSwitch;
    public bool inOverworld; //change in editor
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        buttonClick.Play();
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false); //set ook dit menu uit - Niek
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameIsPaused = false;

        if(inOverworld == false)
        {
            movementSwitch.inMenu = false;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        buttonClick.Play();
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameIsPaused = true;

        if (inOverworld == false)
        {
            movementSwitch.inMenu = true;
        }
    }
    public void ReturnToMenu()
    {
        buttonClick.Play();
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Main Menu");

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //FindObjectOfType<AudioManager>().Play("DefenceSetupMusic");
    }
}
