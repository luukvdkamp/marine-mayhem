using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{
    public int sceneToLoad;
    public void StartButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
