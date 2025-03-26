using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level[] levelsUnlocked; // all level scripts
    public GameObject[] levelLockedBanners;

    public LevelDataSaver levelDataSaver;
    private int currentLevel;

    private void Update()
    {
        if(levelDataSaver == null)
        {
            levelDataSaver = FindAnyObjectByType<LevelDataSaver>();
        }

        //gets activated when level finished
        if(currentLevel != levelDataSaver.currentLevel || currentLevel == 0)
        {
            currentLevel = levelDataSaver.currentLevel;

            levelsUnlocked[currentLevel].isUnlocked = true;
            levelLockedBanners[currentLevel].SetActive(false);
        }
        
    }
}
