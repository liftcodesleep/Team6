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

        target.heal(2);
        target.Strenth += 1;



    }
}
