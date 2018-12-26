using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Building
{
    // Id for each Barrack
    static int barrackIndex = 0;

    private void Start()
    {
        // Set building name for info menu
        buildingName = "Barrack " + barrackIndex.ToString();

        // Increase barrack index by one
        barrackIndex++;

        // Set hierarchical name to building name
        gameObject.name = buildingName;

        // Set building sprite for info menu
        buildingSprite = GetComponent<SpriteRenderer>().sprite;

        // Set unit's name and sprite
        unitName = unit.name;
        unitSprite = unit.GetComponent<SpriteRenderer>().sprite;

        // Find infoMenu object
        infoMenu = FindObjectOfType<InfoMenu>();

    }

    // Produces warrior
    public override void ProduceUnit()
    {
         Instantiate(unit, spawnPos.transform.position, Quaternion.identity);
    }



}
