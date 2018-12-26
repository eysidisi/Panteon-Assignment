using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerStation : Building
{
    // Id for each PowerStation
    static int powerStationIndex = 0;

    private void Start()
    {
        // Set building name for info menu
        buildingName = "PowerStation " + powerStationIndex.ToString();

        // Set hierarchical name to building name
        gameObject.name = buildingName;

        // Increase powerStation index by one
        powerStationIndex++;

        // Set building sprite for info menu
        buildingSprite = GetComponent<SpriteRenderer>().sprite;

        // Find infoMenu object
        infoMenu = FindObjectOfType<InfoMenu>();

        
    }

    // It doesn't produce any unit
    public override void ProduceUnit()
    {
        return;
    }
}
