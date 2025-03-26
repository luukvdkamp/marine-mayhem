using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataSaver : MonoBehaviour
{
    public int currentLevel;
    private Finish currentFinish; // save the finish trigger in current level
    public int overworldScene;

    private int amountOfScripts;
    private LevelDataSaver scriptToNotDestroy;

    [HideInInspector]
    public int lifespanScriptCounter;

    private void Awake()
    {
        LevelDataSaver[] allScripts = FindObjectsOfType<LevelDataSaver>();

        // check all scripts
        foreach (LevelDataSaver script in allScripts)
        {
            amountOfScripts++;

            if(script.lifespanScriptCounter != 0)
                scriptToNotDestroy = script;
                
        }

        // destroy all scripts except old one
        if(amountOfScripts > 1)
        {
            foreach (LevelDataSaver script in allScripts)
            {
                if (script != scriptToNotDestroy)
                    Destroy(script);

            }

            amountOfScripts = 0;
        }

        lifespanScriptCounter++;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        //prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // find finish in level scene
        currentFinish = FindAnyObjectByType<Finish>();
    }

    private void Update()
    {
        if (currentFinish != null)
        {

            print("found code");
            if (currentFinish.levelFinished)
            {
                print("change scene");
                currentFinish.levelFinished = false;
                currentFinish = null;
                currentLevel++;

                SceneManager.LoadScene(overworldScene);
            }
        }
    }
}
