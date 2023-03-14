using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsToPlowshares : Card
{

    public SwordsToPlowshares()
    {
        Name = "SwordsToPlowshares";
        RulesText = "Destroy target creature, its controller gains life equal to its Strength";
    }

    public override void DoAction(Hex hex)
    {
        hexes.Add(hex);

        if (hexes.Count == numTargets)
        {
            foreach (Hex X in hexes)
            {
                Unit target = X.GetUnitsArray()[0];
                target.GetOwner().GetAvatar().Heal(target.HitPoints);
                target.HitPoints -= 999;
            }
            hexes.Clear();
        }
    }
}
