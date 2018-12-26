using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    private GameObject activeObject;

    private InfoMenu infoMenu;

    private void Start()
    {
        infoMenu = FindObjectOfType<InfoMenu>();
    }

    public void ProduceUnit()
    {
        activeObject = infoMenu.GetActiveObject();


        if (activeObject.GetComponent<Building>() != null)
        {
            activeObject.GetComponent<Building>().ProduceUnit();
        }
    }
}
