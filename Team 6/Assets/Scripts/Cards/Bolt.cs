using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt :Card
{

    public Bolt()
    {
        Name = "Bolt";
        numTargets = 2;
    }

    public override void DoAction(Hex hex)
    {
        hexes.Add(hex);
        
        if (hexes.Count == numTargets)
        {
            foreach (Hex X in hexes)
            {
                Unit target = X.Units()[0];
                target.HitPoints -= 3;
            }
            hexes.Clear();
        }
    }
}
