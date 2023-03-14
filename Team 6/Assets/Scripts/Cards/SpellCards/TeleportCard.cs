using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Card
{

    public Teleport()
    {
        Name = "Teleport";
        RulesText = "Move any creature from its current position to another.";
        Color = "Blue";
        numTargets = 2;
    }

    public override void DoAction(Hex hex)
    {

        hexes.Add(hex);
        Debug.Log("Added " + hex.Column);
        Debug.Log("Added " + hex.Row);

        if (hexes.Count == numTargets)
        {
            hexes[0].GetUnitsArray()[0].SetHex(hexes[1]);
            hexes.Clear();

        }
    }
}
