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
    CardComponent[] CardComponentsInHand;

    private PlayerData Owner;

    public static GameData Game;


    private void Start()
    {
        int NumCardsInHand = this.transform.childCount;
        CardComponentsInHand = new CardComponent[NumCardsInHand];

        for (int i = 0; i < NumCardsInHand; i++)
        {
            CardComponentsInHand[i] = this.transform.GetChild(i).GetComponentInChildren<CardComponent>();

        }


    }
    private void Update()
    {
        RenderHand(Game.GetCurrentPlayer());
    }

    public static void SetGameData(GameData GameData)
    {
        HandComponent.Game = GameData;
    }

    public void RenderHand(PlayerData ActivePlayer)
    {
        bool OwnerIsActive = (ActivePlayer == this.Owner);
        for (int i = 0; i < ActivePlayer.GetHand().Cards.Count; i++)
        {
            CardComponentsInHand[i].SetCardText(ActivePlayer.GetHand().Cards[i]);
            CardComponentsInHand[i].SetCardIsVisible(OwnerIsActive); // && Card is real
        }
    }
    public void SetHand(Hand hand)
    {
        Owner = hand.Owner;
        this.hand = hand;
    }
    public void AddCard(CardComponent cardComponent)
    {
        Owner.GetHand().Cards.Add(cardComponent.card);
        cardComponent.SetCardIsVisible(true);
    }

    public void RemoveCard(CardComponent cardComponent)
    {
        Owner.GetHand().Cards.Remove(cardComponent.card);
        cardComponent.SetCardIsVisible(false);
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
