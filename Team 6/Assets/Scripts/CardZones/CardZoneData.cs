using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoneData
{

    public List<Card> Cards;

    protected int ZoneCapacity;
    protected int ZoneOccupation;

    public PlayerData Owner;

    public CardZoneData(PlayerData player)
    {
        Owner = player;
        Cards = new List<Card>();

    }

    public Card PopCard()
    {
        Card TopCard = Cards[0];
        Cards.Remove(TopCard);
        return TopCard;
    }

    public void MoveNCardsFromZone(int n, CardZoneData TargetZone)
    {
        for (int i = 0; i < n; i++)
        {
            Cards.Add(TargetZone.PopCard());
        }
    }


    public void PutInHand(Card card)
    {
        if (Cards.Count < ZoneCapacity)
        {
            Cards.Add(card);
        }

    }




}
