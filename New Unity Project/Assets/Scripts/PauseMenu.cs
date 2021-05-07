using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
     public SceneFader sceneFader;
     public string menuSceneName;
    public string LeveltoLoad = "Main Menu";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        
        }
    }


    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);


        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        
        }
    }
    public void Retry()
    {
        Toggle();
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //  sceneFader.FadeTo("SampleScene");
        //DOMT DO SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        //  Debug.Log("Go to Menu");
        sceneFader.FadeTo("Main Menu");

    }
}
