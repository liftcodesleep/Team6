using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardZoneData
{
    public Hand(PlayerData player) : base(player)
    {
        this.ZoneCapacity = 7;
        this.ZoneOccupation = 0;
    }

    public void DrawNCards(int n)
    {
        if(ZoneOccupation + n > ZoneCapacity)
        {
            n = ZoneCapacity - ZoneOccupation;
        }
        GetNCardsFromZone(n, Owner.GetDeck());
    }
    public void RemoveCard(Card card)
    {

    }
}
