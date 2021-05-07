using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "Main Menu";
    public SceneFader sceneFader;
    public string nextLevel = "SampleScene 1";
    public int LeveltoUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("LevelReached", LeveltoUnlock);
        sceneFader.FadeTo(nextLevel);

    
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
