using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : Card
{
    public Specter()
    {
        Name = "Specter";
        Color = "Black";
    }

    public override void DoAction(Hex hex)
    {
        hexes.Add(hex);
        GameComponent.SpawnUnitAt(new SpecterUnit(), GameComponent.Specter, hex.Column, hex.Row);
    }
}
