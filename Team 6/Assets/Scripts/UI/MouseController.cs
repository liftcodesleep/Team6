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
    public static GameComponent GameLogic;

    private Color[] originalColors;
    private GameObject oldItem = null;

    public Material HighlightedMaterial;

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
            selectedCard.card.hexes.Clear();
            selectedCard.clicked = false;
            selectedCard = null;
        }

        if (oldItem != null)
        {
            Renderer[] items = oldItem.GetComponentsInChildren<Renderer>();

            int i = 0;
            foreach (var item in items)
            {

                item.material.color = originalColors[i];

                i++;
            }
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
            GameLogic.ToolTip.SetActive(true);
            Unit selectedUnit = GameLogic.GameObjectToUnit(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            GameLogic.ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedUnit.Name + "\nHealth: " + selectedUnit.HitPoints +
                "\nStrength: " + selectedUnit.Strength + "\nMovement: " + selectedUnit.MovementRemaining + "/" + selectedUnit.Movement;



            //CurrentSelectedItem.GetComponentInChildren<Renderer>().material.color = Color.green;
            HighLightCurrentItem();

        }
        else if (CurrentSelectedItem != null && IsAHex(CurrentSelectedItem))
        {
            GameLogic.ToolTip.SetActive(true);

            Hex selectedHex = HexMap.GameObjectToHex(CurrentSelectedItem.gameObject);
            //BRING UP TOOLTIP
            GameLogic.ToolTip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Name: " + selectedHex.GetName() + "\nX: " + selectedHex.Column +
                "\nY: " + selectedHex.Row + "\nMana: " + selectedHex.GetHexMana();


            //CurrentSelectedItem.GetComponent<Outline>().enabled = true;
            HighLightCurrentItem();
        }
        else if (selectedCard != null)
        {
            selectedCard.card.hexes.Clear();
            selectedCard.clicked = false;
            selectedCard = null;
        }
        else
        {
            GameLogic.ToolTip.SetActive(false);
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

        Unit firstUnit = GameLogic.GameObjectToUnit(CurrentSelectedItem);
        Unit secondUnit = GameLogic.GameObjectToUnit(gameObjectClicked);

        
        if ( IsAUnit(CurrentSelectedItem) )
        {
            
            if ( IsAHex(gameObjectClicked) )
            {
                CurrentSelectedItem.GetComponent<UnitComponent>().OnUnitMove(clickedHex);
                
            }else if ( IsAUnit(gameObjectClicked) )
            {
                
                firstUnit.attack(secondUnit);

                //GameComponent.UnitToGameObject[secondUnit].GetComponent<UnitComponent>().UpdateHealthBar();
            }
        }

        if (selectedCard != null)
        {
            selectedCard.DoAbility(clickedHex);
            if (selectedCard.card.hexes.Count == 0)
            {
                selectedCard.clicked = false;
                selectedCard.RemoveCard(selectedCard);
                selectedCard = null;
            }

        }
    }

    public static void SetGameData(GameData GameData)
    {
        MouseController.Game = GameData;
    }
    public static void SetGameLogic(GameComponent GameLogic)
    {
        MouseController.GameLogic = GameLogic;
    }
    private bool IsAUnit(GameObject obj)
    {
        return GameLogic.GameObjectToUnit(obj) != null;
    }

    private bool IsAHex(GameObject obj)
    {
        return HexMap.GameObjectToHex(obj) != null;
    }

    private bool IsACard(GameObject obj)
    {
        
        return obj.GetComponentInChildren<CardComponent>() != null;
    }


    private void HighLightCurrentItem()
    {
        oldItem = CurrentSelectedItem;
        Renderer[] items = CurrentSelectedItem.GetComponentsInChildren<Renderer>();
        originalColors = new Color[items.Length];
        int i = 0;
        foreach (var item in items)
        {
            originalColors[i] = item.material.color;
            item.material.color = Color.green;

            i++;
        }
    }

}
