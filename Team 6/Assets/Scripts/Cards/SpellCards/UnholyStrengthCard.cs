using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnholyStrength : Card
{

    public UnholyStrength()
    {
        Name = "Unholy Strength";
        this.Color = "Black";
    }

    public override void DoAction(Hex hex)
    {
        Unit Target = hex.Units()[0];
        if (Target.Color == "White")
        {
            Target.HitPoints -= 2;
            Target.Strength -= 1;
            Debug.Log(Target.Name);
        }
        else
        {
            Debug.Log(Target.Name);
            Target.Heal(2);
            Target.Strength += 1;
        }

    }
}
