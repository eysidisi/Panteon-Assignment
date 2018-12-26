using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    // Icons of building and it's unit
    protected Sprite buildingSprite = null;
    protected Sprite unitSprite = null;

    // Building and unit names
    protected string buildingName = null;
    protected string unitName = null;

    // Used for collision check
    private int overlaps = 0;

    // Info menu variable to show info to the user
    protected InfoMenu infoMenu;

    // Unit to produce
    [SerializeField] protected GameObject unit = null;

    // Unit spawn position
    [SerializeField] protected GameObject spawnPos = null;

    // Produces unit if building is capable of doing
    abstract public void ProduceUnit();

    // If it is colliding with another object increase overlaps by one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlaps++;
    }

    // If collision is ended decrease overlaps by one
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlaps--;
    }

    // Checks if building is colliding with any object 
    public bool checkCollision()
    {
        // If it's colliding return true
        if (overlaps > 0)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    // If building is clicked
    private void OnMouseDown()
    {
        // Show it's info to the user
        infoMenu.SetInfo(buildingSprite, unitSprite, buildingName, unitName);

        // Set this object as clicked, active object
        infoMenu.SetActiveObject(gameObject);
    }
}
