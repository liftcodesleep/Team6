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

    private CardComponent selectedCard;


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

        if (selectedCard != null)
        {
            selectedCard.clicked = false;
            selectedCard = null;
        }


        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject firstSelectedItem = currentSelectedItem;

        if (Physics.Raycast(mouseRay, out hitRay, 100f))
        {
            currentSelectedItem = hitRay.transform.gameObject.transform.parent.transform.parent.gameObject;
            Debug.Log(currentSelectedItem.gameObject.name);
        }
        

        if (currentSelectedItem !=null && IsACard(currentSelectedItem))
        {
            selectedCard = currentSelectedItem.GetComponentInChildren<CardComponent>();
            selectedCard.clicked = true;
            
        }else if (selectedCard != null)
        {
            selectedCard.clicked = false;
            selectedCard = null;
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
            hexGO = hitRay.transform.gameObject.transform.parent.transform.parent.gameObject;
            clickedHex = HexMap.gameObjectToHex(hexGO);
            gameObjectClicked = hitRay.transform.gameObject.transform.parent.transform.parent.gameObject;

        }

        Debug.Log(hexGO.name);

        Unit firstUnit = HexMap.gameObjectToUnit(currentSelectedItem);
        Unit secondUnit = HexMap.gameObjectToUnit(gameObjectClicked);

        
        if ( IsAUnit(currentSelectedItem) )
        {
            
            if ( IsAHex(gameObjectClicked) )
            {
                currentSelectedItem.GetComponent<UnitComponent>().OnUnitMove(clickedHex);
                
            }else if ( IsAUnit(gameObjectClicked) )
            {
                
                firstUnit.attack(secondUnit);

                HexMap.unitToGameObject[secondUnit].GetComponent<UnitComponent>().UpdateHealthBar();
            }
        }

        if (selectedCard != null)
        {
            selectedCard.DoAbility(clickedHex);
            if(selectedCard.card.numTargets == selectedCard.card.hexes.Count)
            {
                selectedCard.clicked = false;
                selectedCard = null;
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

    private bool IsACard(GameObject obj)
    {
        
        return obj.GetComponentInChildren<CardComponent>() != null;
    }

}
