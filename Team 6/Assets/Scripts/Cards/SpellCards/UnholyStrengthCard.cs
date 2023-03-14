using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnholyStrength : Card
{

    public UnholyStrength()
    {
        Name = "Unholy Strength";
        RulesText = "Give any [DARK] creature +1 Strength and heal them 2 HP. Reverse for [LIGHT] creature.";
        this.Color = "Black";
    }

    public override void DoAction(Hex hex)
    {
        Unit Target = hex.GetUnitsArray()[0];
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
