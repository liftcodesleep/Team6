using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMagic : Card
{

    public ControlMagic()
    {
        Name = "ControlMagic";
    }

    public override void DoAction(Hex hex)
    {
        hex.GetUnitsArray()[0].SetOwner(Game.GetCurrentPlayer());
    }
}
