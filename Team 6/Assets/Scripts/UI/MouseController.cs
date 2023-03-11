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
    private CardComponent selectedCard;
    public static GameData Game;

    public GameObject ToolTip;



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
            
        }
        

        if (CurrentSelectedItem !=null && IsACard(CurrentSelectedItem))
        {
            selectedCard = CurrentSelectedItem.GetComponentInChildren<CardComponent>();
            selectedCard.clicked = true;
            
        }
        else if (CurrentSelectedItem != null && IsAUnit(CurrentSelectedItem))
        {
            ToolTip.SetActive(true);
            Unit selectedUnit = Game.GameObjectToUnit(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedUnit.Name + "\nHealth: " + selectedUnit.HitPoints +
                "\nStrength: " + selectedUnit.Strength + "\nMovement: " + selectedUnit.MovementRemaining + "/" + selectedUnit.Movement;
        }
        else if (CurrentSelectedItem != null && IsAHex(CurrentSelectedItem))
        {
            ToolTip.SetActive(true);

            Hex selectedHex = HexMap.GameObjectToHex(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedHex.GetName() + "\nX: " + selectedHex.Column +
                "\nY: " + selectedHex.Row + "\nMana: " + selectedHex.GetMana();
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
            clickedHex = HexMap.GameObjectToHex(hexGO);
            gameObjectClicked = HitRay.transform.gameObject.transform.parent.transform.parent.gameObject;

        }

        

        Unit firstUnit = Game.GameObjectToUnit(CurrentSelectedItem);
        Unit secondUnit = Game.GameObjectToUnit(gameObjectClicked);

        
        if ( IsAUnit(CurrentSelectedItem) )
        {
            
            if ( IsAHex(gameObjectClicked) )
            {
                CurrentSelectedItem.GetComponent<UnitComponent>().OnUnitMove(clickedHex);
                
            }else if ( IsAUnit(gameObjectClicked) )
            {
                
                firstUnit.attack(secondUnit);

                Game.UnitToGameObject[secondUnit].GetComponent<UnitComponent>().UpdateHealthBar();
            }
        }

        if (selectedCard != null)
        {
            
            selectedCard.DoAbility(clickedHex);
            selectedCard.clicked = false;
            selectedCard.RemoveFromHand();
            selectedCard.played = false;
            selectedCard = null;

        }
    }

    public static void SetGameData(GameData GameData)
    {
        MouseController.Game = GameData;
    }

    private bool IsAUnit(GameObject obj)
    {
        return Game.GameObjectToUnit(obj) != null;
    }

    private bool IsAHex(GameObject obj)
    {
        return HexMap.GameObjectToHex(obj) != null;
    }

    private bool IsACard(GameObject obj)
    {
        
        return obj.GetComponentInChildren<CardComponent>() != null;
    }

}
