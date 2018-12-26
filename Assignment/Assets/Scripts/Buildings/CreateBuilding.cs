using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateBuilding : MonoBehaviour
{
    // Building prefab to create
    [SerializeField] private Building buildingPrefab;

    // Game area length in world coordinates
    // Calculated using camera size and GameArea Width
    private int gameAreaLength = 10;

    // Game area height in world coordinates
    // Calculated using camera size and GameArea Height
    private int gameAreaHeight = 14;

    // New created building
    private Building createdBuilding;

    // Position of new building
    private Vector2 buildingPos;

    // Use this for initialization
    void Start()
    {
        // Check to avoid null reference errors
        if (buildingPrefab == null)
        {
            throw new System.ArgumentException("Parameter cannot be null", "buildingPrefab");
        }
    }

    // Clicking to create a new building
    private void OnMouseDown()
    {
        // Get current mouse pos and convert it into world coordinate
        buildingPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        // Create new building
        createdBuilding = Instantiate(buildingPrefab, buildingPos, Quaternion.identity) as Building;
    }

    // Dragging new building
    private void OnMouseDrag()
    {
        // Convert mouse position into world coordinate
        buildingPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        // Drag building as mouse moves along
        createdBuilding.transform.position = buildingPos;

        // If there is collision or building is not in game area paint it to red
        if ((createdBuilding.checkCollision() == true) || (IsBuildingInGameArea() == false))
        {
            createdBuilding.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        else
        {
            createdBuilding.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    //  Finger/mouse button is released to create new building
    private void OnMouseUp()
    {
        // If building is not in game area then destroy it
        if (IsBuildingInGameArea() == false)
        {
            Destroy(createdBuilding.gameObject);
        }

        else
        {
            // If there is a collision with another object destroy the createdBuilding
            if (createdBuilding.checkCollision() == true)
            {
                Destroy(createdBuilding.gameObject);
            }

            // Rescan all grid map since new building is added to the map
            AstarPath.active.Scan();
        }
    }

    // Checks if building is in game area
    private bool IsBuildingInGameArea()
    {
        // If building is not in GameArea return false
        if (createdBuilding.transform.position.x > gameAreaLength || createdBuilding.transform.position.x < 0 ||
            createdBuilding.transform.position.y > gameAreaHeight || createdBuilding.transform.position.y < 0)
        {
            return false;
        }

        else
        {
            return true;
        }
    }


}
