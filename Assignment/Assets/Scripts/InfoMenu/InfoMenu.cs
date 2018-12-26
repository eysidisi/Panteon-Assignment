using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    // Cache variables to set unit and building info at Info menu
    private UnitInfo unitInfo;
    private BuildingInfo buildingInfo;

    // Clicked active object
    private GameObject activeObject;

    //Can active object produce units
    private bool canProduceUnits;

    private void Start()
    {
        // Cache variables
        unitInfo = FindObjectOfType<UnitInfo>();
        buildingInfo = FindObjectOfType<BuildingInfo>();

        // null check
        if(unitInfo==null)
        {
            throw new System.ArgumentException("Parameter cannot be null", "unitInfo");
        }

        // null check
        if (buildingInfo == null)
        {
            throw new System.ArgumentException("Parameter cannot be null", "buildingInfo");
        }

        // Deactivate menus at the start
        buildingInfo.gameObject.SetActive(false);
        unitInfo.gameObject.SetActive(false);
    }

    // Set building and unit infos
    public void SetInfo(Sprite buildingSprite, Sprite unitSprite, string buildingName, string unitName)
    {
        // If info menus are deactivated, activate them before using
        if (buildingInfo.gameObject.activeSelf==false)
        {
            buildingInfo.gameObject.SetActive(true);
        }
        if (unitInfo.gameObject.activeSelf == false)
        {
            unitInfo.gameObject.SetActive(true);
        }

        // Set building info
        buildingInfo.SetInfo(buildingSprite, buildingName);

        // Set unit info
        unitInfo.SetInfo(unitSprite, unitName);
    }

    // Set just unit info 
    public void SetInfo(string unitName, Sprite unitSprite)
    {
        // Set unit info menu active
        if (unitInfo.gameObject.activeSelf == false)
        {
            unitInfo.gameObject.SetActive(true);
        }

        // Deactivate buildingInfo menu
        buildingInfo.gameObject.SetActive(false);

        // Set unit info
        unitInfo.SetInfo(unitSprite,unitName);
    }

    // Set active object as new clicked object
    public void SetActiveObject(GameObject clickedObject)
    {
        activeObject = clickedObject;
    }

    // Get clicked object
    public GameObject GetActiveObject()
    {
        return activeObject;
    }
}
