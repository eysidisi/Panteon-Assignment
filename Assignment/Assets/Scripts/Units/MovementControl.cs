using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    // Clicked object 
    private GameObject activeUnit;

    // Info menu caching variable
    private InfoMenu infoMenu;

    // Right mouse button clicked pos
    private Vector2 clickedPos;

    // If true unit moves
    private bool moveFlag = false;

    // Caching UnitMovement to move unit
    private UnitMovement unitMovement;

    // Game area length in world coordinates
    // Calculated using camera size and GameArea Width
    private int gameAreaLength = 10;

    // Game area height in world coordinates
    // Calculated using camera size and GameArea Height
    private int gameAreaHeight = 14;

    private void Start()
    {
        // Get info menu
        infoMenu = FindObjectOfType<InfoMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Get active unit
            activeUnit = infoMenu.GetActiveObject();

            // Check if active unit is a Warrior
            if (activeUnit.GetComponent<Warrior>())
            {
                // Get current click pos
                clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // If click is in the game area
                if (IsClickInGameArea(clickedPos))
                {
                    // Get unitMovement script 
                    unitMovement = activeUnit.GetComponent<UnitMovement>();

                    // Set move true
                    moveFlag = true;

                }
            }
        }

        // Check if moveFlag set to true
        if (moveFlag == true)
        {
            // Set target pos in unitMovement script
            unitMovement.SetTargetPos(clickedPos);

            // Don't send new target pos
            moveFlag = false;
        }
    }

    private bool IsClickInGameArea(Vector2 clickPos)
    {
        // If click is not in GameArea return false
        if (clickPos.x > gameAreaLength || clickPos.x < 0 ||
            clickPos.y > gameAreaHeight || clickPos.y < 0)
        {
            return false;
        }

        else
        {
            return true;
        }
    }


}
