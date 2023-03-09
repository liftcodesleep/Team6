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
        Debug.Log("Added " + hex);

        if (hexes.Count == numTargets)
        {
            Debug.Log("Is teleporting");

            hexes[0].Units()[0].SetHex(hexes[1]);
            hexes.Clear();

        }
    }
}
