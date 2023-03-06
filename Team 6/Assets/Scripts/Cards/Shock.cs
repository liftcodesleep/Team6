using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock :Card
{

    public Shock()
    {
        name = "Shock";
    }

    public override void DoAction(Hex hex)
    {
        
        Unit target = hex.Units()[0];

        target.HitPoints -= 3;

    }
}
