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

            //Debug.Log(currentSelectedItem.name);
        }

        


    }
     
    private void rightMouseClick()
    {
        
        if( currentSelectedItem == null )
        {
            return;
        }

        Unit clickedUnit = HexMap.gameObjectToUnit(currentSelectedItem);

        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject hexGO;
        Hex clickedHex;
        GameObject gOClicked = null;

        if (Physics.Raycast(mouseRay, out hitRay, 100f))
        {
            hexGO = hitRay.transform.gameObject.transform.parent.gameObject;
            clickedHex = HexMap.gameObjectToHex(hexGO);
            gOClicked = hitRay.transform.gameObject.transform.parent.gameObject;

        }
        else
        {
            hexGO = null;
            clickedHex = null;
        }

        Unit firstUnit = HexMap.gameObjectToUnit(currentSelectedItem);
        Unit secondUnit = HexMap.gameObjectToUnit(gOClicked);
        if (clickedHex != null && clickedUnit!= null)
        {
            if ((currentSelectedItem.transform.position- hexGO.transform.position).magnitude < firstUnit.Movement*2)
            {
                Debug.Log(string.Format("Moving to {0}", hexGO.name));
                clickedUnit.SetHex(clickedHex);
                currentSelectedItem.GetComponent<UnitView>().OnUnitMove(clickedUnit.Hex, clickedHex);
            }
            

        }

        

        if (firstUnit != null && secondUnit != null)
        {
            firstUnit.attack(secondUnit);

            HexMap.unitToGameObject[secondUnit].GetComponent<UnitView>().updateHealthBar();
        }



    }
    
}
