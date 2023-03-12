using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckData : CardZoneData
{

    public DeckData(PlayerData player) : base(player)
    {
        Cards.Add(new GrizzlyBears());
        Cards.Add(new HolyStrength());
        Cards.Add(new Bolt());
        Cards.Add(new WhiteKnight());
        Cards.Add(new Skeleton());
        Cards.Add(new Teleport());
        Cards.Add(new Minotaur());
        Cards.Add(new Specter());
        Cards.Add(new Spider());
        Cards.Add(new Knives());
        Cards.Add(new Goblin());
        this.ZoneCapacity = 40;
        this.ZoneOccupation = Cards.Count;

        Shuffle();

    }
}
