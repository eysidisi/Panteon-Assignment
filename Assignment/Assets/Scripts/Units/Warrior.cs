using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    static int warriorIndex = 0;

    // Warrior icon
    private Sprite warriorSprite;

    // Warrior's name
    private string warriorName;

    // Cache variable
    private InfoMenu infoMenu;

    // Use this for initialization
    void Start()
    {
        // Cache sprite of warrior
        warriorSprite = GetComponent<SpriteRenderer>().sprite;

        // Cache infoMenu
        infoMenu = FindObjectOfType<InfoMenu>();

        // Set unit's name
        warriorName = "Warrior " + warriorIndex;

        // Increase index by one
        warriorIndex++;

        // Set hierarchical name to unit's name
        gameObject.name = warriorName;
    }

    private void OnMouseDown()
    {
        infoMenu.SetInfo(warriorName,warriorSprite);
        infoMenu.SetActiveObject(gameObject);
    }
}
