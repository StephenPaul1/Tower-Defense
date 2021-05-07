using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurrentBluePrint 
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradedPrefab;
    public int upgradedCost;
    public int GetSellAmount()

    {

        return cost / 2;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
