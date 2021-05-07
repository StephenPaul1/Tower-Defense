using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour

{
    public TurrentBluePrint standardTurrent;
    public TurrentBluePrint missileLauncher;
    public TurrentBluePrint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurrent ()
    {

        Debug.Log("Standard Turrent Purchase");
        buildManager.SelectTurrentToBuild(standardTurrent);
       // buildManager.SetTurrentToBuild(buildManager.standardTurrentPrefab);

    }
    public void SelectMisselLuacnher()
    {

        Debug.Log("Missel Launcher Selected");
        buildManager.SelectTurrentToBuild(missileLauncher);
        //buildManager.SetTurrentToBuild(buildManager.misselLauncherPrefab);

    }

    public void SelectLaserBeamer()
    {

        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurrentToBuild(laserBeamer);
        //buildManager.SetTurrentToBuild(buildManager.misselLauncherPrefab);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
