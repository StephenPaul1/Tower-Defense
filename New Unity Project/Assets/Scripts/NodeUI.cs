using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradedCost;
    public Button upgradedButton;
    public Text SellAmount;
    private Node target;



    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.GetBuildPosition();

        if (target.isUpgraded)
        {
            upgradedCost.text = "$" + target.turrentBlueprint.upgradedCost;
            upgradedButton.interactable = true;

        }
        else
        {
            upgradedCost.text = "Done";
            upgradedButton.interactable = false;
        }


        SellAmount.text = "$" + target.turrentBlueprint.GetSellAmount();

        ui.SetActive(true);
    
    }



    public void Hide ()
    {
        ui.SetActive(false);
    
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    
    }


    public void Sell()
    {
        target.SellTurrent();
        BuildManager.instance.DeselectNode();
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
