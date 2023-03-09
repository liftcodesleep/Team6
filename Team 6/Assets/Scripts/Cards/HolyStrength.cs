using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyStrength : Card
{

    public HolyStrength()
    {
        name = "Holy Strength";
    }

    public override void DoAction(Hex hex)
    {

        Unit target = hex.Units()[0];
        if (target.name == "skeleton")
        {
            target.HitPoints -= 2;
            target.Strength -= 1;
        }
        else
        {
            target.heal(2);
            target.Strenth += 1;
        }


    }
}
