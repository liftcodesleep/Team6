using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardZoneData
{
    public Hand(PlayerData player) : base(player)
    {
        this.ZoneCapacity = 7;
        this.ZoneOccupation = 3;
    }
}
