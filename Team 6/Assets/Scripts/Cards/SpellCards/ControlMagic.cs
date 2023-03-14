using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMagic : Card
{

    public ControlMagic()
    {
        Name = "ControlMagic";
        RulesText = "Gain control of target creature.";
    }

    public override void DoAction(Hex hex)
    {
        if (hex.GetUnitsArray()[0].GetOwner().GetAvatar() == hex.GetUnitsArray()[0])
        {
            return;
        }
        hex.GetUnitsArray()[0].SetOwner(Game.GetCurrentPlayer());
    }
}
