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

    public void GetNCardsFromZone(int n, CardZoneData TargetZone)
    {
        for (int i = 0; i < n; i++)
        {
            if (ZoneCapacity > ZoneOccupation)
            {
                Cards.Add(TargetZone.PopCard());
                ZoneOccupation++;
            }
        }
    }
    public void RemoveCard()
    {
        ZoneOccupation -= 1;
    }

    public void Shuffle()
    {
        for(int i = 0; i < Cards.Count; i++)
        {
            Swap(i, Random.Range(0, Cards.Count));
        }
    }

    public void Swap(int target1, int target2)
    {
        Card temp = Cards[target1];

        Cards[target1] = Cards[target2];
        Cards[target2] = temp;

    }
}
