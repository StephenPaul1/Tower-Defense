using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string LeveltoLoad = "SampleScene";
    public SceneFader sceneFader;
    public void Play()
    {

        sceneFader.FadeTo(LeveltoLoad);
      //  SceneManager.LoadScene(LeveltoLoad);
    
    }


    public void Quit()
    { 
    Debug.Log("Quit");
        Application.Quit();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
