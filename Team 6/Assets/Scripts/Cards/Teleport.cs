using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Card
{

    public Teleport()
    {
        name = "Teleport";
        numTargets = 2;
    }

    public override void DoAction(Hex hex)
    {

        hexes.Add(hex);
        Debug.Log("Added " + hex.Column);
        Debug.Log("Added " + hex.Row);

        if (hexes.Count == numTargets)
        {
            Debug.Log("Is teleporting from " + hexes[0].Column + ", " + hexes[1].Row
            + " to " + hexes[1].Column + ", "  + hexes[1].Row);

            hexes[0].Units()[0].SetHex(hexes[1]);
            hexes.Clear();

        }
    }
}
