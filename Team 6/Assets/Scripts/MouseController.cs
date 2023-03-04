using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    private Vector3 pressedDownPosition;
    private Vector3 pressedUpPosition;

    private Ray mouseRay;
    private RaycastHit hitRay;
    private GameObject currentSelectedItem;

    private void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            leftMouseClicked();

        }else if (Input.GetMouseButtonDown(1))
        {
            rightMouseClick();
        }
        
    }

    private void leftMouseClicked()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject firstSelectedItem = currentSelectedItem;

        if (Physics.Raycast(mouseRay, out hitRay, 100f))
        {
            currentSelectedItem = hitRay.transform.gameObject.transform.parent.gameObject;
        }

    }
     
    private void rightMouseClick()
    {
        
        if( currentSelectedItem == null )
        {
            return;
        }

        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject hexGO = null;
        Hex clickedHex = null;
        GameObject gameObjectClicked = null;

        if (Physics.Raycast(mouseRay, out hitRay, 100f))
        {
            hexGO = hitRay.transform.gameObject.transform.parent.gameObject;
            clickedHex = HexMap.gameObjectToHex(hexGO);
            gameObjectClicked = hitRay.transform.gameObject.transform.parent.gameObject;

        }
        
        Unit firstUnit = HexMap.gameObjectToUnit(currentSelectedItem);
        Unit secondUnit = HexMap.gameObjectToUnit(gameObjectClicked);

        if( IsAUnit(currentSelectedItem) )
        {
            if ( IsAHex(gameObjectClicked) )
            {

                currentSelectedItem.GetComponent<UnitComponent>().OnUnitMove(clickedHex);
                //if ((currentSelectedItem.transform.position - hexGO.transform.position).magnitude < firstUnit.Movement * 2)
                /*
                if (firstUnit.hex.DistanceFrom(clickedHex) <= firstUnit.Movement)
                {

                    firstUnit.SetHex(clickedHex);
                    
                }*/
            }

            if ( IsAUnit(gameObjectClicked) )
            {
                firstUnit.attack(secondUnit);

                HexMap.unitToGameObject[secondUnit].GetComponent<UnitComponent>().updateHealthBar();
            }
        }

        
    }

    private bool IsAUnit(GameObject obj)
    {
        return HexMap.gameObjectToUnit(obj) != null;
    }

    private bool IsAHex(GameObject obj)
    {
        return HexMap.gameObjectToHex(obj) != null;
    }
    
}
