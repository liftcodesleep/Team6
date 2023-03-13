using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathOfSlippy : Card
{

    public WrathOfSlippy()
    {
        Name = "WrathOfSlippy";
    }

    public override void DoAction(Hex hex)
    {
        foreach(PlayerData player in Game.Players)
        {
            foreach(Unit unit in player.GetUnits())
            {
                unit.Damage(999);
            }
        }
    }
}
