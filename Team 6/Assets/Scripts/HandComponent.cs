using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandComponent : MonoBehaviour
{
    // Start is called before the first frame update

    //Vector3[] positions;
    //[SerializeField] GameObject card;
    //GameObject[] cards;

   

    public Hand hand;
    CardComponent[] CardComponents;

    private PlayerComponent Owner;
    private bool IsCurrentlyShowing;

    public static GameData Game;


    private void Start()
    {
        IsCurrentlyShowing = false;
        int amountOfCards = this.transform.childCount;
        CardComponents = new CardComponent[amountOfCards];

        for (int i = 0; i < amountOfCards; i++)
        {
            CardComponents[i] = this.transform.GetChild(i).GetComponentInChildren<CardComponent>();

        }

       
    }

    private void Update()
    {
        if (Owner != null && hand != null)
        {
            if (!IsCurrentlyShowing && Game.AllPlayers[Game.GetCurrentPlayer()] == Owner)
            {

                this.Show();
                IsCurrentlyShowing = true;
            }
            else if(IsCurrentlyShowing && Game.AllPlayers[Game.GetCurrentPlayer()] != Owner)
            {
                this.Hide();
                IsCurrentlyShowing = false;

            }
        }

        

    }

    public static void SetGameData(GameData GameData)
    {
        HandComponent.Game = GameData;
    }

    public void SetHand(Hand hand)
    {
        this.hand = hand;
        Owner = hand.Owner;
    }

    public void Hide()
    {
        foreach(CardComponent cardComponent in CardComponents)
        {
            cardComponent.SetCardMeshesVisible(false);
        }
    }

    public void Show()
    {

        int i = 0;
        foreach (CardComponent cardComponent in CardComponents)
        {
            if (i < hand.Cards.Count)
            {
                //cardComponent.card = hand.Cards[i];
                cardComponent.SetCard(hand.Cards[i]);
                cardComponent.SetCardMeshesVisible(true);
                
            }
            else
            {
                cardComponent.SetCardMeshesVisible(false);
            }

            i++;
        }
        
    }

    /*
    void Start()
    {

        int amountOfCards = this.transform.childCount;
        positions = new Vector3[amountOfCards];

        cards = new GameObject[amountOfCards];
        for (int cardIndex = 0; cardIndex < amountOfCards; cardIndex++)
        {
            positions[cardIndex] = this.transform.GetChild(cardIndex).gameObject.transform.position;
            cards[cardIndex] = this.transform.GetChild(cardIndex).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawNewHand()
    {
        Hand hand = HexMap.AllPlayers[HexMap.currentPlayer].hand;
        CardComponent cardC;
        int i = 0;
        foreach (GameObject card in cards)
        {
            // card.GetComponentInChildren<CardComponent>().setSelectedPosition(card.GetComponentInChildren<CardComponent>().getStartPosition());
            // card.GetComponentInChildren<CardComponent>().clicked = false;
            cardC = card.GetComponentInChildren<CardComponent>();
            if (i < hand.cards.Count)
            {
                cardC.setCard(i);
                cardC.drawed = true;
                i++;
            }
            
        }

    }

    public void Draw()
    {
        Hand hand = HexMap.AllPlayers[HexMap.currentPlayer].hand;

        hand.Draw();

    }

    */
}
