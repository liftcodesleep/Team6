using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    private Vector3 pressedDownPosition;
    private Vector3 pressedUpPosition;


    private Ray MouseRay;
    private RaycastHit HitRay;
    private GameObject CurrentSelectedItem;
    public GameObject ToolTip;

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


        MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject firstSelectedItem = CurrentSelectedItem;

        if (Physics.Raycast(MouseRay, out HitRay, 100f))
        {
            CurrentSelectedItem = HitRay.transform.gameObject.transform.parent.transform.parent.gameObject;
            Debug.Log(CurrentSelectedItem.gameObject.name);
        }
        

        if (CurrentSelectedItem !=null && IsACard(CurrentSelectedItem))
        {
            selectedCard = CurrentSelectedItem.GetComponentInChildren<CardComponent>();
            selectedCard.clicked = true;
            
        }
        else if (CurrentSelectedItem != null && IsAUnit(CurrentSelectedItem))
        {
            ToolTip.SetActive(true);
            Unit selectedUnit = HexMap.gameObjectToUnit(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedUnit.Name + "\nHealth: " + selectedUnit.HitPoints +
                "\nStrength: " + selectedUnit.Strength + "\nMovement: " + selectedUnit.MovementRemaining + "/" + selectedUnit.Movement;
        }
        else if (CurrentSelectedItem != null && IsAHex(CurrentSelectedItem))
        {
            ToolTip.SetActive(true);

            Hex selectedHex = HexMap.gameObjectToHex(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedHex.Name + "\nX: " + selectedHex.Column +
                "\nY: " + selectedHex.Row;
        }
        else if (selectedCard != null)
        {
            selectedCard.clicked = false;
            selectedCard = null;
        }
        else
        {
            ToolTip.SetActive(false);

        }



    }

    
     
    private void rightMouseClick()
    {
        
        if( CurrentSelectedItem == null )
        {
            return;
        }

        MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject hexGO = null;
        Hex clickedHex = null;
        GameObject gameObjectClicked = null;

        if (Physics.Raycast(MouseRay, out HitRay, 100f))
        {
            hexGO = HitRay.transform.gameObject.transform.parent.transform.parent.gameObject;
            clickedHex = HexMap.gameObjectToHex(hexGO);
            gameObjectClicked = HitRay.transform.gameObject.transform.parent.transform.parent.gameObject;

        }

        Debug.Log(hexGO.name);

        Unit firstUnit = HexMap.gameObjectToUnit(CurrentSelectedItem);
        Unit secondUnit = HexMap.gameObjectToUnit(gameObjectClicked);

        
        if ( IsAUnit(CurrentSelectedItem) )
        {
            
            if ( IsAHex(gameObjectClicked) )
            {
                CurrentSelectedItem.GetComponent<UnitComponent>().OnUnitMove(clickedHex);
                
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
