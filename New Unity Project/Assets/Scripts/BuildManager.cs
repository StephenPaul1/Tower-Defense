using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
  
    void Awake()
   {
        if (instance != null)
        {
           // Debug.LogError("More than one BuildManagger in scene");
                return;
        }
        instance = this;

    }
    
   // public GameObject standardTurrentPrefab;
   // public GameObject misselLauncherPrefab;

    // DONT DO public GameObject buildEffect;
    // DONT DO public GameObject sellEffect;
   

    private TurrentBluePrint turrentToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }


  

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        
        }

        selectedNode = node;
        turrentToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    
    }

    public void SelectTurrentToBuild(TurrentBluePrint turrent)
    {
        turrentToBuild = turrent;
        selectedNode = null;

        DeselectNode();
    }

    public TurrentBluePrint GetTurrentToBuild()
    {
        return turrentToBuild;
    }

    //public void SetTurrentToBuild(GameObject turrent)
    //{
    //    turrentToBuild = turrent;
  //  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
