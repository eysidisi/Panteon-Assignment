using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitInfo : MonoBehaviour
{
    // Sets unit info on UI
    public void SetInfo(Sprite unitSprite, string unitName)
    {
        // If there is no unitName or unitSprite then disable gameobject
        if (unitSprite == null || unitName == null)
        {
            gameObject.SetActive(false);
        }

        else
        {
            // Setunit name and sprite for info
            GetComponentInChildren<Text>().text = unitName;
            GetComponentInChildren<Image>().sprite = unitSprite;
        }

    }
}
