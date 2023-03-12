using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandComponent : MonoBehaviour
{
    public Hand hand;
    CardComponent[] CardComponents;

    private PlayerData Owner;

    public static GameData Game;

    private void Start()
    {
        int NumCardComponents = this.transform.childCount;
        CardComponents = new CardComponent[NumCardComponents];

        for (int i = 0; i < NumCardComponents; i++)
        {
            CardComponents[i] = this.transform.GetChild(i).GetComponentInChildren<CardComponent>();
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
        int NumCardsInHand = ActivePlayer.GetHand().Cards.Count;
        for (int i = 0; i < NumCardsInHand; i++)
        {
            CardComponents[i].SetCardText(ActivePlayer.GetHand().Cards[i]);
            CardComponents[i].SetCardIsVisible(OwnerIsActive);
        }
        for (int i = CardComponents.Length - 1; i >= NumCardsInHand; i--)
        {
            CardComponents[i].SetCardIsVisible(false);
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
}
