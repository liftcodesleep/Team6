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
        foreach(Unit unit in Game.units)
        {
            if (unit.GetOwner().GetAvatar() != unit)
            {
                unit.Damage(999); 
            }
        }
    }
}
