using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public SceneFader sceneFader;
    public string menuSceneName = "Main Menu";

    

    public void Retry()
    {
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        // Debug.Log("Go to menu");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
