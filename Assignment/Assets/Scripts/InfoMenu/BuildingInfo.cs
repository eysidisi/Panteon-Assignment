using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour
{
    // Sets building info on UI
    public void SetInfo(Sprite buildingSprite, string buildingName)
    {
        if (buildingSprite == null || buildingName == null)
        {
            gameObject.SetActive(false);
        }

        else
        {
            GetComponentInChildren<Text>().text = buildingName;
            GetComponentInChildren<Image>().sprite = buildingSprite;
        }
    }

}
