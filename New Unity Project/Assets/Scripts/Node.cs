using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 poistionOffset;

    //[Header("Optional")]
    [HideInInspector]
    public GameObject turrent;
    [HideInInspector]
    public TurrentBluePrint turrentBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + poistionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        

        if (turrent != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurrent(buildManager.GetTurrentToBuild());

    }

    void BuildTurrent(TurrentBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough Money");
            return;
        }


        PlayerStats.Money -= blueprint.cost;

        GameObject _turrent = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;

        
        turrentBlueprint = blueprint;

        //DONT DO
        // GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion identitfy);
        //Destroy(effect, 5f);



        Debug.Log("Turrent build! money left:" + PlayerStats.Money);

      //  buildManager.BuildTurrentOn(this);
    }


    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turrentBlueprint.upgradedCost)
        {
            Debug.Log("Not enough Money to upgrade");
            return;
        }


        PlayerStats.Money -= turrentBlueprint.upgradedCost;

        Destroy(turrent);


        //BULD A NEW TURRENT
        GameObject _turrent = (GameObject)Instantiate(turrentBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;

        //DONT DO
        // GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion identitfy);
        //Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turrent upgraded:" + PlayerStats.Money);

        //  buildManager.BuildTurrentOn(this);
    }


    public void SellTurrent()
    {
        PlayerStats.Money += turrentBlueprint.GetSellAmount();

        //DONT DO
        // GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion identitfy);
        //Destroy(effect, 5f);

        Destroy(turrent);
        turrentBlueprint = null;
    
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

         if (!buildManager.CanBuild)
           return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }
}