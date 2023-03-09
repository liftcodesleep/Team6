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
        
        Unit[] target = hex.Units();

        if(target.Length < 1)
        {
            return;
        }

        target[0].HitPoints -= 3;

    }
}
