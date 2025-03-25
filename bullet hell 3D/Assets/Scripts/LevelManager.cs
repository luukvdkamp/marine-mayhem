using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level[] levelsUnlocked; // all level scripts
    public static LevelManager Instance;

    public bool unlockNextLevel; // make code unlock new level
    private int levelCount; // current levels unlocked
    private Finish currentFinish; // save the finish trigger in current level
    public int overworldScene;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //unlock lvl 1
        unlockNextLevel = true;

        currentFinish = FindAnyObjectByType<Finish>();
    }

    private void Update()
    {
        //gets activated when level finished
        if(unlockNextLevel)
        {
            levelsUnlocked[levelCount].isUnlocked = true;
            levelCount++;
            unlockNextLevel = false;
        }


        if(currentFinish.levelFinished)
        {
            unlockNextLevel = true;
            currentFinish.levelFinished = false;

            SceneManager.LoadScene(overworldScene);
        }
    }
}
